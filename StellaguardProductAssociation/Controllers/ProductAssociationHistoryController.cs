using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
    [CustomAuthenticationFilter]
    public class ProductAssociationHistoryController : Controller
    {
        private DBHelper helper = null;
        // GET: ProductAssociation
        // GET: ProductAssociationHistory
        //[HttpGet]
        //public ActionResult Index(string keyword)
        //{
        //    ProductAssociationHistoryModels ListSupplierChainModel = new ProductAssociationHistoryModels();
        //   // ListSupplierChainModel.WorkOrderList = GetWorkOrderList(keyword);
        //    return View(ListSupplierChainModel);
        //}



        [NonAction]
        public List<WorkOrderDetails> GetWorkOrderList(int pageSize, int offset, ProductAssociationFilter workorderFilterDTO, string sortBy, string sortDir)
        {
            // List<SupplierChain> SupplierList = new List<SupplierChain>();
            try
            {

                List<ScannedBarcodeDetailClass> ScannedBarcodeDetailList;

                //if (workorderFilterDTO.Id == 0)
                //{ workorderFilterDTO = null; }
                ScannedBarcodeDetailList = GetAllProducts(workorderFilterDTO, offset, sortBy, sortDir);

                List<WorkOrderDetails> WorkOrderList = new List<WorkOrderDetails>();
                foreach (ScannedBarcodeDetailClass scc in ScannedBarcodeDetailList)
                {
                    WorkOrderDetails sc = WorkOrderList.Where(x => x.Id == scc.Id).FirstOrDefault();
                    if (sc == null || sc.Id == 0)
                    {


                        //dt.ToString("yyyy-MM-ddTHH':'mm':'sszzz");
                        sc = new WorkOrderDetails();
                        sc.TimeStamp = scc.CreatedDate;
                        sc.WorkOrder = scc.WorkOrderNumber;
                        sc.User = scc.UserName;
                        sc.ScannedBarcodeList = new List<ScannedBarcodeDetails>();
                        WorkOrderList.Add(sc);


                        //sc.ScannedBarcodeList = new List<ScannedBarcodeDetails>();
                        //bd.AssociationId = scc.Id;

                    }
                    if (scc.Id != null)
                    {
                        ScannedBarcodeDetails bd = new ScannedBarcodeDetails();
                        bd.Id = scc.Id;
                        bd.SerialNumber = scc.SerialNumber;
                        bd.UPC = scc.UPC;
                        bd.ProductName = scc.ProductName;
                        bd.AssociationId = scc.Id;
                        sc.ScannedBarcodeList.Add(bd);
                    }

                }


                return WorkOrderList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public static List<ScannedBarcodeDetailClass> PreocessData(DataSet data)
        //{
        //    List<ScannedBarcodeDetailClass> _AttendenceManualList = new List<ScannedBarcodeDetailClass>();

        //    for (int i = 0; i < data.Tables[0].Rows.Count; i++)
        //    {
        //        ScannedBarcodeDetailClass Student = new ScannedBarcodeDetailClass();
        //        Student.Id = data.Tables[0].Rows[i]["F2"].ToString();
        //        _AttendenceManualList.Add(Student);
        //    }

        //    return _AttendenceManualList;
        //}

        public List<ScannedBarcodeDetailClass> GetAllProducts()
        {
            // DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
            SqlParameter[] param = null;
            param = new SqlParameter[1];
            param[0] = new SqlParameter("UserId", 1);
            helper = new DBHelper(mustCloseConnection: false);
            DataSet dsinsert = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetProductAssociationList", param);

            return (from row in dsinsert.Tables[0].AsEnumerable()
                    select new ScannedBarcodeDetailClass
                    {

                        CreatedDate = row.Field<string>("CreatedDate"),
                        WorkOrderNumber = row.Field<string>("WorkOrderNumber"),
                        SerialNumber = row.Field<string>("SerialNumber"),
                        UPC = row.Field<string>("UPC"),
                        BarcodeData = row.Field<string>("BarcodeData"),
                        UserName = row.Field<string>("UserName"),
                    }).ToList();
        }

        public List<UserDetails> GetAllUsers()
        {
            // DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
            SqlParameter[] param = null;
            param = new SqlParameter[0];
            helper = new DBHelper(mustCloseConnection: false);
            DataSet dsinsert = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetUserList", param);

            return (from row in dsinsert.Tables[0].AsEnumerable()
                    select new UserDetails
                    {

                        Id = row.Field<int>("Id"),
                        UserName = row.Field<string>("UserName"),
                    }).ToList();
        }
        public List<ScannedBarcodeDetailClass> GetAllProducts(ProductAssociationFilter filterCriteriaDTO, int offset, string sortBy, string sortDir)
        {
            // DataSet dsinsert = GetDataSet(sqlQuery, "tblProducts");
            string username = Session["Username"].ToString();
            SqlParameter[] param = null;
            param = new SqlParameter[9];

            param[0] = new SqlParameter("Id", filterCriteriaDTO.Id);
            param[1] = new SqlParameter("UserName", username);
            param[2] = new SqlParameter("WorkOrderNumber", filterCriteriaDTO.WorkOrder);
            param[3] = new SqlParameter("SerialNumber", filterCriteriaDTO.SerialNumber);
            param[4] = new SqlParameter("UPC", filterCriteriaDTO.Upc);
            param[5] = new SqlParameter("Offset", offset);
            param[6] = new SqlParameter("TotalRows", SqlDbType.Int);
            param[6].Direction = ParameterDirection.Output;
            param[7] = new SqlParameter("SortBy", sortBy);
            param[8] = new SqlParameter("SortDir", sortDir);
           // param[7] = new SqlParameter("RowCount", rowCount);
            
            helper = new DBHelper(mustCloseConnection: false);
            DataSet dsinsert = helper.ExecuteDataSet(CommandType.StoredProcedure, "GetProductAssociationList_New", param);

            return (from row in dsinsert.Tables[0].AsEnumerable()
                    select new ScannedBarcodeDetailClass
                    {

                        CreatedDate = row.Field<string>("CreatedDate"),
                        WorkOrderNumber = row.Field<string>("WorkOrderNumber"),
                        SerialNumber = row.Field<string>("SerialNumber"),
                        UPC = row.Field<string>("UPC"),
                        BarcodeData = row.Field<string>("BarcodeData"),
                        UserName = row.Field<string>("UserName"),
                        ProductName = row.Field<string>("ProductName"),
                    }).ToList();
        }

        [HttpGet]
        public ActionResult IndexNew()
        {
            return RedirectToAction("Index", new { page = 1, Type = "Reset" });
        }

        [HttpGet]
        public ActionResult Index(int? page, string Type, ProductAssociationHistoryModels model, string sort, string sortDir)
        {
              ProductAssociationHistoryModels ListSupplierChainModel = new ProductAssociationHistoryModels();

            ListSupplierChainModel = new ProductAssociationHistoryModels { Message = new MessageDisplay { MessageVisible = false, IsGoodMessage = true, Message = String.Empty } };

            
            if (page == null && sort == null && sortDir == null)
            {
                TempData.Remove("Filter");
            }
            if (model.FilterParameters == null)
            {
                model.FilterParameters = (ProductAssociationFilter)TempData["Filter"];
                ListSupplierChainModel.FilterParameters = (ProductAssociationFilter)TempData["Filter"];
                TempData.Keep();
            }

            if (Type == "Reset")
            { TempData.Remove("Filter"); }

            int pageSize = 10;
            ViewBag.PageSize = pageSize;

            int offset = ((page ?? 1) - 1) * pageSize;
            string sortBy = sort;
            if (!string.IsNullOrEmpty(Type))
            {
                ListSupplierChainModel.FilterParameters = null;
                model.FilterParameters = new ProductAssociationFilter();
                ListSupplierChainModel.WorkOrderList = GetWorkOrderList(pageSize, offset, model.FilterParameters, sortBy, sortDir);

            }
            else
            {
                if (model.FilterParameters != null)
                {
                    ListSupplierChainModel.WorkOrderList = GetWorkOrderList(pageSize, offset, model.FilterParameters, sortBy, sortDir);
                    ListSupplierChainModel.FilterParameters = model.FilterParameters;
                }
                else
                {
                    ListSupplierChainModel.Users = GetAllUsers();
                    model.FilterParameters = new ProductAssociationFilter();
                    ListSupplierChainModel.WorkOrderList = GetWorkOrderList(pageSize, offset, model.FilterParameters, sortBy, sortDir);
                   


                }
            }
            return View(ListSupplierChainModel);
        }


        [HttpPost]
        public ActionResult Index(ProductAssociationHistoryModels model, int? page, string sort, string sortDir)
        {
            ProductAssociationHistoryModels productassociationListViewModel = new ProductAssociationHistoryModels { Message = new MessageDisplay { MessageVisible = false, IsGoodMessage = true, Message = String.Empty } };

            int pageSize = 10;
            ViewBag.PageSize = pageSize;

            int offset = ((page ?? 1) - 1) * pageSize;
            string sortBy = sort;
            //productListViewModel = GetProductListWithFilters(pageSize, offset, model.FilterParameters, sortBy, sortDir);
            productassociationListViewModel.WorkOrderList = GetWorkOrderList(pageSize, offset, model.FilterParameters, sortBy, sortDir);
            TempData["Filter"] = model.FilterParameters;
            TempData.Keep();
            // productassociationListViewModel.FilterParameters.UserName=

            // productassociationListViewModel.FilterParameters.UserName.Insert(0, new UserDetails() { Id = 0, UserName = "---Select EPCIS Trigger---" });
            //Obtain permissions
            /// ModulePermissionsModel permissions = GetModulePermissionsForCurrentUser(AuthentiTrack.Utility.Modules.PRODUCT_MODULE);

            //productListViewModel.Permissions = permissions;
            //productListViewModel.TotalRecords = productListViewModel.ProductList.Count;
            //productListViewModel.Message = new UI.Models.MessageDisplay();
            productassociationListViewModel.Users = GetAllUsers();
            return View(productassociationListViewModel);
        }

    }
}