using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FomoDesigner
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Fomod Fomod { get; set; } = new Fomod();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddInstallStep(object sender, RoutedEventArgs e)
        {
            Fomod.AddInstallStep("New InstallStep");
            UpdateListInstallStep();
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
            //LB_listInstallStep.SelectedIndex = -1;
        }

        private void LB_listInstallStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int ElementSelected = LB_listInstallStep.SelectedIndex;
            if(ElementSelected >=0)
            {
                UpdateListGroupModule();
                TV_installStep_listModule.IsEnabled = true;
            }
        }

        private void UpdateListInstallStep()
        {
            LB_listInstallStep.ItemsSource = Fomod.GetInstallStepBinding();
        }

        private void UpdateListGroupModule()
        {
            TV_installStep_listModule.ItemsSource = Fomod.ListInstallStep[LB_listInstallStep.SelectedIndex].GetGroupModuleBinding();
        }

        private void DeleteInstallStep(object sender, RoutedEventArgs e)
        {
            int Element2Delete = LB_listInstallStep.SelectedIndex;
            LB_listInstallStep.SelectedIndex = -1;
            Fomod.DeleteInstallStep(Element2Delete);

            TV_installStep_listModule.ItemsSource = null;
            TV_installStep_listModule.IsEnabled = false;

            UpdateListInstallStep();
        }

        private void TV_installStep_listModule_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if(TV_installStep_listModule.SelectedValuePath == "")
            {
                ListModule_ContextMenu_deleteAction.Visibility = Visibility.Collapsed;
            }
            else
            {
                ListModule_ContextMenu_deleteAction.Visibility = Visibility.Visible;
            }
        }

        private void AddModule(object sender, RoutedEventArgs e)
        {
            Fomod.ListInstallStep[LB_listInstallStep.SelectedIndex].AddGroupeModule("New Group Module");
            UpdateListGroupModule();
        }

        private void DeleteModule(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
