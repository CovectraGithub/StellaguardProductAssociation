using AuthentiTrack.UI.Models;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public class PermissionsHelper
    {
        public static bool IsAccessAllowed(List<ModulePermissions> permissionsList, string moduleName, Enumeration.ModuleActions actionType)
        {
            bool accessAllowed = false;

            ModulePermissions permissions = permissionsList.Where(m => m.Caption == moduleName).FirstOrDefault();
            
            // If no entry for this module exists, use default values (false)
            if (permissions == null)
                permissions = new ModulePermissions { ModuleId = 0, ModuleName = moduleName, CanRead = false, CanWrite = false, CanDelete = false };

            switch (actionType)
            {
                case Enumeration.ModuleActions.Read:
                    if (permissions.CanRead == true)
                        accessAllowed = true;
                    break;

                case Enumeration.ModuleActions.Write:
                    if (permissions.CanWrite == true)
                        accessAllowed = true;
                    break;

                case Enumeration.ModuleActions.Delete:
                    if (permissions.CanDelete == true)
                        accessAllowed = true;
                    break;

                default:
                    throw new ArgumentException();
            }

            return accessAllowed;
        }
    }
}