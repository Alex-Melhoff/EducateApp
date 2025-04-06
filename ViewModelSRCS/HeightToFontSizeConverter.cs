using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace EducateApp
{
    public class HeightToFontSizeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height)
            {
                // размер шрифта будет 5/6 от высоты контейнера
                return height * 5 / 6;
            }
            return 20; // Значение по умолчанию. Необходимо добавить логи
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double height)
            {
                return height * 6 / 5;
            }
            return 24; // Значение по умолчанию. Необходимо добавить логи
        }
    }
}
