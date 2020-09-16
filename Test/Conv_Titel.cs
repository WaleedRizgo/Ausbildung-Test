using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data; // أظفنا مكتبة جديدة لتحويل البيانات 

namespace Test
{

    public class Conv_Titel : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((int)value) //تحويل القيمة الى رقم 
            {
                case 0:
                    return "Frau";
                case 1:
                    return "Herr";
                default:
                    return "!!!!!!!";


            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}

