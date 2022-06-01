using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.SerializationServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public GetPackageDetailsListOfBatchDTO CreateGetPackageDetailsListOfBatchDTO(string userBatchNumber, bool? isQuarantined, int offset, int numberOfRecords, string sortBy, string sortDir)
        {
            byte languageId = SessionHelper.GetLanguageId();
            return new GetPackageDetailsListOfBatchDTO { UserBatchNumber = userBatchNumber, IsQuarantined = isQuarantined, Offset = offset, RowCount = numberOfRecords, LanguageId = languageId, SortBy = sortBy, SortDir = sortDir };
        }
    }
}