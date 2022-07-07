using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StellaguardProductAssociation.Models
{
    public class ProductAssociationModels
    {

        public MessageDisplay Message { get; set; }
        public string BarcodeData { get; set; }

        public string Messages { get; set; }

       // public List<ProductClass> _Lotlist { get; set; }

        [Display(Name = "UPC + Serial Codes")]
        public string UPCSerialNumber { get; set; }

        [Display(Name = "Work Order No.")]
        public string BatchNumber { get; set; }

        public string TimeStamp { get; set; }


        public List<ProductClass> ProductList { get; set; }
       // public List<ScanTableData> TableList { get; set; }

       // public string JsonLotList { get; set; }

        public List<ScannedBarcode> ScannedBarcodeList { get; set; }

        public ProductAssociationFilter FilterParameters { get; set; }


    }
    public class ProductUpcClass
    {
        [JsonProperty("SerialNumber")]
        public string SerialNumber { get; set; }
        [JsonProperty("UPC")]
        public string UPC { get; set; }
        [JsonProperty("ProductName")]
        public string ProductName { get; set; }
        [JsonProperty("Delete")]
        public string Delete { get; set; }

    }

    public class ProductAssociationFilter
    {
        public string SerialNumber { get; set; }

        public string Upc { get; set; }
        public Nullable <int> Id { get; set; }
        public string WorkOrder { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

    }
    public class ScannedBarcode
    {
       // public int TempScannedBarcodeDataId { get; set; }
        public string BarcodeData { get; set; }
       // public string UserName { get; set; }
        public int ScannedBatchId { get; set; }
        public int TotalBarcode { get; set; }
       // public DateTime CreatedDate { get; set; }

    }
    public class ScanTableData
    {

        public string SerialNumber { get; set; }

        public string Upc { get; set; }
        // public DateTime CreatedDate { get; set; }

    }
    public class UserDetails
    {

        public Nullable <int> Id { get; set; }

        public string UserName { get; set; }
    }
    public class ProductClass
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUpc { get; set; }
        public int ClientId { get; set; }
    }

    //public class MessageDisplay
    //{
    //    public bool _messageVisible = false;
    //    public bool _isGoodMessage = false;
    //    public string _message = "";

    //    public bool MessageVisible
    //    {
    //        get { return _messageVisible; }
    //        set { _messageVisible = value; }
    //    }

    //    public bool IsGoodMessage
    //    {
    //        get { return _isGoodMessage; }
    //        set { _isGoodMessage = value; }
    //    }

    //    public string Message
    //    {
    //        get { return _message; }
    //        set { _message = value; }
    //    }
    //    [System.Web.Script.Serialization.ScriptIgnore]
    //    public string MessageJSON
    //    {
    //        get
    //        {
    //            //Dictionary<object, object> dict = new Dictionary<object, object>();
    //            //dict.Add("MessageVisible",_messageVisible);
    //            //dict.Add("IsGoodMessage", _isGoodMessage);
    //            //dict.Add("Message", _message);

    //            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
    //            string jsonString = serializer.Serialize(this);

    //            return jsonString;
    //        }
    //    }
    //}

}