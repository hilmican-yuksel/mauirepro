using Microsoft.Maui.Storage;

namespace MauiApp9
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();

            for (int i = 1; i < 6; i++)
            {
                var fileName = "one";

                switch (i)
                {
                    case 1: fileName = "one"; break;
                    case 2: fileName = "two"; break;
                    case 3: fileName = "three"; break;
                    case 4: fileName = "four"; break;
                    case 5: fileName = "five"; break;
                    default: break;
                }

                var source = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", fileName + ".png");
                var destination = Path.Combine(FileSystem.Current.AppDataDirectory, "Images", fileName + ".png");
                if (File.Exists(source))
                {
                    if (!Path.Exists(Path.Combine(FileSystem.Current.AppDataDirectory, "Images")))
                        Directory.CreateDirectory(Path.Combine(FileSystem.Current.AppDataDirectory, "Images"));

                    if (!File.Exists(destination))
                        File.Copy(source, destination);
                }
            }


        }
    }
}