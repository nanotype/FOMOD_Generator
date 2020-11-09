using System.Windows.Controls;

namespace test_databind
{
	/// <summary>
	/// Logique d'interaction pour MyFirstUserControl.xaml
	/// </summary>
	public partial class MyFirstUserControl : UserControl
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public MyFirstUserControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}
