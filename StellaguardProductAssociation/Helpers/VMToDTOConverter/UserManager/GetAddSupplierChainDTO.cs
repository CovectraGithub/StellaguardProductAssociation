using AuthentiTrack.UI.UserManagerServiceReference;
using AuthentiTrack.UI.Areas.UserManager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.Utility;
namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddSupplierChainDTO GetAddSupplierChainDTO(AddSupplierViewModel supplierChainViewModel)
        {
            byte laguageId = SessionHelper.GetLanguageId();
			
            return new AddSupplierChainDTO {
				CompanyCNPJNumber=supplierChainViewModel.CompanyCNPJNumber,
				SupplierChainTypeId = supplierChainViewModel.SupplierTypeId,
				SupplierChainName = supplierChainViewModel.SupplierChainName,
				LanguageId = laguageId,

				Address1 = supplierChainViewModel.Address1,
				BranchContactAddressId = supplierChainViewModel.BranchContactAddressId,
				City = supplierChainViewModel.City,
				SupplierId = supplierChainViewModel.SupplierId,
				CountryId = supplierChainViewModel.SelectedCountryId,
				Email = supplierChainViewModel.Email,
				PhoneNumber1 = supplierChainViewModel.PhoneNumber1,
				StateId = supplierChainViewModel.SelectedStateId,
				Zip = supplierChainViewModel.Zip,
				SGLN = supplierChainViewModel.SGLN,
				CNPJNumber = supplierChainViewModel.CNPJNumber,
				LocationName = supplierChainViewModel.LocationName
			};
        }
    }
}