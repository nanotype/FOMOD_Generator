using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace test_databind
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Thomas { get; set; } = "Thomas apprend le WPF avec Victor !!!";
        public string Accent { get; set; } = "jé sùïs ûn âcçènt !!!";
        public bool NomDefini { get; set; } = false;
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public double Percent { get; set; } = 0;
        private readonly Timer timer = new Timer(10);
        private double clockTime;
        private readonly double waitingTime = 1000;
        public DateTime SelectedDateTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            users.Add(new User() { Name = "Jean Tartempion" });
            users.Add(new User() { Name = "Henry Potdbeurre" });

            LB_UserList.ItemsSource = users;

            timer.Elapsed += Clock;

            WB_navigateur.Navigate("https://www.google.com");

            Calendar_ComboBox_ListDisplayMode.ItemsSource = Enum.GetValues(typeof(CalendarMode)).Cast<CalendarMode>();
            Calendar_ComboBox_ListDisplayMode.SelectedItem = Calendar.DisplayMode;
            Calendar_ComboBox_ListSelectionMode.ItemsSource = Enum.GetValues(typeof(CalendarSelectionMode)).Cast<CalendarSelectionMode>();
            Calendar_ComboBox_ListSelectionMode.SelectedItem = Calendar.SelectionMode;

        }

        private void B_AddUser_Click(object sender, RoutedEventArgs e)
        {
            NewUserModal newUserModal = new NewUserModal();
            if (newUserModal.ShowDialog() == true)
            {
                users.Add(newUserModal.NewUser);
            }
        }

        private void B_ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (LB_UserList.SelectedItem != null)
            {
                CustomDialogWindow userModification = new CustomDialogWindow("Modifier le nom : ", (LB_UserList.SelectedItem as User).Name);
                if (userModification.ShowDialog() == true)
                {
                    (LB_UserList.SelectedItem as User).Name = userModification.Reponse;
                }
            }
        }

        private void B_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (LB_UserList.SelectedItem != null)
            {
                users.Remove(LB_UserList.SelectedItem as User);
            }
        }

        private void BtnSimpleMessageBox_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!");
        }

        private void BtnMessageBoxWithTitle_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!", "My App");
        }

        private void BtnMessageBoxWithButtons_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This MessageBox has extra options.\n\nHello, world?", "My App", MessageBoxButton.YesNoCancel);
        }

        private void BtnMessageBoxWithResponse_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Would you like to greet the world with a \"Hello, world\"?", "My App", MessageBoxButton.YesNoCancel);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    MessageBox.Show("Hello to you too!", "My App");
                    break;
                case MessageBoxResult.No:
                    MessageBox.Show("Oh well, too bad!", "My App");
                    break;
                case MessageBoxResult.Cancel:
                    MessageBox.Show("Nevermind then...", "My App");
                    break;
            }
        }

        private void BtnMessageBoxWithDefaultChoice_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world!", "My App", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnMessageBoxWithIcon_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, world?", "My App", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt|All files(*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                TboxContentFile.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void BtnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|Victor file (*.vpe)|*.vpe"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TboxContentFile.Text);
            }
        }

        private void BtnOpenBrowser_Click(object sender, RoutedEventArgs e)
        {
            List<FolderContent> items = new List<FolderContent>();

            var folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            TboxContentFile.Text = folderBrowserDialog.SelectedPath;
            DirectoryInfo directory = new DirectoryInfo(folderBrowserDialog.SelectedPath);

            DirectoryInfo[] directoryInfos = directory.GetDirectories();
            foreach (DirectoryInfo directoryInfo in directoryInfos)
            {
                items.Add(new FolderContent(directoryInfo.Name, Properties.Resources.folder));
            }

            FileInfo[] fileInfos = directory.GetFiles();
            foreach (FileInfo fileInfo in fileInfos)
            {
                items.Add(new FolderContent(fileInfo.Name, Properties.Resources.file));
            }

            LB_ContentFolder.ItemsSource = items;
        }

        private void B_MeNommer_Click(object sender, RoutedEventArgs e)
        {
            string nomDonne;
            if (NomDefini)
            {
                nomDonne = TBlock_Name.Text;
            }
            else
            {
                nomDonne = "Un connard";
            }
            CustomDialogWindow customDialog = new CustomDialogWindow("Qui suis-je ?", nomDonne);
            if (customDialog.ShowDialog() == true)
            {
                TBlock_Name.Text = customDialog.Reponse;
                NomDefini = true;
            }
        }

        private void B_boutonDeroulant_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = B_boutonDeroulant.FindResource("menuDeroulantBouton") as ContextMenu;
            contextMenu.PlacementTarget = sender as Button;
            contextMenu.IsOpen = true;
        }

        private void B_LaunchFakeDownload_Click(object sender, RoutedEventArgs e)
        {
            clockTime = 0;
            //déclenche l'appel de la fonction toute les x millisecondes
            timer.Enabled = true;
        }

        private void Clock(object sender, ElapsedEventArgs e)
        {
            clockTime += timer.Interval;

            Percent = (clockTime / waitingTime) * 100;
            NotifyPropertyChanged("Percent");

            if (Percent >= 100)
            {
                timer.Enabled = false;
                MessageBox.Show("Téléchargement terminé !!!", "Fake download");
            }
        }

        private void B_testDatabind_Click(object sender, RoutedEventArgs e)
        {
            Accent = "test Databind réussis !!!";
            NotifyPropertyChanged("Accent");
        }

        private void RGB_ChangedValue(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Color color = Color.FromRgb((byte)S_Red.Value, (byte)S_Green.Value, (byte)S_Blue.Value);
            Border_RGB.Background = new SolidColorBrush(color);
        }

        private void WB_navigateur_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            navigateur_URI.Text = e.Uri.OriginalString;
        }

        private void Navigateur_precedent_Click(object sender, RoutedEventArgs e)
        {
            if (WB_navigateur.CanGoBack)
                WB_navigateur.GoBack();
        }

        private void Navigateur_suivant_Click(object sender, RoutedEventArgs e)
        {
            if (WB_navigateur.CanGoForward)
                WB_navigateur.GoForward();
        }

        private void Navigateur_naviguer_Click(object sender, RoutedEventArgs e)
        {
            WB_navigateur.Navigate(navigateur_URI.Text);
        }

        private void Navigateur_URI_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                WB_navigateur.Navigate(navigateur_URI.Text);
        }

        private void Calendar_DateList_DateDetail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                DateSelected_Update();
            }
        }

        private void Calendar_DateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Calendar_DateList_DateDetail_Year.Text = SelectedDateTime.Year.ToString();
            Calendar_DateList_DateDetail_Month.Text = SelectedDateTime.Month.ToString();
            Calendar_DateList_DateDetail_Day.Text = SelectedDateTime.Day.ToString();
        }

        private void Calendar_DateList_DateDetail_ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DateSelected_Update();
        }

        private void DateSelected_Update()
        {
            if (
                int.TryParse(Calendar_DateList_DateDetail_Year.Text, out int year)
                && int.TryParse(Calendar_DateList_DateDetail_Month.Text, out int month)
                && int.TryParse(Calendar_DateList_DateDetail_Day.Text, out int day))
            {
                SelectedDateTime = new DateTime(year, month, day);
                Calendar_DateList.SelectedItem = SelectedDateTime;
            }
        }
        private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
