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
        public AddUserDTO GetAddUserDTO(AddUserViewModel addUserData)
        {
            string username = addUserData.Username;

            string password = string.Empty;
            password = Security.Encrypt(addUserData.Password);
            string firstName = addUserData.FirstName;
            string lastName = addUserData.LastName;
            byte supplierId = addUserData.CompanyId;
            short createdBy = SessionHelper.GetCurrentUserId();
            string email = addUserData.Email;
            short locationId = addUserData.CompanyLocationId;
            short roleId = addUserData.RoleId;
            byte languageId = SessionHelper.GetLanguageId();

            return new AddUserDTO
            {
               Username = username,
               Password = password,
               FirstName = firstName,
               LastName = lastName,
               SupplierId = supplierId,
               CreatedBy = createdBy,
               Email = email,
               LocationId = locationId,
               RoleId = roleId,
               LanguageId=languageId,
            };
        }
    }
}