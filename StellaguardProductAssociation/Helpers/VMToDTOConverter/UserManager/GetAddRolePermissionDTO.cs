using AuthentiTrack.UI.Areas.UserManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AuthentiTrack.Utility;

using AuthentiTrack.UI.UserManagerServiceReference;


namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public EditRolePermissionDTO GetAddRolePermissionDTO(RolePermissionViewModel RolePemissiomData)
        {
            string XmlRole = string.Empty;
            List<RolePermissionClass> listRoleModule;
            try
            {
                 listRoleModule = RolePemissiomData.list.Select<RolePermission, RolePermissionClass>(p =>
                         {
                             return new RolePermissionClass
                             {

                                 ModuleName = p.ModuleName,
                                 ModuleGroupName = p.ModuleGroupName,
                                 RoleId = p.RoleId,
                                 ModuleId = p.ModuleId,
                                 CanRead = p.CanRead,
                                 CanWrite = p.CanWrite,
                                 CanDelete = p.CanDelete

                             };
                         }).ToList();
            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            short UserId = 0;

            return new EditRolePermissionDTO() { roleModulelist = listRoleModule.ToArray(), UserId = UserId };
        }
    }
}