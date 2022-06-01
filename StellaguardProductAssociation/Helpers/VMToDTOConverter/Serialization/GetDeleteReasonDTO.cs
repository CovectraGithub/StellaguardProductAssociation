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
        public DeleteReasonDTO GetDeleteReasonDTO(short reasonId, byte? statusId)
        {
            byte languageId = SessionHelper.GetLanguageId();

            return new DeleteReasonDTO { ReasonId = reasonId, StatusId = statusId, LanguageId = languageId };
        }
    }
}