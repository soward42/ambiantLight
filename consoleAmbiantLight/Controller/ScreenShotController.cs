using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace consoleAmbiantLight.Controller
{
    class ScreenShotController
    {
        public ScreenShotController()
        {
            screen = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                               Screen.PrimaryScreen.Bounds.Height,
                               PixelFormat.Format32bppArgb);
            Graphics sc = Graphics.FromImage(screen);
            sc.CopyFromScreen(
                Screen.PrimaryScreen.Bounds.X,
                Screen.PrimaryScreen.Bounds.Y,
                0,
                0,
                Screen.PrimaryScreen.Bounds.Size
            );
        }

        private int FlattenRed(int red)
        {
            if (red % 10 < 5)
                return red - (red % 10);
            if (red % 10 > 5)
                return red + (10 - (red % 10));
            return red;
        }
        
        private int FlattenGreen(int green)
        {
            if (green % 10 < 5)
                return green - (green% 10);
            if (green % 10 > 5)
                return green + (10 - (green % 10));
            return green;
        }
        
        private int FlattenBlue(int blue)
        {
            if (blue % 10 < 5)
                return blue - (blue % 10);
            if (blue % 10 > 5)
                return blue + (10 - (blue % 10));
            return blue;
        }

        private Color FlattenColor(Color color)
        {
            int R = FlattenRed(color.R);
            int G = FlattenGreen(color.G);
            int B = FlattenBlue(color.B);

            return Color.FromArgb(R, G, B);
        }
        public Color GetScreenAverageColor()
        {
            int r = 0;
            int g = 0;
            int b = 0;

            int total = 0;

            for (int y = 0; y < screen.Height; y++)
            {
                for (int x = 0; x < screen.Width; x++)
                {
                    Color c = screen.GetPixel(x, y);

                    r += c.R;
                    g += c.G;
                    b += c.B;
                        
                    total++;
                }
            }
            r /= total;
            g /= total;
            b /= total;
            return FlattenColor(Color.FromArgb(r, g, b));
        }

        private Bitmap screen;
    }
}
