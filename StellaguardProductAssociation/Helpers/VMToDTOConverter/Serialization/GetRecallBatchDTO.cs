using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.CloudServiceReference;
using AuthentiTrack.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        //public RecallBatchDTO GetRecallBatchDTO(RecallBatchViewModel recallBatchData)
        //{
        //    string userBatchNumber = recallBatchData.UserBatchNumber;
        //    byte locationId = 0;
        //    short userId = 0;

        //    userId = SessionHelper.GetCurrentUserId();
        //    locationId = SessionHelper.GetCurrentLocationId();

        //    return new RecallBatchDTO { UserBatchNumber = userBatchNumber, LocationId = locationId, UserId = userId };
        //}

        public RecallBatchDTO GetRecallBatchDTO(string userBatchNumber)
        {
            short locationId = 0;
            short userId = 0;
            byte languageId = 1;
           

            userId = SessionHelper.GetCurrentUserId();
            locationId = SessionHelper.GetCurrentLocationId();
             languageId = SessionHelper.GetLanguageId();

            return new RecallBatchDTO { UserBatchNumber = userBatchNumber, LocationId = locationId, UserId = userId,LanguageId=languageId };
        }
    }
}