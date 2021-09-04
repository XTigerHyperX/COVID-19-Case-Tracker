using System.Globalization;

namespace Corona_Virus_Cases_2
{
    public static class Manager
    {
        public static string FormatValue(this decimal num)
        {
            if (num > 999999 || num < -999999 )
            {
                return num.ToString("0,,.##M", CultureInfo.InvariantCulture);
            }
            else
            if (num > 999 || num < -999)
            {
                return num.ToString("0,.#K", CultureInfo.InvariantCulture);
            }
            else
            {
                return num.ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}