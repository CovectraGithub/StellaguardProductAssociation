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
        public QuarantineDTO GetQuarantineDTO(QuarantineViewModel quarantineData)
        {
            string hrCodes = StringHelper.ConvertToCSV(quarantineData.HRCodes);
            short locationId;
            short userId;
            byte languageId = 1;

            locationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();
            languageId = SessionHelper.GetLanguageId();

            return new QuarantineDTO { HRCodes = hrCodes, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}