using StellaguardProductAssociation.DAL;
using StellaguardProductAssociation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StellaguardProductAssociation.Controllers
{
    public class HomeController : Controller
    {
        private DBHelper helper = null;

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Index(ProductAssociationLogin objUser)
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
                        result = dsResult.Tables[0].Rows[0]["Message"].ToString();
                    }
                    if (result == "Login Success")
                    {
                        if (!string.IsNullOrEmpty(dsResult.Tables[0].Rows[0]["Username"].ToString()))
                            Session["Username"] = dsResult.Tables[0].Rows[0]["Username"].ToString();
                        if (!string.IsNullOrEmpty(dsResult.Tables[0].Rows[0]["id"].ToString()))
                            Session["UserId"] = dsResult.Tables[0].Rows[0]["id"].ToString();
                        if (!string.IsNullOrEmpty(dsResult.Tables[0].Rows[0]["RoleName"].ToString()))
                            Session["RoleName"] = dsResult.Tables[0].Rows[0]["RoleName"].ToString();
                        return RedirectToAction("Index", "ProductAssociation");
                    }
                    ModelState.AddModelError("Result", result);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session["Username"] = null;
            Session["UserId"] = null;
            Session["RoleName"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}