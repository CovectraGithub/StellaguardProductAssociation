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
        public AddProductDTO GetAddProductDTO(AddProductViewModel addProductViewModel)
        {
            return new AddProductDTO { ProductName = addProductViewModel.ProductName, DosageFormId = addProductViewModel.DosageFormId, NDC = addProductViewModel.NDC, NDCType = addProductViewModel.SeedNDCTypeValue,  Strength = addProductViewModel.Strength, LanguageId=SessionHelper.GetLanguageId(),AnvisaRegistrationNumber=addProductViewModel.AnviseRegistrationNumber, BrandOwnerId = addProductViewModel.ManufacturerId, ProductFamilyId = addProductViewModel.ProductFamilyId, ExchangeServiceId =addProductViewModel.ExchangeServiceId, ActionTypeId= addProductViewModel.ActionTypeId};
        }

        /// <summary>
        /// Crates an EditProductDTO
        /// </summary>
        /// <param name="productId">editProductViewModel</param>
        /// <param name="userId">userId</param>
        /// <returns>EditProductDTO</returns>
        public EditProductDTO GetEditProductDTO(EditProductViewModel editProductViewModel)
        {
            return new EditProductDTO { ProductId = editProductViewModel.ProductId, ProductName = editProductViewModel.ProductName,LanguageId=SessionHelper.GetLanguageId(),AnvisaRegistrationNumber=editProductViewModel.AnviseRegistrationNumber, DosageFormId = editProductViewModel.DosageFormId, NDC = editProductViewModel.NDC, NDCType = editProductViewModel.SeedNDCTypeValue, Strength = editProductViewModel.Strength, BrandOwnerId = editProductViewModel.ManufacturerId, ProductFamilyId = editProductViewModel.ProductFamilyId, ExchangeServiceId = editProductViewModel.ExchangeServiceId, ActionTypeId = editProductViewModel.ActionTypeId };
        }

        public GetProductListFilterCriteriaDTO GetGetProductListFilterCriteriaDTO(FilterProductCriteria filterCriteria)
        {
            return new GetProductListFilterCriteriaDTO
            {
                ProductName = filterCriteria.FilterProductName,
                NDC = filterCriteria.FilterProductNDC,
                BrandOwner = filterCriteria.FilterProductBrandOwner

            };
        }
    }
}