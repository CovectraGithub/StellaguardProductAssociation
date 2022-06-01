using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.Areas.Serialization.Models;

using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public DisaggregationDTO GetDisaggregationDTO(DisaggregationViewModel disaggregationData)
        {
            // Get form data
            string parentSerialNumber = disaggregationData.ParentSerialNumber;
            string childrenSerialNumbers = String.IsNullOrEmpty(disaggregationData.ChildrenSerialNumbers) ? String.Empty : StringHelper.ConvertToCSV(disaggregationData.ChildrenSerialNumbers);
            short locationId = 0;
            byte languageId = 1;

            try
            {
                //  LocationId = ConfigInfo.LocationId;
                locationId = SessionHelper.GetCurrentLocationId();
                languageId = SessionHelper.GetLanguageId();
            }
            catch (Exception Ex)
            {
				throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }
            short UserId = SessionHelper.GetCurrentUserId();

            return new DisaggregationDTO { ParentSerialNumber = parentSerialNumber, ChildrenSerialNumbers = childrenSerialNumbers, LocationId = locationId, UserId = UserId,LanguageId=languageId };
        }
    }
}