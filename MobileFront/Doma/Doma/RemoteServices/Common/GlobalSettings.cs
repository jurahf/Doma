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
        // "https://travel-helper.ru"; 

#if DEBUG
        public const string BackendUri = "https://4596-83-222-68-201.ngrok.io";
#else
        public const string BackendUri = "https://doma-booking.ru";
#endif

        public static CultureInfo DefaultCulture => CultureInfo.GetCultureInfo("ru-RU");
    }
}
