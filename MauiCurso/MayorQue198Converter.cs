using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiCurso
{
    public class MayorQue198Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int numero)
            {
                if (parameter?.ToString() == "Opacity")
                    return numero > 198 ? 1.0 : 0.4; // gris tenue si está deshabilitado

                return numero > 198; // habilitado solo si es mayor a 198
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
