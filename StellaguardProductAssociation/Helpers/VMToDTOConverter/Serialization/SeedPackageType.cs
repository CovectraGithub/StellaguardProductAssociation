

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
        public AddPackageTypeDTO GetAddPackageType(AddPackageTypeViewModel addPackageTypeViewModel)
        {
            string PackageType = string.Empty;
            string PackagingLevel = string.Empty;
            byte? DefaultSSCCExtensionDigit = addPackageTypeViewModel.DefaultSSCCExtensionDigit;


            if (addPackageTypeViewModel != null)
            {
                PackageType = addPackageTypeViewModel.PackageType;
                PackagingLevel = addPackageTypeViewModel.PackagingLevel;
                DefaultSSCCExtensionDigit = addPackageTypeViewModel.DefaultSSCCExtensionDigit;
                

            }
            return new AddPackageTypeDTO
            {
                PackageType = PackageType,
                PackagingLevel = PackagingLevel,
                
            };
        }
        public EditPackageTypeDTO GetEditPackageType(EditPackageTypeViewModel editPackageTypeViewModel)
        {
            int PackageTypeId = editPackageTypeViewModel.PackageTypeId;
            string PackageType = editPackageTypeViewModel.PackageType;
            byte? DefaultSSCCExtensionDigit = editPackageTypeViewModel.DefaultSSCCExtensionDigit;
            string PackagingLevel = editPackageTypeViewModel.PackagingLevel;
            //byte? IsRecursive = editPackageTypeViewModel.IsRecursive;


            if (editPackageTypeViewModel != null)
            {
                PackageTypeId = editPackageTypeViewModel.PackageTypeId;

                PackageType = editPackageTypeViewModel.PackageType;
                DefaultSSCCExtensionDigit= editPackageTypeViewModel.DefaultSSCCExtensionDigit;
                PackagingLevel = editPackageTypeViewModel.PackagingLevel;
                //IsRecursive = editPackageTypeViewModel.IsRecursive;
            }
            return new EditPackageTypeDTO
            {    PackageTypeId = PackageTypeId,
                PackageType = PackageType,
                DefaultSSCCExtensionDigit = DefaultSSCCExtensionDigit,
                PackagingLevel = PackagingLevel
                //IsRecursive = IsRecursive

            };
        }
    }
}