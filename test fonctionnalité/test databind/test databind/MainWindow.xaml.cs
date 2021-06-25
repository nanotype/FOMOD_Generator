using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

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
		public SolidColorBrush ProgressBarColor { get; set; } = new SolidColorBrush(Colors.Blue);
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

			users.Add(new User() { Name = "Jean Tartempion", Age = 34, Mail = "jean.tartempion@truc.fr" });
			users.Add(new User() { Name = "Henry Potdbeurre", Age = 22, Mail = "Henry.potdbeurre@machin.com" });

			LB_UserList.ItemsSource = users;
			ListViewUserWithOverritedToString.ItemsSource = users;
			ListViewUserWithItemTemplate.ItemsSource = users;
			ListViewUserWithGridView.ItemsSource = users;

			timer.Elapsed += Clock;

			WB_navigateur.Navigate("https://www.google.com");

			Calendar_ComboBox_ListDisplayMode.ItemsSource = Enum.GetValues(typeof(CalendarMode)).Cast<CalendarMode>();
			Calendar_ComboBox_ListDisplayMode.SelectedItem = Calendar.DisplayMode;
			Calendar_ComboBox_ListSelectionMode.ItemsSource = Enum.GetValues(typeof(CalendarSelectionMode)).Cast<CalendarSelectionMode>();
			Calendar_ComboBox_ListSelectionMode.SelectedItem = Calendar.SelectionMode;

			Calendar_DatePicker_FormatSelection.ItemsSource = Enum.GetValues(typeof(DatePickerFormat)).Cast<DatePickerFormat>();
			Calendar_DatePicker_FormatSelection.SelectedIndex = 0;

			Calendar_DateExclusion.SelectedDate = DateTime.Now;
			Calendar_RangeExclusion_Start.SelectedDate = DateTime.Now;
			Calendar_RangeExclusion_End.SelectedDate = DateTime.Now;

			Calendar_DatePicker_FormatSelection.ItemsSource = Enum.GetValues(typeof(SelectionMode)).Cast<SelectionMode>();
			Calendar_DatePicker_FormatSelection.SelectedIndex = 0;

			Expander_ToolBar_ExpandDirection.ItemsSource = Enum.GetValues(typeof(ExpandDirection)).Cast<ExpandDirection>();
			Expander_ToolBar_ExpandDirection.SelectedIndex = 0;

			IEnumerable<bool> boolEnum = new List<bool> { false, true };
			Expander_ToolBar_IsExpanded.ItemsSource = boolEnum;
			Expander_ToolBar_IsExpanded.SelectedIndex = 0;

			TabControl_Placement.ItemsSource = Enum.GetValues(typeof(Dock)).Cast<Dock>();
			TabControl_Placement.SelectedItem = Dock.Top;

			List<TaskItem> items = new List<TaskItem>();
			items.Add(new TaskItem("element1", 50));
			items.Add(new TaskItem());
			GenericItemControl.ItemsSource = items;

			ProgressBar_Color.ItemsSource = typeof(Colors).GetProperties();
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

		private void Calendar_DateList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Calendar.SelectedDate = Calendar_DateList.SelectedItem as DateTime?;
		}

		private void DockPanel_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}

		private void Calendar_Exclusion_Button_Click(object sender, RoutedEventArgs e)
		{
			Calendar.BlackoutDates.AddDatesInPast();
		}

		private void Calendar_RangeExclusion_Exclude_Click(object sender, RoutedEventArgs e)
		{
			if(Calendar_RangeExclusion_Start.SelectedDate.HasValue && Calendar_RangeExclusion_End.SelectedDate.HasValue)
			{
				CalendarDateRange range = new CalendarDateRange(Calendar_RangeExclusion_Start.SelectedDate.Value, Calendar_RangeExclusion_End.SelectedDate.Value);
				if (!Calendar.BlackoutDates.Contains(range)){
					Calendar.BlackoutDates.Add(range);
				}
				else
				{
					Calendar.BlackoutDates.Remove(range);
				}
			}
		}

		private void Calendar_DateExclusion_Exclude_Click(object sender, RoutedEventArgs e)
		{
			if (Calendar_DateExclusion.SelectedDate.HasValue)
			{
				CalendarDateRange date = new CalendarDateRange(Calendar_DateExclusion.SelectedDate.Value);
				if (!Calendar.BlackoutDates.Contains(date))
				{
					Calendar.BlackoutDates.Add(date);
				}
				else
				{
					Calendar.BlackoutDates.Remove(date);
				}
			}
		}

		private void ProgressBar_Color_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			Color selectedColor = (Color)(ProgressBar_Color.SelectedItem as PropertyInfo).GetValue(null, null);
			this.Background = new SolidColorBrush(selectedColor);
			NotifyPropertyChanged("ProgressBarColor");
			NotifyPropertyChanged("variableProgressBarColor");
		}
	}
}
