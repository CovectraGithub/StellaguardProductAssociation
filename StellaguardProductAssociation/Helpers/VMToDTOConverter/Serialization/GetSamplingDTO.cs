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
        public SamplingDTO GetSamplingDTO(SamplingViewModel samplingData)
        {
            string hrCodes = StringHelper.ConvertToCSV(samplingData.HRCodes);
            short fromLocationId = 0;

            short userId = 0;


            userId = SessionHelper.GetCurrentUserId();
            fromLocationId = SessionHelper.GetCurrentLocationId();
            byte languageId = SessionHelper.GetLanguageId();

            return new SamplingDTO() { SerialNumbers = hrCodes, LocationId = fromLocationId, UserId = userId,LanguageId=languageId };
        }
    }
}