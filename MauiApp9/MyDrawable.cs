#if WINDOWS
using Microsoft.Maui.Graphics.Win2D;
#elif !WINDOWS
using Microsoft.Maui.Graphics.Platform;
#endif

using IImage = Microsoft.Maui.Graphics.IImage;

namespace MauiApp9
{
    internal class MyDrawable : IDrawable
    {
        public bool IsCancel = false;
        public bool IsDrag = false;
        IImage image;

        public MyDrawable()
        {
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (IsDrag)
            {
                Random rnd = new Random();
                var rndNumber = rnd.Next(1, 6);

                var fileName = "one";

                switch (rndNumber)
                {
                    case 1: fileName = "one"; break;
                    case 2: fileName = "two"; break;
                    case 3: fileName = "three"; break;
                    case 4: fileName = "four"; break;
                    case 5: fileName = "five"; break;
                    default: break;
                }

                var path = Path.Combine(FileSystem.Current.AppDataDirectory, "Images", fileName + ".png");
                if (File.Exists(path))
                {
                    var buffer = File.ReadAllBytes(path);
#if WINDOWS
                    W2DImageLoadingService w2DImageLoadingService = new W2DImageLoadingService();
                    image = w2DImageLoadingService.FromBytes(buffer);

#elif !WINDOWS
                using (var stream = new MemoryStream(buffer))
                {
                    image = PlatformImage.FromStream(stream);
                }
#endif
                    if (image != null)
                    {
                        canvas.DrawImage(image, 0, 0, image.Width, image.Height);
                    }
                }
            }
        }
    }
}
