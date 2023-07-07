using System.Diagnostics;
using WindowsInput.Native;

namespace CopyAndPasteOmatic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool active = false;

        Thread updateThread;

        private string[] SplitMessageIntoSegments(string message, int segmentSize) // source: ChatGPT
        {
            /*int segmentCount = (int)Math.Ceiling((double)message.Length / segmentSize);
            string[] segments = new string[segmentCount];

            for (int i = 0; i < segmentCount; i++)
            {
                int startIndex = i * segmentSize;
                int length = Math.Min(segmentSize, message.Length - startIndex);
                segments[i] = message.Substring(startIndex, length);
            }*/
            List<string> segments = new List<string>();
            for (int i = 0; i < message.Length; i += segmentSize)
            {
                if (i > message.Length)
                    break;
                if (i + segmentSize > message.Length)
                    segmentSize = message.Length - i;
                segments.Add(message.Substring(i, segmentSize));
            }

            return segments.ToArray();
        }

        private void ThreadUpdate()
        {
            while (ActiveForm != null && active)
                Thread.Sleep(50);

            //Debug.WriteLine("active form not selected!");
            string[] segments = SplitMessageIntoSegments(
                richTextBox1.Invoke(() => richTextBox1.Text.Replace("\n", " ").Trim()),
                (int)richTextBox1.Invoke(() => numericMaxMessageLength.Value));
            foreach (string s in segments)
                Debug.WriteLine(s);
            int index = 0;
            while (active && ActiveForm == null)
            {
                //Debug.WriteLine("index " + index);
                string segment = segments[index];

                index++;
                //Debug.WriteLine($"'{segment}'");
                if (segment.Trim().Length <= 0)
                    continue;
                KeyboardController.sim.Keyboard.KeyPress(VirtualKeyCode.OEM_2);
                Thread.Sleep(50);
                KeyboardController.sim.Keyboard.TextEntry(segment.Trim());
                Thread.Sleep(50);
                KeyboardController.sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                statusLabel.Invoke(() => statusLabel.Text = $"Sent segment {(index)} of {segments.Length}");
                if (index > segments.Length - 1)
                {
                    if (loopedCheckBox.Invoke(() => loopedCheckBox.Checked))
                    {
                        index = 0;
                    }
                    else
                        break; // done!
                }
                int waitTime = (int)numericRate.Value;
                timeLeftLabel.Invoke(() => timeLeftLabel.Text = $"{(index * waitTime / 1000):##.##}:00/{segments.Length * waitTime / 1000:##.##}:00");
                progressBar1.Invoke(() => progressBar1.Value = (int)((decimal)index / segments.Length * 100));
                Thread.Sleep(waitTime);
            }
            if (active)
            {
                toggleButton.Invoke(() => toggleButton.Text = "Start");
                statusLabel.Invoke(() => statusLabel.Text = $"Done sending {segments.Length} segments! (Clicked on form)");
                timeLeftLabel.Invoke(() => timeLeftLabel.Text = "00:00/00:00");
            }
            active = false;
        }

        private void toggleButton_Click(object sender, EventArgs e)
        {
            if (!active)
            {
                if (ActiveForm != this)
                {
                    return; // bruh
                }
                statusLabel.Text = "Starting... (focus on application)";
                toggleButton.Text = "Stop";
                timeLeftLabel.Text = "00:00/00:00";
                progressBar1.Value = 0;
                active = true;
                updateThread = new Thread(ThreadUpdate);
                updateThread.Start();
            }
            else
            {
                active = false;
                toggleButton.Text = "Start";
                statusLabel.Text = "Stopped";
                timeLeftLabel.Text = "00:00/00:00";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            segmentCountLabel.Text = $"{SplitMessageIntoSegments(
                richTextBox1.Text.Replace("\n", " ").Trim(), (int)numericMaxMessageLength.Value).Length} segments";
        }
    }
}