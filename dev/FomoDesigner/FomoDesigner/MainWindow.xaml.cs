using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace FomoDesigner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<InstallStep> InstallSteps { get; set; } = new ObservableCollection<InstallStep>();
        public InstallStep SelectedInstallStep { get; set; } = new InstallStep();

        public MainWindow()
        {
            InitializeComponent();
            ListInstallStep.ItemsSource = InstallSteps;
        }

        #region ListInstallStep methods

        #region event
        private void ListInstallStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedInstallStep = ListInstallStep.SelectedItem as InstallStep;
            ListGroupModule.ItemsSource = SelectedInstallStep.GroupeModules;
        }
        #endregion

        #region buttons
        private void ListInstallStep_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (ListInstallStep.SelectedItem != null)
            {
                InstallStep elementToDelete = ListInstallStep.SelectedValue as InstallStep;
                ListInstallStep.SelectedIndex = -1;
                InstallSteps.Remove(elementToDelete);
            }
        }
        private void ListInstallStep_Add_Click(object sender, RoutedEventArgs e)
        {
            InstallSteps.Add(new InstallStep());
        }
        #endregion

        #endregion

        private void ListInstallStep_Up_Click(object sender, RoutedEventArgs e)
        {
            if(ListInstallStep.SelectedItem != null)
            {
                SelectedInstallStep.GroupeModules.Add(new GroupeModule());
            }
        }
    }
}
