using Colore;
using System;
using System.Drawing;
using ColoreColor = Colore.Data.Color;
using Keyboard = Colore.Effects.Keyboard;

namespace consoleAmbiantLight.Controller
{
    class KeyboardController
    {
        private ColoreColor _keyboardColor;

        public ColoreColor KeyboardColor { 
            get => _keyboardColor;
            set => _keyboardColor = value;
        }

        public KeyboardController()
        {
        }

        public void changeKeyboardColor(Color rgbaColor)
        {
            KeyboardColor = new ColoreColor(
                                (byte)rgbaColor.R,
                                (byte)rgbaColor.G,
                                (byte)rgbaColor.B
                            );
        }

        public async void applyKeyboardColor(IChroma ChromaInstance)
        {
            try
            {
                Keyboard.KeyboardStatic k = new Keyboard.KeyboardStatic(KeyboardColor);
                await ChromaInstance.Keyboard.SetStaticAsync(k);
            } catch (Exception err)
            {
                Console.WriteLine("Error: " + err.Message);
            }
        }
    }
}
