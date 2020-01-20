using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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

        #region InstallStep ListBox

        #region Function

        private void UpdateListInstallStep()
        {
            LB_listInstallStep.ItemsSource = Fomod.GetInstallStepBinding();
        }

        #endregion

        #region Event

        private void LB_listInstallStep_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            if (LB_listInstallStep.SelectedIndex == -1)
            {
                LB_listInstallStep.ContextMenu = LB_listInstallStep.Resources["ListBoxContext"] as ContextMenu;
            }
            else
            {
                LB_listInstallStep.ContextMenu = LB_listInstallStep.Resources["InstallStepContext"] as ContextMenu;
            }
        }

        private void LB_listInstallStep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LB_listInstallStep.SelectedIndex >= 0)
            {
                UpdateListGroupModule();
                TV_installStep_listModule.IsEnabled = true;
            }
        }

        #endregion

        #region ContextMenu function

        private void AddInstallStep(object sender, RoutedEventArgs e)
        {
            Fomod.AddInstallStep("New InstallStep");
            UpdateListInstallStep();
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

        #endregion

        #endregion

        #region GroupModule and Module TreeView

        #region Function

        private void UpdateListGroupModule()
        {
            TV_installStep_listModule.ItemsSource = Fomod.InstallSteps[LB_listInstallStep.SelectedIndex].GetGroupModuleBinding();
        }

        private void LoadTreeViewContextMenu()
        {
            if (TV_installStep_listModule.SelectedItem is TreeViewItem selectedItem)
            {
                switch (selectedItem.Tag.ToString())
                {
                    case "GroupModule":
                        TV_installStep_listModule.ContextMenu = TV_installStep_listModule.Resources["GroupModuleContext"] as ContextMenu;
                        break;

                    case "Module":
                        TV_installStep_listModule.ContextMenu = TV_installStep_listModule.Resources["ModuleContext"] as ContextMenu;
                        break;
                }
            }
            else
            {
                TV_installStep_listModule.ContextMenu = TV_installStep_listModule.Resources["TreeViewContext"] as ContextMenu;
            }
        }

        #endregion

        #region Event

        private void TV_installStep_listModule_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = GetTreeViewItem(e.OriginalSource as DependencyObject);
            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
            else
            {
                if (TV_installStep_listModule.SelectedItem is TreeViewItem selectedItem)
                {
                    selectedItem.IsSelected = false;
                }
            }
        }

        private static TreeViewItem GetTreeViewItem(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
            {
                source = VisualTreeHelper.GetParent(source);
            }
            return source as TreeViewItem;
        }

        private void TV_installStep_listModule_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LoadTreeViewContextMenu();

            if ((e.Source as TreeView).SelectedItem is TreeViewItem element && element.Tag.ToString() == "Module")
            {
                TreeViewItem parent = element.Parent as TreeViewItem;
                TB_installStep_descriptionModule.DataContext = Fomod.InstallSteps[LB_listInstallStep.SelectedIndex].ListGroupeModule[TV_installStep_listModule.Items.IndexOf(parent)].ListModule[parent.Items.IndexOf(element)].Description;
            }

        }

        private void TV_installStep_listModule_Loaded(object sender, RoutedEventArgs e)
        {
            TV_installStep_listModule.ContextMenu = TV_installStep_listModule.Resources["TreeViewContext"] as ContextMenu;
        }

        private void TV_installStep_listModule_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TV_installStep_listModule.SelectedItem is TreeViewItem selectedItem)
            {
                selectedItem.IsSelected = false;
            }
        }

        #endregion

        #region ContextMenu function

        #region GroupModule

        private void AddGroupModule(object sender, RoutedEventArgs e)
        {
            Fomod.InstallSteps[LB_listInstallStep.SelectedIndex].AddGroupeModule("New Group Module");
            UpdateListGroupModule();
        }

        private void DeleteGroupModule(object sender, RoutedEventArgs e)
        {
            Fomod
                .InstallSteps[LB_listInstallStep.SelectedIndex]
                .DeleteGroupeModule(TV_installStep_listModule.Items.IndexOf(TV_installStep_listModule.SelectedItem));

            UpdateListGroupModule();
        }

        #endregion

        #region Module

        private void AddModule(object sender, RoutedEventArgs e)
        {
            Fomod
                .InstallSteps[LB_listInstallStep.SelectedIndex]
                .ListGroupeModule[TV_installStep_listModule.Items.IndexOf(TV_installStep_listModule.SelectedItem)]
                .AddModule("New Module");

            UpdateListGroupModule();
        }

        private void DeleteModule(object sender, RoutedEventArgs e)
        {
            TreeViewItem element2Delete = TV_installStep_listModule.SelectedItem as TreeViewItem;
            TreeViewItem parentElement = element2Delete.Parent as TreeViewItem;

            Fomod
                .InstallSteps[LB_listInstallStep.SelectedIndex]
                .ListGroupeModule[TV_installStep_listModule.Items.IndexOf(parentElement)]
                .DeleteModule(parentElement.Items.IndexOf(element2Delete));

            UpdateListGroupModule();
        }

        #endregion

        #endregion

        #endregion
    }
}
