using AuthentiTrack.UI.Areas.UserManager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.Models;
using AuthentiTrack.UI.UserManagerServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddRoleDTO GetAddRoleDTO(AddRoleViewModel roleViewModel)
        {
            string roleName = roleViewModel.Name; 
            string description = roleViewModel.Description;
            byte defaultModuleId = roleViewModel.DefaultModuleId;
            byte languageId = SessionHelper.GetLanguageId();

            return new AddRoleDTO
            {
                Name = roleName,
                Description = description,
                DefaultModuleId = defaultModuleId,
                LanguageId=languageId
            };
        }

        public EditRoleDTO GetEditRoleDTO(EditRoleViewModel roleViewModel)
        {
            short roleId = roleViewModel.RoleId;
            string roleName = roleViewModel.Name;
            string description = roleViewModel.Description;
            byte defaultModuleId = roleViewModel.DefaultModuleId;
            byte languageId = SessionHelper.GetLanguageId();

            return new EditRoleDTO
            {
                RoleId = roleId,
                Description = description,
                DefaultModuleId = defaultModuleId,
                LanguageId=languageId
            };
        }
    }
}