using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StellaguardProductAssociation.Models
{
    public class ShippingViewModel
    {

        [Display(Name = "Serial Codes")]
        public string SerialCodes { get; set; }

        [Display(Name = "Shipment Date")]
        public DateTime ShipmentDateTime { get; set; }
        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
        public List<TimeZoneClass> timeZoneList { get; set; }
    }

    public class TimeZoneClass
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public string StandardName { get; set; }
    }
}