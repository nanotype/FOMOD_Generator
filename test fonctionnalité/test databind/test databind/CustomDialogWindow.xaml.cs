using System;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace test_databind
{
	/// <summary>
	/// Logique d'interaction pour CustomDialogWindow.xaml
	/// </summary>
	public partial class CustomDialogWindow : Window
    {
        public ImageSource Image { get; set; }
        public string Reponse { get { return TBox_response.Text; } }

        public CustomDialogWindow(string _question, string _reponseParDefaut = "")
        {
            InitializeComponent();
            Image = Imaging.CreateBitmapSourceFromHBitmap(Properties.Resources.interrogation.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());

            L_question.Content = _question;
            TBox_response.Text = _reponseParDefaut;
        }

        private void B_DialogOk_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            TBox_response.SelectAll();
            TBox_response.Focus();
        }
    }
}
