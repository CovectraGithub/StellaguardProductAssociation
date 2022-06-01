using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public RepackagingDTO GetRepackagingDTO(RepackagingViewModel repackagingData)
        {
            string existingParent = repackagingData.ExistingParent;
            string newParent = repackagingData.NewParent;
            short locationId = 0;
            short userId = 0;
            byte languageId = 1;

            userId = SessionHelper.GetCurrentUserId();
            locationId = SessionHelper.GetCurrentLocationId();
            languageId = SessionHelper.GetLanguageId();

            return new RepackagingDTO { ExistingParent = existingParent, NewParent = newParent, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}