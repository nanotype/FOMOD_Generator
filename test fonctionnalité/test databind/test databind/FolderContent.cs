using System;
using System.Drawing;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace test_databind
{
	class FolderContent
    {
        public string ElementName { get; set; }
        public ImageSource Image { get; set; }

        public FolderContent(string elementName, Bitmap image)
        {
            ElementName = elementName;
            Image = Imaging.CreateBitmapSourceFromHBitmap(image.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
