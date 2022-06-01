using FCChinaArchitectureDemo.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCChinaArchitectureDemo.UI.Helpers
{
    public class DispositionHelper
    {
        public static List<DispositionReason> GetReasonList(byte? statusId)
        {
            DispositionReasonListDTO dispositionReasonListDTO;
            try
            {
                using (SerializationServiceClient service = new SerializationServiceClient())
                {
                    dispositionReasonListDTO = service.GetStatusBasedReasonList(statusId);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            List<DispositionReason> reasonList = dispositionReasonListDTO.DispositionReasonList.ToList();

            return reasonList;
        }
    }
}