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
    //[RoutePrefix("ProductAssociation")]
    public class ProductAssociationController : Controller
    {

        private DBHelper helper = null;
        // GET: ProductAssociation
        [HttpGet, ValidateInput(false)]
        public ActionResult Index()
        {
            ProductAssociationModels objProductView = new ProductAssociationModels();
            if (Session["Username"] != null)
            {


                
                //objProductView._Lotlist = new List<Models.ProductClass>();
                //if (objProductView.Message != null)
                //{
                //   // objProductView.Message = objProductView.Message;
                //}
                //string messageLocal = message;
                bool messageVisible = false;
                objProductView.BatchNumber = "Wo-" + DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz");
                objProductView.TimeStamp = DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz");
                messageVisible = true;
                int userid = Convert.ToInt32(Session["UserId"]);
                objProductView = GetScannedBarcodeListByUser(userid);
                objProductView.ProductList = new List<Models.ProductClass>();
                objProductView.ProductList = this.GetProductList();
                // objProductView._Lotlist = this.GetProductList();

                objProductView.Message= new MessageDisplay { MessageVisible = false, IsGoodMessage = false, Message = "test" };
                return View(objProductView);
               // return View(new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = false } });
            }
            else
            {
                //objProductView.Message = new MessageDisplay { MessageVisible = false, IsGoodMessage = false, Message = "test" };
                //return View(objProductView);
                return RedirectToAction("Index", "Home");
            }
        }
        //POST: ProductAssociation
        [HttpPost, ValidateInput(false)]
        [Route("Index/{productAssociationModel}")]
        public ActionResult Index(ProductAssociationModels productAssociationModel, string submitButton)
        {
            ProductAssociationModels objProductView = new ProductAssociationModels();
           // string myStringFromTheInput = TimeStamp.Value;

            // productAssociationModel.BatchNumber+=

            //  //return View();
            if (Request.Form["Save"] != null)
            {
                // productAssociationModel.BarcodeData = productAssociationModel.BarcodeData.Replace("\r\n", string.Empty);
                return (Save(productAssociationModel));

            }
            else if (Request.Form["Submit"] != null)
            {
                // code for function 2
                return (Submit(productAssociationModel));
            }

            else if (Request.Form["Reset"] != null)
            {
                // code for function 2
                return RedirectToAction("Index");
            }



            return View(productAssociationModel);
        }


        private ActionResult Submit(ProductAssociationModels productAssociationModel1)
        {
            bool isGoodMessage;
            ProductAssociationModels objProductView = new ProductAssociationModels();
            if (Session["Username"] != null)
            {


                string result1 = Regex.Replace(productAssociationModel1.BatchNumber, @"_", "");
                productAssociationModel1.BatchNumber = result1;

                if (productAssociationModel1.ScannedBarcodeList == null && productAssociationModel1.BarcodeData == null)

                {
                    isGoodMessage = true;
                    objProductView.Message = new MessageDisplay { IsGoodMessage = isGoodMessage, Message = "No SerialNumbers to Associate.", MessageVisible = true };
                    //objProductView.Messages = "<script language='javascript' type='text/javascript'>alert  ('No Values to save.');</script>";
                    return View(objProductView);
                }

                string username = Session["Username"].ToString();
                string result = string.Empty;
                SqlParameter[] param = null;
                // string message;
                param = new SqlParameter[5];
                param[0] = new SqlParameter("BarcodeList", productAssociationModel1.BarcodeData);
                param[1] = new SqlParameter("UserName", username);
                param[2] = new SqlParameter("WorkOrder", productAssociationModel1.BatchNumber);

                param[3] = new SqlParameter("Message", SqlDbType.NVarChar, 1000);
                param[3].Direction = ParameterDirection.Output;

                param[4] = new SqlParameter("MessageType", SqlDbType.Bit);
                param[4].Direction = ParameterDirection.Output;
                helper = new DBHelper(mustCloseConnection: false);
                DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "ProductAssociationSerialNumber_New", param);


                //isGoodMessage = true;
                //return View(new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = param[3].Value.ToString() } });
                if (dsResult != null)
                {
                    isGoodMessage = true;
                    objProductView = new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = param[3].Value.ToString() } };
                    return View(objProductView);

                }
                else
                {

                    isGoodMessage = true;
                    objProductView = new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = "Something Went Wrong." } };
                    return View(objProductView);
                }


            }
            else

            {
                return RedirectToAction("Index", "Home");
            }
            // process the cancellation request here.
           // return View(objProductView);

        }

        private ActionResult Save(ProductAssociationModels productAssociationModel2)
        {
            bool isGoodMessage;
            ProductAssociationModels objProductView = new ProductAssociationModels();
            if (Session["Username"] != null)
            {

                string username = Session["Username"].ToString();
                string msg = "";

                var result = string.Empty;
                SqlParameter[] param = null;

                param = new SqlParameter[2];
                param[0] = new SqlParameter("BarcodeDataList", productAssociationModel2.BarcodeData);
                param[1] = new SqlParameter("UserName", username);
                // perform the actual send operation here.


                helper = new DBHelper(mustCloseConnection: false);
                DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "AddTempScannedBarcodeData", param);
                if (dsResult != null)
                {
                    isGoodMessage = true;
                    result = dsResult.Tables[0].Rows[0]["Message"].ToString();
                    objProductView = new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = result.ToString() } };
                    return View(objProductView);

                }
                else
                {

                    isGoodMessage = true;
                    objProductView = new ProductAssociationModels { Message = new MessageDisplay { MessageVisible = true, IsGoodMessage = isGoodMessage, Message = "Something Went Wrong." } };
                    return View(objProductView);
                }

            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

             
        }
        // GET: ProductAssociation

        public ActionResult Login()
        {
            // return View();
            //return View("Index");
            if (Session["Username"] != null)
            {

                return View(new MessageDisplay { MessageVisible = false });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ProductAssociationLogin objUser)
        {

            if (ModelState.IsValid)
            {
                var result = string.Empty;
                SqlParameter[] param = null;
                try
                {
                    param = new SqlParameter[2];
                    param[0] = new SqlParameter("Username", objUser.Username);
                    param[1] = new SqlParameter("Password", objUser.Password);

                    helper = new DBHelper(mustCloseConnection: false);
                    DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "ProductAssociationLogin", param);
                    if (dsResult != null && dsResult.Tables[0].Rows.Count > 0)
                    {
                        Session["Username"] = dsResult.Tables[0].Rows[0]["UserName"].ToString();
                        Session["UserId"] = dsResult.Tables[0].Rows[0]["id"].ToString();
                        result = dsResult.Tables[0].Rows[0]["Message"].ToString();
                    }
                    if (result == "Login Success")
                    {
                        return RedirectToAction("Index", "ProductAssociation");
                    }
                    ModelState.AddModelError("Result", "Login Failed");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();

        }

        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 
        /// </summary>
        [NonAction]
        public List<Models.ProductClass> GetProductList()
        {
            SqlParameter[] param = null;
            List<Models.ProductClass> LotNumberList = new List<Models.ProductClass>();

            helper = new DBHelper(mustCloseConnection: false);
            DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetProductUPCDetails", param);
            List<ProductClass> listName = dsResult.Tables[0].AsEnumerable().Select(m => new ProductClass()
            {
                ProductId = m.Field<int>("ProductId"),
                ProductName = m.Field<string>("ProductName"),
                ProductUpc = m.Field<string>("ProductUPC"),
            }).ToList();


            return listName;
        }

        [NonAction]
        public ProductAssociationModels GetScannedBarcodeListByUser(int userid)
        {
            SqlParameter[] param = null;
            ProductAssociationModels productListViewModel = new ProductAssociationModels();
            helper = new DBHelper(mustCloseConnection: false);
            param = new SqlParameter[1];
            param[0] = new SqlParameter("UserId", userid);
            //param[1] = new SqlParameter("Password", userid);

            DataSet dsResult = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetTempScannedBarcodeDetailsByUserId", param[0]);
            productListViewModel.ScannedBarcodeList = dsResult.Tables[0].AsEnumerable().Select(m => new ScannedBarcode()
            {
                //TempScannedBarcodeDataId = m.Field<int>("TempScannedBarcodeDataId"),
                //BarcodeData = m.Field<string>("BarcodeData"),
                BarcodeData = m.Field<string>("BarcodeData"),
                ScannedBatchId = m.Field<int>("ScannedBatchId"),
                // TotalBarcode = m.Field<int>("TotalBarcode"),
            }).ToList();

            return productListViewModel;
        }
    }
}
