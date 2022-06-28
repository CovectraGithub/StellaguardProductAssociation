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
    public class ShippingController : Controller
    {
        // GET: Shipping
        private DBHelper helper = null;
        public ActionResult Index()
        {
            if (Session["Username"] != null)
            {
                ShippingViewModel objShippingView = new ShippingViewModel();

                AssignTimeZoneList(objShippingView);

                if (objShippingView.Message != null)
                {
                    // objShippingView.Message = objShippingView.Message;
                    objShippingView.Message = new MessageDisplay { MessageVisible = false, IsGoodMessage = false, Message = "" };
                    return View(objShippingView);
                }

                // return View(objShippingView);
                objShippingView.Message = new MessageDisplay { MessageVisible = false, IsGoodMessage = false, Message = "test" };
                return View(objShippingView);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        [HttpPost, ValidateInput(false)]
        [Route("Index/{productAssociationModel}")]

        public ActionResult Index(ShippingViewModel shippingviewModel, string submitButton,string timezone1)
        {
            ShippingViewModel objProductView = new ShippingViewModel();

            if (Request.Form["Save"] != null)
            {
                // productAssociationModel.BarcodeData = productAssociationModel.BarcodeData.Replace("\r\n", string.Empty);
                return (Save(shippingviewModel, timezone1));

            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        private ActionResult Save(ShippingViewModel shippingviewmodel,string timezone1)
        {
            ShippingViewModel objshippingviewmodel = new ShippingViewModel();

            bool isGoodMessage;
            if (Session["Username"] != null)
            {

                // string serialcodes = GetSerialNumber(objshippingviewmodel.SerialCodes);
                string username = Session["Username"].ToString();
                string msg = "";
                string result = string.Empty;
                string SerialCodeList = GetSerialNumberList(shippingviewmodel.SerialCodes);

                if (string.IsNullOrEmpty(SerialCodeList))
                {
                    result = "Scanned Serial Code done not contain any Data!!!";
                }
                else
                {
                    ShippingDateCalculation(timezone1, shippingviewmodel);
                    SqlParameter[] param = null;
                    param = new SqlParameter[4];
                    param[0] = new SqlParameter("SerialCodeList", SerialCodeList);
                    param[1] = new SqlParameter("orderNo", shippingviewmodel.OrderNumber);
                    param[2] = new SqlParameter("UserName", username);
                    param[3] = new SqlParameter("ShippingDate", shippingviewmodel.ShipmentDateTime);

                    // perform the actual send operation here.


                    helper = new DBHelper(mustCloseConnection: false);
                    DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "AddShippingDetails", param);
                    if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                    {
                        result = dsResult.Tables[0].Rows[0]["Message"].ToString();
                    }
                    else
                    {
                        result = null;
                    }
                    // msg = dsResult.ToString();
                }
                objshippingviewmodel.Messages = result;
                AssignTimeZoneList(objshippingviewmodel);
                if (result != null || result != "")
                {
                    isGoodMessage = true;
                    return View(new ShippingViewModel { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = result.ToString() } });
                }

                if (result == null )
                {
                    isGoodMessage = true;
                    return View(new ShippingViewModel { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = "Something Went Wrong Scan again.." } });
                }

                return View(objshippingviewmodel);
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            // return View(objProductView);
        }

        public string GetSerialNumberList(string scannedBarCodeDetail)
        {
            string strSerialCodes = string.Empty;
            if (scannedBarCodeDetail !=null && scannedBarCodeDetail.Length > 0 && scannedBarCodeDetail.Contains(":"))
            {
                string[] CodeList = scannedBarCodeDetail.Split(':');
                foreach (string strTemp in CodeList)
                {
                    if (strTemp.Contains("8200https"))
                    {
                        var strCode = strTemp.Substring(0, strTemp.IndexOf("8200https"));
                        if (strCode.Contains('\n'))
                        {
                            int Index = strCode.IndexOf("\n21") + 3;
                            strCode = strCode.Substring(Index, (strCode.Length - Index));
                            if (strSerialCodes.Length > 0)
                                strSerialCodes = strSerialCodes + ',' + strCode;
                            else
                                strSerialCodes = strCode;
                        }
                        else
                        {
                            string strFirstCode = strCode.Remove(0, 2);
                            if (strSerialCodes.Length > 0)
                                strSerialCodes = strSerialCodes + ',' + strFirstCode;
                            else
                                strSerialCodes = strFirstCode;
                        }
                    }


                }

            }
            return strSerialCodes;

        }

        public void AssignTimeZoneList(ShippingViewModel objShippingView)
        {
            #region TO CHANGE THE LOCAL TIME ON THE SELECTED TIME ZONE
            var timeZones = TimeZoneInfo.GetSystemTimeZones();
            List<TimeZoneClass> items = new List<TimeZoneClass>();
            foreach (var timeZone in timeZones)
            {
                if (timeZone.SupportsDaylightSavingTime == true)
                {

                    var UTCTime = timeZone.GetUtcOffset(DateTime.Now);
                    string SubUTCTime = UTCTime.ToString();

                    if (SubUTCTime.StartsWith("0") || SubUTCTime.StartsWith("1"))
                    {
                        items.Add(new TimeZoneClass()
                        {
                            Value = timeZone.DaylightName.ToString(),
                            //  Value = timeZone.Id.ToString(),
                            Text = "(UTC+" + SubUTCTime.Substring(0, 5) + ") " + timeZone.DaylightName,
                            StandardName = timeZone.StandardName.ToString()
                        });
                    }
                    else
                    {
                        items.Add(new TimeZoneClass()
                        {
                            Value = timeZone.DaylightName.ToString(),
                            // Value = timeZone.Id.ToString(),
                            Text = "(UTC" + SubUTCTime.Substring(0, 6) + ") " + timeZone.DaylightName,
                            StandardName = timeZone.StandardName.ToString()
                        });
                    }
                }

                items.Add(new TimeZoneClass()
                {
                    Value = timeZone.StandardName.ToString(),
                    //Value = timeZone.Id.ToString(),
                    Text = timeZone.DisplayName,
                    StandardName = timeZone.StandardName.ToString()
                });
            }

            objShippingView.timeZoneList = new List<Models.TimeZoneClass>();
            objShippingView.timeZoneList = items;

            #endregion

        }

        public void ShippingDateCalculation(string timezone1, ShippingViewModel objShippingView)
        {
           
            var timeZones = TimeZoneInfo.GetSystemTimeZones();

            List<TimeZoneClass> items = new List<TimeZoneClass>();
            //if(timezoneList !=null && timezoneList.Count >0)
            //{
            //    timezone1 = timezoneList[0].Text;
            //}
            foreach (var timeZone in timeZones)
            {
                if (timeZone.SupportsDaylightSavingTime == true)
                {

                    var UTCTime = timeZone.GetUtcOffset(DateTime.Now);
                    string SubUTCTime = UTCTime.ToString();

                    if (SubUTCTime.StartsWith("0") || SubUTCTime.StartsWith("1"))
                    {
                        items.Add(new TimeZoneClass()
                        {
                            Value = timeZone.DaylightName.ToString(),
                            //  Value = timeZone.Id.ToString(),
                            Text = "(UTC+" + SubUTCTime.Substring(0, 5) + ") " + timeZone.DaylightName,
                            StandardName = timeZone.StandardName.ToString()
                        });
                    }
                    else
                    {
                        items.Add(new TimeZoneClass()
                        {
                            Value = timeZone.DaylightName.ToString(),
                            // Value = timeZone.Id.ToString(),
                            Text = "(UTC" + SubUTCTime.Substring(0, 6) + ") " + timeZone.DaylightName,
                            StandardName = timeZone.StandardName.ToString()
                        });
                    }
                }

                items.Add(new TimeZoneClass()
                {
                    Value = timeZone.StandardName.ToString(),
                    //Value = timeZone.Id.ToString(),
                    Text = timeZone.DisplayName,
                    StandardName = timeZone.StandardName.ToString()
                });
            }


            //TimeZoneInfo localZone = TimeZoneInfo.Local;
            var test = items.Find(x => x.Value == timezone1);

            TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById(test.StandardName.ToString());
            DateTime shipmentUtcDate = TimeZoneInfo.ConvertTimeToUtc(objShippingView.ShipmentDateTime, tz);
          
            // Check future date for Shipment Date 
            DateTime now = DateTime.UtcNow;
            var substractSeconds = now.ToString("M/dd/yyyy h:mm:00 tt");
            now = Convert.ToDateTime(substractSeconds);

            //if (shipmentUtcDate > now)
            //{
                objShippingView.ShipmentDateTime = shipmentUtcDate;
          //  }

        }
    }

}