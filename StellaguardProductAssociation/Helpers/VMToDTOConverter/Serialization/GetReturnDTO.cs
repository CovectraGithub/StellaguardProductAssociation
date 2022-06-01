using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.CloudServiceReference;
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
        public ReturnDTO GetReturnDTO(ReturnViewModel returnData)
        {
            string hrCodes = StringHelper.ConvertToCSV(returnData.HRCodes);
            byte reasonId = returnData.ReasonId;
            string comments = returnData.Comments;
            short locationId;
            short userId;
            byte languageId = SessionHelper.GetLanguageId();

            locationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();

            return new ReturnDTO { HRCodes = hrCodes, ReasonId = reasonId, Comments = comments, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}