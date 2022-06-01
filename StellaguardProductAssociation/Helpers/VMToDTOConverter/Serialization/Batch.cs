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
        public GetBatchListFilterCriteriaDTO GetGetBatchListFilterCriteriaDTO(FilterCriteria filterCriteria)
        {
			if (filterCriteria.MFGDateTo != null)
			{
				filterCriteria.MFGDateTo = filterCriteria.MFGDateTo.Value.AddHours(23);
				filterCriteria.MFGDateTo = filterCriteria.MFGDateTo.Value.AddMinutes(59);
				filterCriteria.MFGDateTo = filterCriteria.MFGDateTo.Value.AddSeconds(59);
			}
            byte? BatchStatusID;
            if (filterCriteria.BatchStatusID == 0)
            { BatchStatusID = null; }
            else
            { BatchStatusID = filterCriteria.BatchStatusID; }

            return new GetBatchListFilterCriteriaDTO
            {
                UserBatchNumber = filterCriteria.UserBatchNumber,
                ProductName = filterCriteria.ProductName,
                MFGDateFrom = filterCriteria.MFGDateFrom,
                MFGDateTo = filterCriteria.MFGDateTo,
                ExpiryDateFrom = filterCriteria.ExpiryDateFrom,
                ExpiryDateTo = filterCriteria.ExpiryDateTo,
                IsRecalled = filterCriteria.IsRecalled,
                BatchStatusId = Convert.ToByte(BatchStatusID)
            };
        }
    }
}