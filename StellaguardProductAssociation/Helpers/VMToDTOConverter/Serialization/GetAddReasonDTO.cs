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
        public AddReasonDTO GetAddReasonDTO(AddReasonViewModel addReasonData)
        {
            string statusIdCSV = String.Join(",", addReasonData.SelectedStatusList.Select(x => x.ToString()).ToArray());
            string reasonDescription = addReasonData.ReasonDescription;
            short userId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            
            return new AddReasonDTO { StatusIdCSV = statusIdCSV, ReasonDescription = reasonDescription, LanguageId = languageId, CreatedBy = userId };
        }
    }
}