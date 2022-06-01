#region Using Block

using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
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
        public DivertedDTO GetDivertedDTO(DivertedViewModel divertedData)
        {
            string hrCodes = StringHelper.ConvertToCSV(divertedData.HRCodes);
            bool areInnerPackagesAffected = divertedData.AreInnerPackagesAffected;
            short locationId = 0;
            short userId = 0;
            byte languageId = 1;

            locationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();
            languageId = SessionHelper.GetLanguageId();

            return new DivertedDTO { HRCodes = hrCodes, AreInnerPackagesAffected = areInnerPackagesAffected, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}