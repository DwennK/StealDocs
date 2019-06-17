using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace StealDocs
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sourceDirectory = @"C:\temp\source";
            string targetDirectory = @"C:\temp\destination";

            Copy(sourceDirectory, targetDirectory);
        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            var diSource = new DirectoryInfo(sourceDirectory);
            var diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(System.IO.Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        public string getUserPath()
        {
            String UserPath = "";

            switch (User.Items.CurrentItem)
            {
                case "Thierry": UserPath = "schedert";
                    break;
                case "Achilles": UserPath = "gontrana";
                    break;
                case "Remy": UserPath = "zimmermannr";
                    break;
                case "Maxence": UserPath = "benderm";
                    break;
                case "Dwenn": UserPath = "kaufmanndw";
                    break;
                case "Mehmet": UserPath = "onganm";
                    break;
                case "Dilane": UserPath = "rodriguesD";
                    break;
                default: UserPath = "%USERNAME%";
                    break;
            }
 

            return UserPath;
        }
    }
}
