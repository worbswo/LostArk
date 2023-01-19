using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace LostArkAction.Code
{
    internal class StringToImageSourceConverter : IValueConverter
    {
        #region Converter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imagePath = null;
            if ((string)value == ".png") return null;
            imagePath = (string)value;

            if (imagePath == null) return null;
            BitmapImage image = new BitmapImage();

            image.BeginInit();
            image.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            image.DecodePixelWidth = 50;
            image.DecodePixelHeight = 50;
            image.EndInit();
            if (image == null) return null;

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("The method or operation is not implemented.");
        }
        #endregion
    }
}
