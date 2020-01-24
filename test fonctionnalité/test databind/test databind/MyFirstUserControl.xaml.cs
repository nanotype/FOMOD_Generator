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
