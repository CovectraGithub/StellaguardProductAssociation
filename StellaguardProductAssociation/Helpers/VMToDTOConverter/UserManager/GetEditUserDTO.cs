using AuthentiTrack.UI.Areas.UserManager.Models;
using AuthentiTrack.UI.UserManagerServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public EditUserDTO GetEditUserDTO(EditUserViewModel editUserData)
        {
            short userId = editUserData.UserId;
            string firstName = editUserData.FirstName;
            string lastName = editUserData.LastName;
            string email = editUserData.Email;
            short? roleId = editUserData.RoleId;
            byte companyId = editUserData.CompanyId;
            short modifiedBy = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            short locationId = editUserData.CompanyLocationId;
            return new EditUserDTO
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                RoleId = roleId,
                CompanyId = companyId,
                ModifiedBy = modifiedBy,
                LanguageId=languageId,
                LocationId=locationId
            };
        }
    }
}