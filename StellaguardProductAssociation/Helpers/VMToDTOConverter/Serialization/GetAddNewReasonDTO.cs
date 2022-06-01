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
        public AddNewReasonDTO GetAddNewReasonDTO(DispositionReasonListViewModel reasonData)
        {
            byte StatusId = reasonData.StatusId;
            string ReasonDescription = reasonData.NewReason;
            return new AddNewReasonDTO { StatusId = StatusId, ReasonDescription = ReasonDescription };
        }
    }
}