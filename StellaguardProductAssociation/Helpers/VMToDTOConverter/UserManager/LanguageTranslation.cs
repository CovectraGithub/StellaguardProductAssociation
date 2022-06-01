using AuthentiTrack.UI.UserManagerServiceReference;
using AuthentiTrack.UI.Areas.UserManager.Models;

using AuthentiTrack.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public partial class VMToDTOConverter
    {
        public LanguageTranslationImportDTO LanguageTranslationImport(byte languageId,string messageTranslationFile,string tableDataTranslationFile,string emailTemplateTranslationData=null)
        {
            short userId = SessionHelper.GetCurrentUserId();
            byte userLanguageId = SessionHelper.GetLanguageId();
            return new LanguageTranslationImportDTO() { LanguageId=languageId,CreatedBy=userId,MessageTranslationFile=messageTranslationFile,TableDataTranslationFile=tableDataTranslationFile,EmailTemplateTranslationFile=emailTemplateTranslationData,UserLanguageId=userLanguageId};
        }
    }
}