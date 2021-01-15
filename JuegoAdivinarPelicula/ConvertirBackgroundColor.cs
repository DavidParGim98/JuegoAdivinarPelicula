using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JuegoAdivinarPelicula
{
    class ConvertirBackgroundColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals((Pelicula.Dificultad)0))
            {
                return "PaleGreen";
            }
            else if (value.Equals((Pelicula.Dificultad)1))
            {
                return "Yellow";
            }
            else if (value.Equals((Pelicula.Dificultad)2))
            {
                return "IndianRed";
            }
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
