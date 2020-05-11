using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

        private Color findFirstTrueColor(List<KeyValuePair<Color, int>> list)
        {
            foreach (KeyValuePair<Color, int> c in list)
            {
                if (c.Key.R < 170 || c.Key.B < 170 || c.Key.G < 170 &&
                   (c.Key.R != c.Key.G || c.Key.G != c.Key.B))
                    return c.Key;
            }

            return list[0].Key;
        }

        public Color GetScreenAverageColor()
        {
            Dictionary<Color, int> colorPalette = new Dictionary<Color, int>();

            for (int y = 0; y < screen.Height; y++)
            {
                for (int x = 0; x < screen.Width; x++)
                {
                    Color c = screen.GetPixel(x, y);

                    if (colorPalette.ContainsKey(c))
                        colorPalette[c] += 1;
                    else
                        colorPalette.Add(c, 1);
                }
            }
            var list = colorPalette.OrderByDescending(k => k.Value).ToList();
            return findFirstTrueColor(list);
        }

        private Bitmap screen;
    }
}
