using FCChinaArchitectureDemo.UI.Areas.Serialization.Models;
using FCChinaArchitectureDemo.UI.Models;
using FCChinaArchitectureDemo.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCChinaArchitectureDemo.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public SetDispositionDTO GetSetDispositionDTO(DispositionViewModel dispositionData)
        {
            string serialNumbers = ConvertToCSV(dispositionData.SerialNumbers);
            byte dispositionId = dispositionData.DispositionId;
            byte reasonId = dispositionData.ReasonId;
            string comments = dispositionData.Comments;
            bool areChildrenAffected = dispositionData.AreChildrenAffected;
            bool areChildrenSerialNumbers = dispositionData.AreChildrenSerialNumbers;

            byte LocationId = 0;
            try
            {
                LocationId = this.GetLocationId();
            }
            catch (Exception Ex)
            {
                throw new Exception("Current location is invalid");
            }
            short UserId = 0;

            return new SetDispositionDTO { SerialNumbers = serialNumbers, AreChildrenSerialNumbers = areChildrenSerialNumbers, DispositionId = dispositionId, ReasonId = reasonId, Comments = comments, AreChildrenAffected = areChildrenAffected, LocationId = LocationId, UserId = UserId };
        }
    }
}