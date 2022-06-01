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
        public AddASNConfigurationDTO GetAddASNConfigurationDTO(AddASNConfigurationViewModel addASNConfigurationData)
        {
            short createdBy = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            
            return new AddASNConfigurationDTO { CreatedBy = createdBy, IsASNGenerationAutomated = addASNConfigurationData.IsASNGenerationAutomated.ToBooleanSafe() , IsASNSentOnOwnershipTransferOnly = addASNConfigurationData.IsASNSentOnOwnershipTransferOnly.ToBooleanSafe() , LanguageId = languageId , Supplierid = addASNConfigurationData.SupplierId};
        }
    }
}