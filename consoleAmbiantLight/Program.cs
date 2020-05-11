using System;
using System.Drawing;
using System.Threading.Tasks;
using Colore;
using consoleAmbiantLight.Controller;

namespace consoleAmbiantLight
{
    class Program
    {
        static void Main(string[] args)
        {
            ambiantColor();
        }

        static async void ambiantColor()
        {
            KeyboardController keyboard = new KeyboardController();
            IChroma ChromaInstance = await ColoreProvider.CreateNativeAsync();
            while (true)
            {
                ScreenShotController screen = new ScreenShotController();
                keyboard.changeKeyboardColor(screen.GetScreenAverageColor());
                keyboard.applyKeyboardColor(ChromaInstance);
            }
        }
    }
}
