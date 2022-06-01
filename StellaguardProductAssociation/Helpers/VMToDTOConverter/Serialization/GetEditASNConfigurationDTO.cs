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
        public EditASNConfigurationDTO GetEditASNConfigurationDTO(EditASNConfigurationViewModel editData)
        {
            byte languageId = SessionHelper.GetLanguageId();
            return new EditASNConfigurationDTO 
            {
                ASNConfigurationId = editData.ASNConfigurationId,
                IsASNGenerationAutomated = editData.IsASNGenerationAutomated==1,
                IsASNSentOnOwnershipTransferOnly = editData.IsASNSentOnOwnershipTransferOnly==1,
                LanguageId = languageId
            };
        }
    }
}