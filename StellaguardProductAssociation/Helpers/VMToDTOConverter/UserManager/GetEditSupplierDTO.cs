using AuthentiTrack.UI.UserManagerServiceReference;
using AuthentiTrack.UI.Areas.UserManager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public EditSupplierChainDTO GetEditSupplierDTO(EditSupplierViewModel supplierModel)
        {
            byte SupplierChainId = supplierModel.SupplierId;
            byte SupplierChainTypeId = supplierModel.SupplierTypeId;
            string SupplierChainName = supplierModel.SupplierName;
            byte languageId = SessionHelper.GetLanguageId();
			string CnpjNumber = supplierModel.CNPJNumber;
            return new EditSupplierChainDTO { SupplierChainId = SupplierChainId, SupplierChainTypeId = SupplierChainTypeId, 
				SupplierChainName = SupplierChainName,LanguageId=languageId,CNPJNumber=CnpjNumber }; 
        }
    }
}