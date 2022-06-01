using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AuthentiTrack.UI.SerializationServiceReference;
using AuthentiTrack.UI.Areas.Serialization.Models;


namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public AddResourcesDTO GetAddResourcesDTO(AddResourceViewModel addResourceViewModel)
        {

            string resourceName = string.Empty;
            bool isStoredProcedure = addResourceViewModel.IsStoredProcedure;
            if (addResourceViewModel != null)
            {
                resourceName = addResourceViewModel.ResourceName;
                isStoredProcedure = addResourceViewModel.IsStoredProcedure;

            }
            return new AddResourcesDTO
            {
                ResourceName = resourceName,
                IsStoredProcedure = isStoredProcedure
            };
        }

        public EditResourceTypeDTO GetEditResourceType(EditResourceTypeViewModel editResourceTypeViewModel)
        {
            int ResourceId = editResourceTypeViewModel.ResourceId;
            string ResourceName = editResourceTypeViewModel.ResourceName;
            bool? IsStoredProcedure = editResourceTypeViewModel.IsStoredProcedure;

            if (editResourceTypeViewModel != null)
            {
                ResourceId = editResourceTypeViewModel.ResourceId;

                ResourceName = editResourceTypeViewModel.ResourceName;
                IsStoredProcedure = editResourceTypeViewModel.IsStoredProcedure;

            }
            return new EditResourceTypeDTO
            {
                ResourceId = ResourceId,
                ResourceName = ResourceName,
                IsStoredProcedure = IsStoredProcedure


            };
        }

        public AddNewMessageDTO GetAddNewMessage(AddNewMessageViewModel addNewMessageViewModel)
        {
            int ResourceId = addNewMessageViewModel.ResourceId;
            int LanguageID = addNewMessageViewModel.LanguageID;
            string MessageCode = addNewMessageViewModel.MessageCode;
            string Message = addNewMessageViewModel.Message;
            bool? IsStoredProcedure = addNewMessageViewModel.IsStoredProcedure;

            if (addNewMessageViewModel != null)
            {
                ResourceId = addNewMessageViewModel.ResourceId;
                LanguageID = addNewMessageViewModel.LanguageID;
                MessageCode = addNewMessageViewModel.MessageCode;
                Message = addNewMessageViewModel.Message;
                IsStoredProcedure = addNewMessageViewModel.IsStoredProcedure;

            }
            return new AddNewMessageDTO
            {
              ResourceId = ResourceId,
              LanguageID1 = LanguageID,
              MessageCode = addNewMessageViewModel.MessageCode,
              Message = Message,
              IsStoredProcedure = IsStoredProcedure,
            };

        }

        //public EditMessageTypeDTO GetEditMessage(EditMessageTypeViewModel editMessageTypeViewModel)
        //{
        //    int ResourceId = editMessageTypeViewModel.ResourceId;
        //    int LanguageID = editMessageTypeViewModel.LanguageId;
        //    string MessageCode = editMessageTypeViewModel.MessageCode;
        //    string Message = editMessageTypeViewModel.Message;
        //    bool? IsStoredProcedure = editMessageTypeViewModel.IsStoredProcedure;
           
        //    if (editMessageTypeViewModel != null)
        //    {
        //        ResourceId = editMessageTypeViewModel.ResourceId;
        //        LanguageID = editMessageTypeViewModel.LanguageId;
        //        MessageCode = editMessageTypeViewModel.MessageCode;
        //        Message = editMessageTypeViewModel.Message;
        //        IsStoredProcedure = editMessageTypeViewModel.IsStoredProcedure;

        //    }
        //    return new AddNewMessageDTO
        //    {
        //        ResourceId = ResourceId,
        //        LanguageID1 = LanguageID,
        //        MessageCode = editMessageTypeViewModel.MessageCode,
        //        Message = Message,
        //        IsStoredProcedure = IsStoredProcedure,
        //    };

        //}
    }
}