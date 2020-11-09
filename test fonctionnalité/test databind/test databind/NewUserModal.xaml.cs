using System;
using System.Windows;

namespace test_databind
{
	/// <summary>
	/// Logique d'interaction pour NewUserModal.xaml
	/// </summary>
	public partial class NewUserModal : Window
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public User NewUser { get { return new User(){ Name =$"{FirstName} {LastName}" }; } }

        public NewUserModal()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            NewUser_FirstName.Focus();
        }

        private void NewUser_ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
