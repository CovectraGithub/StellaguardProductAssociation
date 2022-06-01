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
        public ShippingDTO GetShippingDTO(ShippingViewModel shippingData,string transactionXml,string lotNumbers)
        {
            string hrCodes = string.Empty;
            string selectedlotNumber = string.Empty; 

            if (shippingData.IsShipedBYLot == true)
            {
                selectedlotNumber = lotNumbers;
            }
            else
            { hrCodes = StringHelper.ConvertToCSV(shippingData.HRCodes); }
            short fromLocationId = 0;
            short toLocationId = 0;
            short userId = 0;
            byte languageId = 1;
			short sellerLocationId = shippingData.SellerLocationId;
			short buyerLocationId = shippingData.BuyerLocationId;

            byte? movementTypeId = shippingData.MovementTypeId;
            short? carrierTypeAddressId = shippingData.CarrierPartyAddressId;
            DateTime? shippingDateTime = shippingData.ShipmentDateTime;

            short? processFromLocationId = shippingData.ProcessingFromLocationId;
            short? processToLocationId = shippingData.ProcessingToLocationId;
            bool isDropShipment = shippingData.IsDropShipment;
            
            toLocationId = shippingData.ToAddressId;
            userId = SessionHelper.GetCurrentUserId();
            fromLocationId = SessionHelper.GetCurrentLocationId();
            languageId = SessionHelper.GetLanguageId();


            return new ShippingDTO() { LotIds = lotNumbers,  HRCodes = hrCodes, FromLocationId = fromLocationId, ToLocationId = toLocationId, TransactionXml = transactionXml, UserId = userId, MovementTypeId = movementTypeId, CarrierTypeAddressId = carrierTypeAddressId, TrackingNumber = shippingData.TrackingNumber, LanguageId = languageId, SellerLocationId = sellerLocationId, BuyerLocationId = buyerLocationId, ShippingDateTime = shippingDateTime,ProcessFromLocationId=processFromLocationId,ProcessToLocationId=processToLocationId,IsDropShipment=isDropShipment};
        }
		
    }
}