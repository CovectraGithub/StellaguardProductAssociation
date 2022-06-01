using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public ProvisioningRequestDTO GetProvisioningRequestDTO(ProvisioningRequestViewModel model)
        {
            return new ProvisioningRequestDTO
            {
                UserId = SessionHelper.GetCurrentUserId(),
                ProductId = model.ProductId,
                PackageTypeId = model.PackageTypeId,
                BatchNumber = model.BatchNumber == null ? null : model.BatchNumber.ToUpper(),
                Quantity = model.Quantity,
                LanguageId=SessionHelper.GetLanguageId()
            };
        }
    }
}