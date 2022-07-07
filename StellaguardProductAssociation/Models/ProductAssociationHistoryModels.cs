using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StellaguardProductAssociation.Models
{
    public class ProductAssociationHistoryModels
    {
        public List<WorkOrderDetails> WorkOrderList { get; set; }

        public MessageDisplay Message { get; set; }

        // public ModulePermissions Permissions { get; set; }
        public ProductAssociationFilter FilterParameters { get; set; }

        public Nullable<int> Id { get; set; }
        public List<UserDetails> Users { get; set; }
        public int TotalRecords { get; set; }
    }



    public class WorkOrderDetails
    {
        public int WorkOrderId { get; set; }

        [Display(Name = "TimeStamp")]
        public string TimeStamp { get; set; }

        [Display(Name = "WorkOrder")]
        public string WorkOrder { get; set; }

        public string User { get; set; }
        //public string SupplierCNPJ { get; set; }
        //public short SupplierContactId { get; set; }

        public List<ScannedBarcodeDetails> ScannedBarcodeList { get; set; }


    }

    public class GetWorkOrderDetailsDTO
    {


        public int TotalRow { get; set; }

        public List<ScannedBarcodeDetailClass> ScannedBarcodeDetailList { get; set; }
    }

    public class ScannedBarcodeDetailClass
    {

        public int WorkOrderId { get; set; }

        public string CreatedDate { get; set; }

        public string UserName { get; set; }

        public string WorkOrderNumber { get; set; }

        public string BarcodeData { get; set; }

        public string SerialNumber { get; set; }


        public string UPC { get; set; }
        public string ProductName { get; set; }
    }

        public class ScannedBarcodeDetails
    {
        [Display(Name = "AssociationId")]
        public short AssociationId { get; set; }

        public int  WorkOrderId { get; set; }

     
        public string SerialNumber { get; set; }

        [Display(Name = "UPC")]
        public string UPC { get; set; }

        [Display(Name = "ProductName")]
        public string ProductName { get; set; }

        //[Display(Name = "Email_Display_Name")]
        //public string LocationName { get; set; }


    }
}