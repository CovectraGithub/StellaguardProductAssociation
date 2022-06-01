using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public static class Validator
    {
        public static bool CheckIfMultipleOf(decimal dividend, decimal divisor)
        {
            try
            {
                if (dividend % divisor == 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool CheckLength(string target, int length)
        {
            if (target.Length == length)
                return true;
            else
                return false;
        }

        public static bool CheckMinLength(string target, int length)
        {
            if (target.Length >= length)
                return true;
            else
                return false;
        }
    }
}