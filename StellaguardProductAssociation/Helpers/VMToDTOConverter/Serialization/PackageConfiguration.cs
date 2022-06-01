using AuthentiTrack.UI.Areas.Serialization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.SerializationServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddPackageConfigurationDTO GetAddPackageConfigurationDTO(AddPackageConfigurationViewModel model)
        {
            short productId = model.ProductId;
            byte packageTypeId = model.PackageTypeId;
            byte? extensionDigit = model.ExtensionDigit;  
            decimal reserveCount = model.ReserveCount;
            byte generationTypeId = model.GenerationTypeId;
            string SGTIN = model.SGTINPrefix;
            int blockSize = model.BlockSize;
            decimal defaultRangeStartNumber = model.DefaultRangeStartNumber;
            decimal defaultRangeEndNumber = model.DefaultRangeEndNumber;
            short UserId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            byte generationMethodId = model.GenerationMethodId;
            byte sharedRangeId = model.SharedRangeId;

            return new AddPackageConfigurationDTO
            {
                ProductId = productId,
                PackageTypeId = packageTypeId,
                ExtensionDigit = extensionDigit,
                GenerationTypeId = generationTypeId,
                ReserveCount = reserveCount,
                SGTINPrefix = SGTIN,
                BlockSize = blockSize,
                DefaultRangeStartNumber = defaultRangeStartNumber,
                DefaultRangeEndNumber = defaultRangeEndNumber,
                CreatedBy = UserId,
                LanguageId = languageId,
                GenerationMethodId = generationMethodId,
                sharedRangeId = sharedRangeId
            };
        }

        public EditPackageConfigurationDTO GetEditPackageConfigurationDTO(EditPackageConfigurationViewModel model)
        {
            short productPackageConfigurationId = model.PackageConfigurationId;
            decimal reserveCount = model.ReserveCount;
            string SGTIN = model.SGTINPrefix;
            short modifiedBy = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();

            return new EditPackageConfigurationDTO
            {
                ProductPackageConfigurationId = productPackageConfigurationId,
                ReserveCount = reserveCount,
                SGTINPrefix = SGTIN,
                ModifiedBy = modifiedBy,
                LanguageId=languageId
            };
        }

        public AddPackageRangeDTO GetAddPackageRangeDTO(AddPackageRangeViewModel model)
        {
            short packageConfigurationId = model.PackageConfigurationId;
            decimal startNumber = model.StartNumber;
            decimal endNumber = model.EndNumber;
            short createdBy = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            byte SharedRangeId = model.SharedRangeId;

            return new AddPackageRangeDTO
            {
                ProductPackageConfigurationId = packageConfigurationId,
                StartNumber = startNumber,
                EndNumber = endNumber,
                CreatedBy = createdBy,
                LanguageId=languageId,
                SharedRangeId = SharedRangeId
            };
        }
    }
}