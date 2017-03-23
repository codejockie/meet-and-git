using System;
using System.Globalization;

namespace MeetAndGit.Helpers
{
    public class StringToTitleConverter : Xamarin.Forms.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var name = (string)value;
            string[] names = name.Split(' ');
            string titleName = "";

            foreach (var item in names)
            {
                item[0].ToString().ToUpper();
                titleName += item + " ";
            }

            return titleName.Trim();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
