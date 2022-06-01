using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public static class DisplayModeHelper
    {
        private static string[] SeparateUserAgents(string userAgentList, char delimiter)
        {
            return userAgentList.Split(delimiter.ToString().ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        public static bool IsScanner(this HttpRequestBase request)
        {
            return IsScanner(request.UserAgent);
        }

        public static bool IsScanner(string userAgentString)
        {
            bool isScanner = false;

            string[] scannerUserAgentList = SeparateUserAgents(AppSettings.ScannerUserAgentList, AppSettings.ScannerUserAgentListDelimiter);

            string normalizedUserAgentString = Regex.Replace(userAgentString, @"\s", "");

            foreach (string scannerUserAgent in scannerUserAgentList)
            {
                if (String.Equals(normalizedUserAgentString, Regex.Replace(scannerUserAgent, @"\s", ""), StringComparison.OrdinalIgnoreCase))
                {
                    isScanner = true;
                    break;
                }
            }

            return isScanner;
        }
    }
}