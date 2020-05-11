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
            Color tmp = new Color();
            while (true)
            {
                ScreenShotController screen = new ScreenShotController();
                Console.WriteLine("Tmp: " + tmp.ToString() + "\nScreen Color: " + screen.GetScreenAverageColor());
                if (tmp != screen.GetScreenAverageColor())
                {
                    tmp = screen.GetScreenAverageColor();
                    keyboard.changeKeyboardColor(screen.GetScreenAverageColor());
                    keyboard.applyKeyboardColor(ChromaInstance);
                }
            }
        }
    }
}
