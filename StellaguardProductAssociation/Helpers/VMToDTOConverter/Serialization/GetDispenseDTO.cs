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
        public DispenseDTO GetDispenseDTO(DispenseViewModel dispenseData)
        {
            string hrCodes = StringHelper.ConvertToCSV(dispenseData.HRCodes);
            string comments = dispenseData.Comments;
            short fromLocationId = 0;

            short userId = 0;
            byte languageId = 1; 


            userId = SessionHelper.GetCurrentUserId();
            fromLocationId = SessionHelper.GetCurrentLocationId();
            languageId = SessionHelper.GetLanguageId();

            return new DispenseDTO() { SerialNumbers = hrCodes, Comments = comments, LocationId = fromLocationId, UserId = userId,LanguageId=languageId };
        }
    }
}