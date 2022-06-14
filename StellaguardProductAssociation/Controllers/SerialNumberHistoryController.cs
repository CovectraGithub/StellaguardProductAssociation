using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;
using StellaguardProductAssociation.DAL;
using StellaguardProductAssociation.Models;

namespace StellaguardProductAssociation.Controllers
{
    public class SerialNumberHistoryController : Controller
    {
        private DBHelper helper = null;
        SerialNumberHistoryModelView obj = null;
        // GET: SerialNumberHistory
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [Route("{serialNumber}")]
        //  [AuthorizeUser(module = AuthentiTrack.Utility.Modules.TRACK_HISTORY_MODULE, actionType = AuthentiTrack.Utility.Enumeration.ModuleActions.Read)]
        public ActionResult Index(string serialNumber)
        {
            if (!string.IsNullOrEmpty(serialNumber))
            {
               // obj.SerialNumber = serialNumber;
                obj = GetSerailNumberHistory(serialNumber);
                if ((obj != null) && (obj.SerialNumberStatusList != null) && (obj.SerialNumberStatusList.Any()))
                    return View(obj);
                else
                {
                    // string isEventHistory = AuthentiTrack.I18NResources.Common.No_Record_found;
                    return RedirectToAction("Index", "ProductAssociationHistory");
                }
            }
            else
            {
                return GetForm();
            }
        }

        [NonAction]
        public ActionResult GetForm()
        {
            return View();
        }

        [NonAction]
        public SerialNumberHistoryModelView GetSerailNumberHistory(string serialnumber)
        {
            SqlParameter[] param = null;
            SerialNumberHistoryModelView productListViewModel = new SerialNumberHistoryModelView();
            helper = new DBHelper(mustCloseConnection: false);
            param = new SqlParameter[1];
            param[0] = new SqlParameter("SerialNumber", serialnumber);
            //param[1] = new SqlParameter("Password", userid);
            productListViewModel.SerialNumber = serialnumber.ToString();
            DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetSerialNumberHistoryBySerialNumber", param[0]);
            productListViewModel.SerialNumberStatusList = dsResult.Tables[0].AsEnumerable().Select(m => new SerialNumberStatus()
            {
                //TempScannedBarcodeDataId = m.Field<int>("TempScannedBarcodeDataId"),
                CreatedBy = m.Field<string>("CreatedBy"),
                Status = m.Field<string>("Status"),
                CreatedDate = m.Field<DateTime>("CreatedDate"),
                Note=  m.Field<string>("Note"),
               // ScannedBatchId = m.Field<int>("ScannedBatchId"),
                // TotalBarcode = m.Field<int>("TotalBarcode"),
            }).ToList();
          
            return productListViewModel;
        }
    }
}