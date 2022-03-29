using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Doma.RemoteServices.Common
{
    public static class GlobalSettings
    {
        // "https://doma-booking.ru";
        // "https://u1627485.plsk.regruhosting.ru";

        public const string BackendUri = "https://travel-helper.ru"; 

        public static CultureInfo DefaultCulture => CultureInfo.GetCultureInfo("ru-RU");
    }
}
