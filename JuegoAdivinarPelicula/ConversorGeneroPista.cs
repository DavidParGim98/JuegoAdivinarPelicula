using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoAdivinarPelicula
{
    class ConversorGeneroPista : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value)
            {
                case 0:
                    return "assets/comedia.png";
                case 1:
                    return "assets/drama.png";
                case 2:
                    return "assets/accion.png";
                case 3:
                    return "assets/terror.png";
                case 4:
                    return "assets/scifi.png";
            }

            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
