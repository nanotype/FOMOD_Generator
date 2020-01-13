using System;
using System.Collections.Generic;
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

namespace FomoDesigner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Fomod fomod = new Fomod();

        public MainWindow()
        {
            InitializeComponent();
            //DataContext = fomod;
        }

        private void addInstallStep(object sender, RoutedEventArgs e)
        {
            fomod.addInstallStep("test");
            updateListInstallStep();
        }

        private void LB_listInstallStep_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (LB_listInstallStep.SelectedIndex == -1)
            {
                ListInstallStep_ContextMenu_deleteAction.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListInstallStep_ContextMenu_deleteAction.Visibility = Visibility.Visible;
            }
        }

        private void LB_listInstallStep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LB_listInstallStep.SelectedIndex = -1;
        }

        private void LB_listInstallStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ElementSelected = LB_listInstallStep.SelectedIndex;
            //TV_installStep_listModule.ItemsSource=
        }

        private void updateListInstallStep()
        {
            LB_listInstallStep.ItemsSource = fomod.GetInstallStepBinding();
        }

        private void deleteInstallStep(object sender, RoutedEventArgs e)
        {
            int Element2Delete = LB_listInstallStep.SelectedIndex;
            LB_listInstallStep.SelectedIndex = -1;
            fomod.deleteInstallStep(Element2Delete);
            updateListInstallStep();
        }
    }
}
