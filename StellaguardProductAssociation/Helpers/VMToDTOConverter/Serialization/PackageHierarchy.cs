using AuthentiTrack.UI.SerializationServiceReference;

using AuthentiTrack.UI.Areas.Serialization.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddProductPackageHierarchyDTO GetAddProductPackageHierarchyDTO(string jsonHierarchyList)
        {
            ProductPackageHierarchy[] hierarchyList = new JavaScriptSerializer().Deserialize<ProductPackageHierarchy[]>(jsonHierarchyList);

            return new AddProductPackageHierarchyDTO
            {
                ProductId = SessionHelper.GetCurrentProductId(),
                UserId = SessionHelper.GetCurrentUserId(),
                LanguageId=SessionHelper.GetLanguageId(),
                PackageHierarchyList = hierarchyList                
            };

        }
        public AddProductPackageHierarchyDTO GetAddProductPackageHierarchyDTO(string jsonHierarchyList,short productId)
        {
            ProductPackageHierarchy[] hierarchyList = new JavaScriptSerializer().Deserialize<ProductPackageHierarchy[]>(jsonHierarchyList);

            return new AddProductPackageHierarchyDTO
            {
                ProductId = productId,
                UserId = SessionHelper.GetCurrentUserId(),
                LanguageId=SessionHelper.GetLanguageId(),
                PackageHierarchyList = hierarchyList
            };

        }
       
    }
}