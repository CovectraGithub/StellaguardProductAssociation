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
        public EndOfLifeEventsDTO GetEndOfLifeEventsDTO(EndOfLifeEventsViewModel eolEventData)
        {
            string serialNumbers = StringHelper.ConvertToCSV(eolEventData.SerialNumbers);
            byte statusId = eolEventData.StatusId;
            byte reasonId = eolEventData.ReasonId;
            string comments = eolEventData.Comments;
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
            return new EndOfLifeEventsDTO { SerialNumbers = serialNumbers, StatusId = statusId, ReasonId = reasonId, Comments = comments, LocationId = locationId, UserId = userId, LanguageId = languageId };
        }
    }
}