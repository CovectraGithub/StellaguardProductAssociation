#region Using Block

using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        /*
        public ReceivingDTO GetReceivingDTO(ReceivingViewModel receivingData)
        {
            string hrCodes = StringHelper.ConvertToCSV(receivingData.HRCodes);
            short receivingLocationId = 0;
            short userId = 0;
            byte languageId = 1;

            receivingLocationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();
            languageId = SessionHelper.GetLanguageId();

            return new ReceivingDTO { HRCodes = hrCodes,MovementTypeId=(byte)receivingData.MovementTypeId, TransactionVal=receivingData.TransactionXML,ToLocationId = receivingLocationId, UserId = userId,LanguageId=languageId };
        }
          */
        public ReceivingDTO GetReceivingDTO(ReceivingViewModel receivingData)
        {
            string hrCodes = StringHelper.ConvertToCSV(receivingData.HRCodes);
            short receivingLocationId = 0;
            short userId = 0;
            byte languageId = 1;

            receivingLocationId = SessionHelper.GetCurrentLocationId();
            userId = SessionHelper.GetCurrentUserId();
            languageId = SessionHelper.GetLanguageId();

            return new ReceivingDTO { HRCodes = hrCodes, AtLocationId = receivingLocationId, UserId = userId, LanguageId = languageId };
        }

    }
}