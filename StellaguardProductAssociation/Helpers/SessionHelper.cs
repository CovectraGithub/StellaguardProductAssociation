using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.Models;
using AuthentiTrack.Utility;
using AuthentiTrack.UI.UserManagerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Location = AuthentiTrack.UI.Models.Location;
using System.Web.SessionState;
using System.Threading;

namespace AuthentiTrack.UI.Helpers
{
    public static class SessionHelper
    {
        public static short GetCurrentLocationId()
        {
            HttpContext context = HttpContext.Current;
           // Location location = (Location)context.Session[SessionKeys.LOCATION_SESSION];
            UserSession userSession = (UserSession)context.Session[SessionKeys.USER_SESSION];
            return userSession.CurrentLocationId;
        }

        public static short GetCurrentUserId()
        {
            HttpContext context = HttpContext.Current;
            UserSession userSession = (UserSession)context.Session[SessionKeys.USER_SESSION];
            if (userSession == null)
                return 0;
            else
                return userSession.UserId;
        }

        public static string GetCurrentUserUsername()
        {
            HttpContext context = HttpContext.Current;
            UserSession userSession = (UserSession)context.Session[SessionKeys.USER_SESSION];
            if (userSession == null)
                return String.Empty;
            else
                return userSession.Username;
        }

        public static short GetCurrentProductId()
        {
            HttpContext context = HttpContext.Current;
            ProductSession productSession = (ProductSession)context.Session[SessionKeys.PRODUCT_SESSION];
            if (productSession == null)
                return 0;
            else
                return productSession.ProductId;
        }

        public static void Logout(UserSession userSession)
        {
            if (userSession != null)
            {
                Guid authKey = userSession.AuthKey;

                try
                {
                    using (UserManagerServiceClient service = new UserManagerServiceClient())
                    {
                        service.Logout(authKey);
                    }
                }

                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static byte GetLanguageId()
        {
            HttpContext context = HttpContext.Current;
            UserSession userSession = (UserSession)context.Session[SessionKeys.USER_SESSION];
            if (userSession == null)
                return 1;
            else
                return userSession.LanguageId;
        }

        //public static byte GetLanguageId()
        //{
        //    HttpContext context = HttpContext.Current;
        //    byte laguageId = 1;
        //    string cultuerName = Thread.CurrentThread.CurrentCulture.Name;
        //    if (context.Session[SessionKeys.LANGUAGE_KEY] != null)
        //    {
        //        if (cultuerName == (string)context.Session[SessionKeys.LANGUAGE_KEY])
        //        {
        //            if (context.Session[SessionKeys.LANGUAGE_ID] != null)
        //            {
        //                return (byte)context.Session[SessionKeys.LANGUAGE_ID];
        //            }
        //            else
        //            {
        //                if (context.Session[SessionKeys.SEED_LANGUAGE] != null)
        //                {
        //                    List<SeedLanguage> list = (List<SeedLanguage>)context.Session[SessionKeys.SEED_LANGUAGE];
        //                    laguageId = list.Where(x => x.CultureCode == cultuerName).Select(x => x.LanguageId).FirstOrDefault();
        //                    return laguageId;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        context.Session[SessionKeys.LANGUAGE_KEY] = cultuerName;
        //        if (context.Session[SessionKeys.SEED_LANGUAGE] != null)
        //        {
        //            List<SeedLanguage> list = (List<SeedLanguage>)context.Session[SessionKeys.SEED_LANGUAGE];
        //            laguageId = list.Where(x => x.CultureCode == cultuerName).Select(x => x.LanguageId).FirstOrDefault();
        //            context.Session[SessionKeys.LANGUAGE_ID] = laguageId;
        //            return laguageId;
        //        }

        //    }

        //    return 1;
        //}


    }
}