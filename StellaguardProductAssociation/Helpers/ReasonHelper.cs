using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.CloudServiceReference;

namespace AuthentiTrack.UI.Helpers
{
    public class ReasonHelper
    {
        public static Dictionary<short, string> GetReasonList(string statusDesc)
        {
            ReasonListDTO reasonListDTO;
            byte languageId = SessionHelper.GetLanguageId();
            try
            {
                using (CloudServiceClient service = new CloudServiceClient())
                {
                    reasonListDTO = service.GetReasonList(statusDesc,languageId);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            Dictionary<short, string> reasonList = reasonListDTO.ReasonList;

            return reasonList;
        }
    }
}