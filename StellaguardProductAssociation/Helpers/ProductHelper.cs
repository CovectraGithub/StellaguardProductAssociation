using AuthentiTrack.UI.SerializationServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public class ProductHelper
    {
        public static string GetProductNameById (short productId)
        {
            string productName = string.Empty;
            try
            {
                using (SerializationServiceClient service = new SerializationServiceClient())
                {
                    productName = service.GetProductNameById(productId);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return productName;
        }

        public static string GetHierarchyNameByHierarchyId(short hierarchyId,short productId)
        {
            string hierarchyName = string.Empty;
            byte languageId = SessionHelper.GetLanguageId();
            try
            {
                using (SerializationServiceClient service = new SerializationServiceClient())
                {
                    hierarchyName = service.GetHierarchyNameById(hierarchyId,productId,languageId);
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }

            return hierarchyName;
        }
    }
}