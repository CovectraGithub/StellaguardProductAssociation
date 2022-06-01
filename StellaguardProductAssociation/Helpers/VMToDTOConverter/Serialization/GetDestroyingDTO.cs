#region Using Block

using AuthentiTrack.UI.SerializationServiceReference;

using AuthentiTrack.UI.Areas.Serialization.Models;

using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public DestroyingDTO GetDestroyingDTO(DestroyingViewModel destroyingData)
        {
            string hrCodes = StringHelper.ConvertToCSV(destroyingData.HRCodes);
            short locationId = 0;
            short userId = 0;

            locationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            return new DestroyingDTO { HRCodes = hrCodes, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}