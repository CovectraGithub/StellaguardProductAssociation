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
        public EditReasonDTO GetEditReasonDTO(EditReasonViewModel editReasonData)
        {
            byte reasonId = editReasonData.ReasonId;
            string statusIdCSV = String.Join(",", editReasonData.SelectedStatusList.Select(x => x.ToString()).ToArray());
            string reasonDescription = editReasonData.ReasonDescription;
            short userId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            
            return new EditReasonDTO { ReasonId = reasonId, StatusIdCSV = statusIdCSV, ReasonDescription = reasonDescription, LanguageId = languageId };
        }
    }
}