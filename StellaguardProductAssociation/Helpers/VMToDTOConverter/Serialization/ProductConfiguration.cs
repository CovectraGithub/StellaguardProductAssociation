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
        public AddPackageHierarchyDTO GetAddPackageHierarchyDTO(AddPackageHierarchyViewModel addPackageHierarchyViewModel)
        {
            AddPackageHierarchyDTO addPackageHierarchyDTO;

            short productId = addPackageHierarchyViewModel.ProductId;
            byte packageTypeId = addPackageHierarchyViewModel.PackageTypeId;
            byte maxChildrenCount = addPackageHierarchyViewModel.MaxChildrenCount;
           // decimal reserveCount = addPackageHierarchyViewModel.ReserveCount;
            byte hierarchyTypeId = addPackageHierarchyViewModel.HierarchyTypeId;
            // decimal startNumber = addPackageConfigurationViewModel.StartNumber;
            //decimal endNumber = addPackageConfigurationViewModel.EndNumber;
            //byte algorithmId = addPackageHierarchyViewModel.AlgorithmId;
            //string SGTINPrefix = addPackageConfigurationViewModel.SGTINPrefix;
            bool isBaseUnit = addPackageHierarchyViewModel.IsBaseUnit;
            bool isPartialPackingAllowed = addPackageHierarchyViewModel.IsPartialPackingAllowed;
            byte languageId = SessionHelper.GetLanguageId();

            addPackageHierarchyDTO = new AddPackageHierarchyDTO { ProductId = productId, PackageTypeId = packageTypeId, MaxChildrenCount = maxChildrenCount, HierarchyTypeId = hierarchyTypeId,  IsBaseUnit = isBaseUnit ,IsPartialPackingAllowed=isPartialPackingAllowed,LanguageId=languageId};

            return addPackageHierarchyDTO;

        }
       
    }
}