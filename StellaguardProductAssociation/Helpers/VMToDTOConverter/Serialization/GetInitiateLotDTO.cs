using AuthentiTrack.UI.Areas.Serialization.Models;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    //public class GetInitiateLotDTO
    //{
    //}
   public partial class VMToDTOConverter
    {
        public InitiateLotDTO GetInitiateLotDTO(InitiateLotViewModel initiateLotData)
        {
        //    string ChildrenSerialNumbers = StringHelper.ConvertToCSV(initiateLotData.);
        //    string ParentSerialNumber = initiateLotData.ParentSerialNumber;
            short locationId = 0;
            try
            {

                locationId = SessionHelper.GetCurrentLocationId();
            }
            catch (Exception Ex)
            {
                throw new Exception(AuthentiTrack.I18NResources.Common.Current_location_is_invalid);//"Current location is invalid");
            }
            short userId = SessionHelper.GetCurrentUserId();
            byte languageId = SessionHelper.GetLanguageId();
            //return new InitiateLotDTO { ChildrenSerialNumbers = ChildrenSerialNumbers, ParentSerialNumber = ParentSerialNumber, ChildPackageTypeId = childPackageTypeId, ParentPackageTypeId = parentPackageTypeId, LocationId = locationId, UserId = userId, LanguageId = languageId };

            return new InitiateLotDTO { LotNo = initiateLotData.Lot,
                                        ProductId = initiateLotData.ProductId,
                                        ProductHierarcyId = initiateLotData.InitiateLot_ProductHierarcyID,
                                        ExpirationDate = Convert.ToDateTime(initiateLotData.ExpirationDate),
                                        TotalAvailableIds = initiateLotData.TotalAvailableIDs,
                                        LotSize = initiateLotData.LotSize,
                                        PackageTypeId = initiateLotData.PackageTypeId,
                                        UserId = userId,
                                        ClientId = languageId,
                                        LocationId = locationId,
                                        LanguageId = languageId,
                                        LineServerID = initiateLotData.LineServerId

            };
        }
    }
}