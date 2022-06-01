using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AuthentiTrack.UI.SerializationServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    //public class GetAddDSCSAJobDTO
    //{
    //}
    public partial class VMToDTOConverter
    {
        public AddDSCSAJobDTO GetAddDSCSAJobDTO(AuthentiTrack.UI.Areas.Reports.Models.DSCSAJobModel dSCSAJobModel)
        {
            long shipmentDetailID = 0;
            string downloadURL = string.Empty;
            string type = string.Empty;
            string status = string.Empty;
            int userId = 0;
            string fileName = string.Empty;
            if (dSCSAJobModel != null)
            {
                shipmentDetailID = dSCSAJobModel.ShipmentDetailID;
                downloadURL = dSCSAJobModel.DownloadURL;
                type = dSCSAJobModel.Type;
                status = dSCSAJobModel.Status;
                userId = dSCSAJobModel.UserId;
                fileName = dSCSAJobModel.FileName;
            }

            byte languageId = AuthentiTrack.UI.Helpers.SessionHelper.GetLanguageId();
            return new AddDSCSAJobDTO
            {
                ShipmentDetailID = shipmentDetailID,
                DownloadURL = downloadURL,
                Type = type,
                Status = status,
                LanguageId = languageId,
                UserId = userId,
                FileName = fileName
            };
        }
    }
}