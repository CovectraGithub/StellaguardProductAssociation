using AuthentiTrack.UI.UserManagerServiceReference;
using AuthentiTrack.UI.Areas.UserManager.Models;

using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public ChangePasswordDTO ChangePassword(ChangePasswordViewModel changePasswordData)
        {
            string password=Security.Encrypt(changePasswordData.Password);
            string newPassword=Security.Encrypt(changePasswordData.NewPassword);
           
            string userName=changePasswordData.UserName;
            short userId = SessionHelper.GetCurrentUserId();
            short locationId = SessionHelper.GetCurrentLocationId();
            byte languageId = SessionHelper.GetLanguageId();
            return new ChangePasswordDTO(){UserName=userName,Password=password,NewPassword=newPassword, UserId = userId ,LocationId=locationId,LanguageId=languageId};
        }
    }
}