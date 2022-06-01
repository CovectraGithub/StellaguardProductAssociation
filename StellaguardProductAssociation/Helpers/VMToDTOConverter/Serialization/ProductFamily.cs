using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.Areas.Serialization.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        /// <summary>
        /// Creates an AddProductDTO
        /// </summary>
        /// <param name="addProductViewModel">addProductViewModel</param>
        /// <returns>AddProductDTO</returns>
        public AddProductFamilyDTO GetAddProductFamilyDTO(AddProductFamilyViewModel addProductFamilyViewModel)
        {
            return new AddProductFamilyDTO { ProductFamilyName = addProductFamilyViewModel.ProductFamilyName, CompanyPrefix = addProductFamilyViewModel.CompanyPrefix, IsActive = addProductFamilyViewModel.IsActive,LanguageId = SessionHelper.GetLanguageId(),  CreatedBy = addProductFamilyViewModel.CreatedBy };
        }

        /// <summary>
        /// Creates an AddProductDTO
        /// </summary>
        /// <param name="addProductViewModel">addProductViewModel</param>
        /// <returns>AddProductDTO</returns>
        public EditProductFamilyDTO GetEditProductFamilyDTO(EditProductFamilyViewModel editProductFamilyViewModel)
        {
            return new EditProductFamilyDTO { ProductFamilyId =editProductFamilyViewModel.ProductFamilyId, ProductFamilyName = editProductFamilyViewModel.ProductFamilyName, CompanyPrefix = editProductFamilyViewModel.CompanyPrefix, IsActive = editProductFamilyViewModel.IsActive, LanguageId = SessionHelper.GetLanguageId(), ModifiedBy = editProductFamilyViewModel.ModifiedBy };
        }
    }
}