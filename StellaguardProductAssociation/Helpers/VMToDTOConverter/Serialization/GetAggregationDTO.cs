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
        public AggregationDTO GetAggregationDTO(AggregationViewModel aggregationData, byte childPackageTypeId, byte parentPackageTypeId)
        {
            string ChildrenSerialNumbers = StringHelper.ConvertToCSV(aggregationData.ChildrenSerialNumbers);
            string ParentSerialNumber = aggregationData.ParentSerialNumber;
            short locationId = 0;
            try
            {

                locationId = SessionHelper.GetCurrentLocationId();

            }
            catch (Exception Ex)
            {
                throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }
            short userId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            return new AggregationDTO { ChildrenSerialNumbers = ChildrenSerialNumbers, ParentSerialNumber = ParentSerialNumber, ChildPackageTypeId = childPackageTypeId, ParentPackageTypeId = parentPackageTypeId, LocationId = locationId, UserId = userId ,LanguageId=languageId};
        }
    }
}