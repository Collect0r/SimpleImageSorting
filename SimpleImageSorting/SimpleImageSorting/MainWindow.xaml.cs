using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleImageSorting
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String folder = @"E:\Data\01 Bilder\2017\!Handy\";
        String subFolder;
        string[] files;
        int imgCounter = 0;
        Pic currentPic;
        Pic previousPic;
        bool deleteFile;

        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
            files = Directory.GetFiles(folder, "*.jpg", SearchOption.TopDirectoryOnly);
        }

        private void image_Loaded(object sender, RoutedEventArgs e)
        {
            openNextImage();
        }

        private void openNextImage()
        {
            previousPic = currentPic;
            currentPic = new Pic(new FileInfo(files[imgCounter]));

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(files[imgCounter]);
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();

            image.Source = bitmap;

            imgCounter++;
        }

        private void storePreviousImage()
        {
            if (previousPic == null)
                return;

            if (deleteFile)
            {
                deleteFile = false;
                File.Delete(previousPic.PathAndName);
                return;
            }

            Directory.CreateDirectory(folder + subFolder);

            File.Move(previousPic.PathAndName, folder + subFolder + @"\" + previousPic.Date + ".jpg");
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    subFolder = "1";
                    break;
                case Key.D2:
                    subFolder = "2";
                    break;
                case Key.D3:
                    subFolder = "3";
                    break;
                case Key.D4:
                    subFolder = "4";
                    break;
                case Key.D5:
                    subFolder = "5";
                    break;
                case Key.D6:
                    subFolder = "6";
                    break;
                case Key.D7:
                    subFolder = "7";
                    break;
                case Key.D8:
                    subFolder = "8";
                    break;
                case Key.D9:
                    subFolder = "9";
                    break;
                case Key.D0:
                    subFolder = "0";
                    break;
                case Key.Delete:
                    deleteFile = true;
                    break;
            }

            openNextImage();
            storePreviousImage();
        }
    }
}
