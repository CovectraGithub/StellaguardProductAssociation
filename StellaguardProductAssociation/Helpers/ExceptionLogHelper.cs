using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public static class ExceptionLogHelper
    {
        public static void LogException(Exception ex)
        {
            var context = HttpContext.Current;
            Elmah.ErrorLog.GetDefault(context).Log(new Elmah.Error(ex, context));
        }
    }
}