using System;

namespace Facensa.SegurancaApp.Utils
{
    public class DateUtilService    
    {
        public bool CanConvertToDate(string stringToConvert)
        {
            try
            {
                if (stringToConvert.Length >= 6)
                {
                    int days = 0, month = 0;
                    int.TryParse(stringToConvert.Substring(0, 2), out days);
                    int.TryParse(stringToConvert.Substring(2, 2), out month);

                    return days <= 31 && month <= 12;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}