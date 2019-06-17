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

        /// <summary>
        /// Variables Globales
        /// </summary>
        public static string strBasePath = @"\\LMB-212-01\";
        public static string strUserPath = getUserPath();
        public static string strNumeroPoste;
        public static string strWord = @"\AppData\Roaming\Microsoft\Word\";
        public static string sourceDirectory = strBasePath + @"\c$\Users\" + strUserPath + strWord;
        public static string targetDirectory = @"C:\temp\destination";



        private void Button_Click(object sender, RoutedEventArgs e)
        {
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

        public void getUserPath()
        {
            String UserPath = (String)User.SelectedItem.ToString();
            String NumeroPoste = "1";

            switch (UserPath)
            {
                case "Thierry":
                        UserPath = "schedert";
                        NumeroPoste = "1";
                    break;
                case "Achilles":
                        UserPath = "gontrana";
                        NumeroPoste = "2";
                    break;
                case "Remy":
                        UserPath = "zimmermannr";
                        NumeroPoste = "4";
                    break;
                case "Maxence":
                        UserPath = "benderm";
                        NumeroPoste = "5";
                    break;
                case "Dwenn":
                        UserPath = "kaufmanndw";
                        NumeroPoste = "6";
                    break;
                case "Mehmet":
                        UserPath = "onganm";
                        NumeroPoste = "7";
                    break;
                case "Dilane":
                        UserPath = "rodriguesD";
                        NumeroPoste = "8";
                    break;
                default:
                        UserPath = "kaufmanndw";
                        NumeroPoste = "6";
                    break;
            }


            strUserPath = UserPath;
            strNumeroPoste = NumeroPoste;
        }
    }
}
