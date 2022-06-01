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
        public DecommissioningDTO GetDecommissioningDTO(DecommissioningViewModel decommissioningData)
        {
            string SerialNumbers = StringHelper.ConvertToCSV(decommissioningData.SerialNumbers);
            byte ReasonId = decommissioningData.ReasonId;
            string Comments = decommissioningData.Comments;
            short LocationId = 0;
            try
            {
                LocationId = SessionHelper.GetCurrentLocationId();
            }
            catch (Exception Ex)
            {
				throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }
            short UserId = 0;
            byte languageId = SessionHelper.GetLanguageId();
            return new DecommissioningDTO { SerialNumbers = SerialNumbers, ReasonId = ReasonId, Comments = Comments, LocationId = LocationId, UserId = UserId,LanguageId=languageId };
        }
    }
}