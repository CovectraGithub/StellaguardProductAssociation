using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public LotShippingDTO GetLotShippingDTO(LotShipViewModel shippingData,string transactionXml)
        {
            string batchNumber = shippingData.BatchNumber;
            short fromLocationId = 0;
            short toLocationId = 0;
            short userId = 0;
            byte languageId = 1;
			byte sellerId = shippingData.SellerId;
			byte buyerId = shippingData.BuyerId;

            toLocationId = shippingData.ToAddressId;
            userId = SessionHelper.GetCurrentUserId();
            fromLocationId = SessionHelper.GetCurrentLocationId();
            languageId = SessionHelper.GetLanguageId();

			return new LotShippingDTO() { BatchNumber = batchNumber, FromLocationId = fromLocationId, 
				ToLocationId = toLocationId, TransactionXml = transactionXml, UserId = userId, 
				LanguageId = languageId, SellerId = sellerId, BuyerId = buyerId };
        }
		
    }
}