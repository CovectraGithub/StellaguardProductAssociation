using AuthentiTrack.UI.Areas.UserManager.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.Models;
using AuthentiTrack.UI.UserManagerServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddClientDTO GetAddClientDto(AddClientViewModel clientViewModel)
        {
            string clientName = string.Empty;
            string companyPrefix = string.Empty;
            string clientCode = string.Empty;

            if (clientViewModel != null)
            {
                clientName = clientViewModel.ClientName;
                companyPrefix = clientViewModel.CompanyPrefix;
                clientCode = clientViewModel.ClientCode;
            }
            
            byte languageId = SessionHelper.GetLanguageId();
            return new AddClientDTO
            {
                ClientName = clientName,
                ComanyPrefix = companyPrefix,
                LanguageId = languageId,
                ClientCode = clientCode

            };

        }

        public EditClientDTO GetEditClientDTO(EditClientViewModel clientViewModel)
        {
            byte clientId = clientViewModel.ClintId;
            string clientName = clientViewModel.ClientName;
            string companyPrefix = clientViewModel.CompanyPrefix;
            string clientCode = clientViewModel.ClientCode;

            byte languageId = SessionHelper.GetLanguageId();

            return new EditClientDTO
            {
                ClientId = clientId,
                ClientName = clientName,
                ClientCode = clientCode,
                CompanyPrefix = companyPrefix,
                LanguageId = languageId
            };
        }
    }
}