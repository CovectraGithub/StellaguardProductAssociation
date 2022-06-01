using FCChinaArchitectureDemo.UI.Areas.Serialization.Models;
using FCChinaArchitectureDemo.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FCChinaArchitectureDemo.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public RecallLotDTO GetRecallLotDTO(RecallLotViewModel recallLotData)
        {
            string UserLotNumber = recallLotData.UserLotNumber;
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

            return new RecallLotDTO { UserLotNumber = UserLotNumber, LocationId = LocationId, UserId = UserId };
        }

        public RecallLotDTO GetRecallLotDTO(string UserLotNumber)
        {
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

            return new RecallLotDTO { UserLotNumber = UserLotNumber, LocationId = LocationId, UserId = UserId };
        }
    }
}