using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StellaguardProductAssociation.Models
{
    public class SerialNumberHistoryModelView
    {
        [Display(Name = "SerialNumber")]
        public string SerialNumber { get; set; }
        [Display(Name = "ProductName")]
        public string ProductName { get; set; }
        public List<SerialNumberStatus> SerialNumberStatusList { get; set; }

    }

    public class SerialNumberStatus
    {
        public int StatusId { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string Note { get; set; }
    }
}