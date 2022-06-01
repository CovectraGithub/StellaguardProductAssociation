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
        public UpdateUserLocationDTO UpdateUserLocation(short locationId)
        {
            short userId = SessionHelper.GetCurrentUserId();
            byte userLanguageId = SessionHelper.GetLanguageId();
            return new UpdateUserLocationDTO() { LanguageId = userLanguageId,LocationId  = locationId, UserId=userId };
        }
    }
}