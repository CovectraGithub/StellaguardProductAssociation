using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.DTO.DTOEntities;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public SerializationServiceReference.AddCompanyPrefixSetupDTO GetAddCompanyPrefixDto(AddCompanyPrefixSetupModel companyPrefixViewModel)
        {
            string companyDesc = string.Empty;
            string companyPrefix = string.Empty;
            short clientPrefixId = 0;
            string companyName = string.Empty;
            byte noOfDigits = 0;

            if (companyPrefixViewModel != null)
            {
                companyDesc = companyPrefixViewModel.CompanyDesc;
                companyPrefix = companyPrefixViewModel.CompanyPrefix;
                clientPrefixId = companyPrefixViewModel.CompanyPrefixId;
                companyName = companyPrefixViewModel.CompanyName;
                noOfDigits = companyPrefixViewModel.NoOfDigits;
            }
            return new SerializationServiceReference.AddCompanyPrefixSetupDTO
            {
                CompanyDesc = companyDesc,
                CompanyPrefix = companyPrefix,
                CompanyPrefixId = clientPrefixId,
                NoOfDigits = noOfDigits,
                CompanyName = companyName
            };
        }

        public SerializationServiceReference.EditCompanyPrefixSetupDTO GetEditCompanyPrefixDto(EditCompanyPrefixSetupModel companyPrefixViewModel)
        {

            string companyDesc = string.Empty;
            string companyPrefix = string.Empty;
            short clientPrefixId = 0;
            string companyName = string.Empty;
            byte noOfDigits = 0;

            if (companyPrefixViewModel != null)
            {
                companyDesc = companyPrefixViewModel.CompanyDesc;
                companyPrefix = companyPrefixViewModel.CompanyPrefix;
                clientPrefixId = companyPrefixViewModel.CompanyPrefixId;
                companyName = companyPrefixViewModel.CompanyName;
                noOfDigits = companyPrefixViewModel.NoOfDigits;
            }
            return new SerializationServiceReference.EditCompanyPrefixSetupDTO
            {
                CompanyDesc = companyDesc,
                CompanyPrefix = companyPrefix,
                CompanyPrefixId = clientPrefixId,
                NoOfDigits = noOfDigits,
                CompanyName = companyName
            };
        }
    }
}