using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace test_databind
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string Thomas { get; set; } = "Thomas apprend le WPF avec Victor !!!";
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            users.Add(new User() { Name = "Jean Tartempion" });
            users.Add(new User() { Name = "Henry Potdbeurre" });

            LB_UserList.ItemsSource = users;
        }

        private void B_AddUser_Click(object sender, RoutedEventArgs e)
        {
            users.Add(new User() { Name = "Nouvel utilisateur" });
        }

        private void B_ChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(LB_UserList.SelectedItem != null)
            {
                (LB_UserList.SelectedItem as User).Name = "Nom modifié";
            }
        }

        private void B_DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if(LB_UserList.SelectedItem != null)
            {
                users.Remove(LB_UserList.SelectedItem as User);
            }
        }
    }
}
