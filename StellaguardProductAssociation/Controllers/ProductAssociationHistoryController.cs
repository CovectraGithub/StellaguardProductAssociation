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
        //private DBHelper helper = null;
        [HttpGet]
        [CustomAuthorize("Admin","User")]
        public ActionResult Index(string keyword)
        {
           ProductAssociationHistoryModels ListSupplierChainModel = new ProductAssociationHistoryModels();
            ListSupplierChainModel.SupplierChainList = GetSupplierChainList(keyword);
            return View(ListSupplierChainModel);
        }



        [NonAction]
        public List<SupplierChain> GetSupplierChainList(string keyword)
        {
            try
            {
                List<SupplierChain> SupplierList = new List<SupplierChain>
                {
                    new SupplierChain { SupplierId=1, SupplierName= DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz"), SupplierType="Abhandari",SupplierLocation="W20220513123613",ContactAddressList= new List<BranchAddressDetails>() {
                        new BranchAddressDetails() {BranchContactAddressId = 455,City = "Suwanee1",LocationName = "100330004722624",SGLN = "Test Product-3",Address1 = "263572354635" }

                    }
            },
                    new SupplierChain { SupplierId=2, SupplierName= DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz"), SupplierType="CovectraSupport",SupplierLocation="W20220513123629",ContactAddressList= new List<BranchAddressDetails>() {
                        new BranchAddressDetails() {BranchContactAddressId = 456,City = "Suwanee2",LocationName = "100330004722625",SGLN = "Test Product-2",Address1 = "263572354635" }

                    }},
                    new SupplierChain { SupplierId=3, SupplierName= DateTime.Now.ToString("yyyy-MM-ddTHH':'mm':'sszzz"), SupplierType="TestUser",SupplierLocation="W20220513123704",ContactAddressList= new List<BranchAddressDetails>() {
                        new BranchAddressDetails() {BranchContactAddressId = 457,City = "Suwanee3",LocationName = "100330004722626",SGLN = "Test Product-1",Address1 = "263572354635" }

                    }},



                };
                return SupplierList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}