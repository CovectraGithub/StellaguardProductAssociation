using AuthentiTrack.UI.Models;
using MvcSiteMapProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public class CustomVisibilityProvider : SiteMapNodeVisibilityProviderBase
    {
        public override bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata)
        {
            bool isScanner = Convert.ToBoolean(sourceMetadata["isScanner"]);

            bool isAccessAllowed = false;
            bool isVisibleOnScanner = false;

            // Is a visibility attribute specified?
            string visibility = node.Attributes.Keys.Contains("visibility") ? (string)node.Attributes["visibility"] : String.Empty;
            if (string.IsNullOrEmpty(visibility))
            {
                // If not specified, access allowed
                isAccessAllowed = true;

                // If not specified, not visible on scanner
                isVisibleOnScanner = true;

                if (isScanner == false)
                    return isAccessAllowed;
                else
                    return isAccessAllowed && isVisibleOnScanner;
            }
            visibility = visibility.Trim();

            //process visibility

            VisibilityDetails visibilityData = JsonConvert.DeserializeObject<VisibilityDetails>(visibility);

            string module = visibilityData.Module;
            string actionType = visibilityData.ActionType;
            bool allowedInScanner = visibilityData.ShowInScanner;

            // If module and action type not specified, access is allowed
            if (String.IsNullOrEmpty(module) && String.IsNullOrEmpty(actionType))
            {
                isAccessAllowed = true;
            }
            // Else, access is allowed depending on module permissions
            else
            {
                var session = HttpContext.Current.Session;

                ModulePermissionsSession modulePermissionsSession = (ModulePermissionsSession)session[AuthentiTrack.Utility.SessionKeys.MODULE_PERMISSIONS_SESSION];

                List<ModulePermissions> permissionsList = modulePermissionsSession.ModulePermissionsList;

                isAccessAllowed = PermissionsHelper.IsAccessAllowed(permissionsList, module, (Utility.Enumeration.ModuleActions)Enum.Parse(typeof(Utility.Enumeration.ModuleActions), actionType));
            }

            isVisibleOnScanner = Convert.ToBoolean(allowedInScanner);

            if (isScanner == false)
                return isAccessAllowed;
            else
                return isAccessAllowed && isVisibleOnScanner;

            // return isAccessAllowed && (!isScanner || isVisibleOnScanner);

        }
    }

    public class VisibilityDetails
    {
        public string Module { get; set; }
        public string ActionType { get; set; }
        public bool ShowInScanner { get; set; }
    }
}