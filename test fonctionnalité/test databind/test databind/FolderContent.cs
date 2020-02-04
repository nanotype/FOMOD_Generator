using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            IntPtr gdiImage = image.GetHbitmap();
            Image = Imaging.CreateBitmapSourceFromHBitmap(gdiImage, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
