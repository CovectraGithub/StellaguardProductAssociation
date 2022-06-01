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
        public DamagingDTO GetDamagingDTO(DamagingViewModel damagingData)
        {
            string SerialNumbers = StringHelper.ConvertToCSV(damagingData.SerialNumbers);
            bool AreChildrenSerialNumbers = damagingData.AreChildrenSerialNumbers;
            bool AreInnerPackagesAffected = damagingData.AreInnerPackagesAffected;
            short LocationId = 0;
            try
            {
                // LocationId = ConfigInfo.LocationId;
                LocationId = SessionHelper.GetCurrentLocationId();
            }
            catch (Exception Ex)
            {
				throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }
            short UserId = 0;
            byte languageId = 1;
            LocationId = SessionHelper.GetCurrentLocationId();
            UserId = SessionHelper.GetCurrentUserId();
              languageId=  SessionHelper.GetLanguageId();

            return new DamagingDTO() { SerialNumbers = SerialNumbers, AreChildrenSerialNumbers = AreChildrenSerialNumbers, AreInnerPackagesAffected = AreInnerPackagesAffected, LocationId = LocationId, UserId = UserId,LanguageId=languageId };
        }
    }
}