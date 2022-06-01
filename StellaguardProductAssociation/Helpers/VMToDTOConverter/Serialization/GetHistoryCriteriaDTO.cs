using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.CloudServiceReference;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public GetHistoryDTO GetHistoryCriteriaDTO(HistoryViewModel historyData)
        {
            string cnpj = historyData.CNPJ;
            string hrCode = historyData.HumanReadableCode;
            string sscc = historyData.SSCC;
            byte? statusId = historyData.SelectedStatusId;
            DateTime? fromDate = historyData.FromDate;
            DateTime? toDate = historyData.ToDate;
            byte languageId = SessionHelper.GetLanguageId();
            int rowCount = historyData.PackageVolumeDetails.RowCount;
            int offset = historyData.PackageVolumeDetails.OffSet;

            return new GetHistoryDTO { CNPJ = cnpj, HRCode = hrCode, SSCC= sscc, StatusId = statusId, FromDate = fromDate, ToDate = toDate, RowCount = rowCount, Offset = offset, LanguageId = languageId };
        }
		public GetPackageHistoryDetailsDTO GetPackageHistoryDetailsDTO(HistoryViewModel historyCriteriaData)
		{
            return new GetPackageHistoryDetailsDTO
            {
                CNPJ = historyCriteriaData.CNPJ,
                SSCC = historyCriteriaData.SSCC,
                FromDate = historyCriteriaData.FromDate,
                ToDate = historyCriteriaData.ToDate,
                StatusId = historyCriteriaData.StatusId,
                ProductId = historyCriteriaData.ProductId,
                PackageTypeId = historyCriteriaData.PackageTypeId,
                LanguageId = SessionHelper.GetLanguageId(),
                SSCCORSerialCode=historyCriteriaData.SSCCORSerialCode
            };
		}
    }
}