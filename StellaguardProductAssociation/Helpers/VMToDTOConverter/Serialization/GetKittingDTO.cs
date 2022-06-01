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
        public KittingDTO GetkittingDTO(KittingViewModel kittingData)
        {
            string ChildrenSerialNumbers = StringHelper.ConvertToCSV(kittingData.ChildrenSerialNumbers);
            string ParentSerialNumber = kittingData.ParentSerialNumber;
            short locationId = 0;
            byte languageId = 1;
            short userId = 0;
            try
            {

                locationId = SessionHelper.GetCurrentLocationId();
                languageId = SessionHelper.GetLanguageId();
                userId = SessionHelper.GetCurrentUserId();

            }
            catch (Exception Ex)
            {
				throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }

            return new KittingDTO { ChildrenSerialNumbers = ChildrenSerialNumbers, ParentSerialNumber = ParentSerialNumber, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}