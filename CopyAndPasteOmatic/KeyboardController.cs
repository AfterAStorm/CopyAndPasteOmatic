using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace CopyAndPasteOmatic
{
    public static class KeyboardController
    {

        #region # - Constants

        private readonly static Dictionary<char, VirtualKeyCode[]> keyPairs = new Dictionary<char, VirtualKeyCode[]>()
        {
            { '!', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_1 } },
            { '@', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_2 } },
            { '$', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_4 } },
            { '%', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_5 } },
            { '^', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_6 } },
            { '*', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_8 } },
            { '(', new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, VirtualKeyCode.VK_9 } }
        };

        public static readonly InputSimulator sim = new InputSimulator();

        public static List<VirtualKeyCode> DownedKeys = new List<VirtualKeyCode>();

        #endregion

        #region # - Methods

        public static bool IsCapital(char character)
        {
            return char.IsUpper(character);
        }

        public static VirtualKeyCode GetVirtualKeyCodeFromCharacter(char key)
        {
            try
            {
                return (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), $"VK_{char.ToUpper(key)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to parse key \"{key}\" because: ${ex.Message}");
                return VirtualKeyCode.SPACE;
            }
        }

        public static VirtualKeyCode[] GetVirtualKeyCodesFromCharacter(char key)
        {
            bool hasPair = keyPairs.TryGetValue(key, out VirtualKeyCode[]? values);

            if (hasPair)
            {
                if (values != null)
                    return values;
                else
                    return new VirtualKeyCode[0];
            }
            else
            {
                if (IsCapital(key))
                {
                    return new VirtualKeyCode[2] { VirtualKeyCode.LSHIFT, GetVirtualKeyCodeFromCharacter(key) };
                }
                else
                {
                    return new VirtualKeyCode[1] { GetVirtualKeyCodeFromCharacter(key) };
                }
            }
        }

        public static void KeyDown(VirtualKeyCode[] keyCodes)
        {
            foreach (VirtualKeyCode keyCode in keyCodes)
            {
                if (!DownedKeys.Contains(keyCode))
                    DownedKeys.Add(keyCode);
                sim.Keyboard.KeyDown(keyCode);
            }
        }

        public static void KeyUp(VirtualKeyCode[] keyCodes)
        {
            foreach (VirtualKeyCode keyCode in keyCodes.Reverse())
            {
                if (DownedKeys.Contains(keyCode))
                    DownedKeys.Remove(keyCode);
                sim.Keyboard.KeyUp(keyCode);
            }
        }

        public static void KeyPress(VirtualKeyCode[] keyCodes)
        {
            sim.Keyboard.KeyPress(keyCodes);
        }

        public static void KeyDown(VirtualKeyCode keyCode)
        {
            if (!DownedKeys.Contains(keyCode))
                DownedKeys.Add(keyCode);
            sim.Keyboard.KeyDown(keyCode);
        }

        public static void KeyUp(VirtualKeyCode keyCode)
        {
            if (DownedKeys.Contains(keyCode))
                DownedKeys.Remove(keyCode);
            sim.Keyboard.KeyUp(keyCode);
        }

        public static void KeyPress(VirtualKeyCode keyCode)
        {
            sim.Keyboard.KeyPress(keyCode);
        }

        #endregion

    }
}
