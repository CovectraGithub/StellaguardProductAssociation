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
        [HttpGet]
        public ActionResult Index(string keyword)
        {
            ProductAssociationHistoryModels ListSupplierChainModel = new ProductAssociationHistoryModels();
            ListSupplierChainModel.WorkOrderList = GetWorkOrderList(keyword);
            return View(ListSupplierChainModel);
        }



        [NonAction]
        public List<WorkOrderDetails> GetWorkOrderList(string keyword)
        {
            // List<SupplierChain> SupplierList = new List<SupplierChain>();
            try
            {

                List<ScannedBarcodeDetailClass> ScannedBarcodeDetailList;
                ScannedBarcodeDetailList = GetAllProducts();

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

    }
}