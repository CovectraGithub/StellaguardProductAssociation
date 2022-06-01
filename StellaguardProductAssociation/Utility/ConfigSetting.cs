using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace StellaguardProductAssociation.Utility
{
   public class ConfigSetting
    {
       public static string GetLogPath()
       {
          string defaultPath = @"C:\SystechGS1\Log";
           string key = "LogPath";
           string path= ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;   
           if(Directory.Exists(path)==false)
           {
               Directory.CreateDirectory(path);
           }
           return path;
       }
	   public static string GetSqlFilePath()
	   {
		   string defaultPath = @"C:\SystechGS1\Log";
		   string key = "SqlFilePath";
		   string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
		   if (Directory.Exists(path) == false)
		   {
			   Directory.CreateDirectory(path);
		   }
		   return path;
	   }
       public static string GetImportXMLPath()
       {
           string defaultPath = @"C:\SystechGS1\ImportXML";
           string key = "ImportXMLPath";
           string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
           if (Directory.Exists(path) == false)
           {
               Directory.CreateDirectory(path);
           }
           return path;
       }
       public static string GetExportXMLPath()
       {
           string defaultPath = @"C:\SystechGS1\ExportXML";
           string key = "ExportXMLPath";
           string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
           if (Directory.Exists(path) == false)
           {
               Directory.CreateDirectory(path);
           }
           return path;
       }
       public static string GetErrorXMLPath()
       {
           string defaultPath = @"C:\SystechGS1\ErrorXML";
           string key = "ErrorXMLPath";
           string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
           if (Directory.Exists(path) == false)
           {
               Directory.CreateDirectory(path);
           }
           return path;
       }
       public static string GetXSLTParserPath()
       {
           return ConfigurationSettings.AppSettings["XSLTParserPath"];
       }
        public static string GetConnectionString()
       {
           return ConfigurationSettings.AppSettings["PharmoRxConnectionString"];
       }

        public static string GetFromEmailAddress()
        {
            return ConfigurationSettings.AppSettings["FromEmailAddress"];
        }
        public static string GetCCEmailAddress()
        {
            return ConfigurationSettings.AppSettings["CCTo"];
        }
        public static string GetPort()
        {
            return ConfigurationSettings.AppSettings["Port"];
        }
        public static string GetEnableSSL()
        {
            return ConfigurationSettings.AppSettings["EnableSSL"];
        }
        public static string GetSMTPServerName()
        {
            return ConfigurationSettings.AppSettings["SMTPServerName"];
        }
        public static string GetMailUsername()
        {
            return ConfigurationSettings.AppSettings["MailUsername"];
        }
        public static string GetMailPassword()
        {
            return ConfigurationSettings.AppSettings["MailPassword"];
        }
		public static string GetCreatedBy()
		{
			return ConfigurationSettings.AppSettings["CreatedBy"];
		}

		internal static string GetParseStartSubject()
		{
			return ConfigurationSettings.AppSettings["PARSE_START_SUBJECT"];
		}

		internal static string GetParseStartBody()
		{
			return ConfigurationSettings.AppSettings["PARSE_START_BODY"];
		}

		internal static string GetParseSuccessSubject()
		{
			return ConfigurationSettings.AppSettings["PARSE_SUCCESS_SUBJECT"];
		}

		internal static string GetParseSuccessBody()
		{
			return ConfigurationSettings.AppSettings["PARSE_SUCCESS_BODY"];
		}

		internal static string GetParseErrorSubject()
		{
			return ConfigurationSettings.AppSettings["PARSE_ERROR_SUBJECT"];
		}

		internal static string GetParseErrorBody()
		{
			return ConfigurationSettings.AppSettings["PARSE_ERROR_BODY"];
		}

        internal static string GetSendASNErrorSubject()
        {
            return ConfigurationSettings.AppSettings["SEND_ASN_ERROR_SUBJECT"];
        }

        internal static string GetSendASNSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["SEND_ASN_SUCCESS_SUBJECT"];
        }

        internal static string GetGenerateASNErrorSubject()
        {
            return ConfigurationSettings.AppSettings["GENERATE_ASN_ERROR_SUBJECT"];
        }

        internal static string GetGenerateASNSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["GENERATE_ASN_SUCCESS_SUBJECT"];
        }
        internal static string GetCertificateFolderPath()
        {
            return ConfigurationSettings.AppSettings["CertificateFolderPath"];
        }


        internal static string GetAttachmentFolderPath()
        {
            return ConfigurationSettings.AppSettings["AttachmentFolder"];
        }
        internal static string GetSNImportEmailSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["SN_IMPORT_SUCCESS_SUBJECT"];
        }
        internal static string GetSNImportEmailRequestRejectionSubject()
        {
            return ConfigurationSettings.AppSettings["SN_IMPORT_REQUEST_REJECTION_SUBJECT"];
        }
        internal static string GetSNImportEmailErrorSubject()
        {
            return ConfigurationSettings.AppSettings["SN_IMPORT_ERROR_SUBJECT"];
        }
        internal static string GetSNImportEmailErrorInConfirmationSubject()
        {
            return ConfigurationSettings.AppSettings["SN_IMPORT_ERRORONCONFIRMATION_SUBJECT"];
        }
        internal static string GetCaptureSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["XML_CAPTURE_SUCCESS"];
        }

        internal static string GetCSVCaptureSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["CSV_CAPTURE_SUCCESS"];
        }

        internal static string GetCaptureErrorSubject()
        {
            return ConfigurationSettings.AppSettings["XML_CAPTURE_ERROR"];
        }
        internal static string GetCSVCaptureErrorSubject()
        {
            return ConfigurationSettings.AppSettings["CSV_CAPTURE_ERROR"];
        }

        internal static string GetLotSummarySuccessSubject()
        {
            return ConfigurationSettings.AppSettings["LOT_SUMMARY_SUCCESS"];
        }

        internal static string GetLotSummaryErrorSubject()
        {
            return ConfigurationSettings.AppSettings["LOT_SUMMARY_ERROR"];
        }

        internal static string GetXSDLocation()
        {
            return ConfigurationSettings.AppSettings["XSDLocation"];
        }

        internal static string GetConfigurationPathXML()
        {
            return ConfigurationSettings.AppSettings["ConfigurationPathCapture"];
        }

        internal static string GetCapturedXMLPath()
        {
            return ConfigurationSettings.AppSettings["CapturedXMLPath"];
        }
        internal static string GetLotSummaryXMLPath()
        {
            return ConfigurationSettings.AppSettings["LotSummaryXMLPath"];
        }
        
        internal static bool IsXSDValidate()
        {
            return Convert.ToBoolean(ConfigurationSettings.AppSettings["IsValidate"]);
        }
        //-------------------------------
        internal static string SNProvisioningInboxPath()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["SNProvisioningInboxPath"]);
        }

        internal static string AquestiveICSInboxPath()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["AquestiveICSInboxPath"]);
        }
        internal static string SNProvisioningOutboxPath()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["SNProvisioningOutboxPath"]);
        }
        internal static string NonProvisioningFilePath()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["NonProvisioningFilePath"]);
        }
        internal static string SNProvisioningRequestConfigurationCode()
        {
            return ConfigurationSettings.AppSettings["SNProvisioningRequestConfigurationCode"];
        }
        internal static string SNProvisioningSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["SNPROVISIONING_SUCCESS_SUBJECT"];
        }
        internal static string SNProvisioningFailureSubject()
        {
            return ConfigurationSettings.AppSettings["SNPROVISIONING_FAILURE_SUBJECT"];
        }
        internal static string EPCISFileSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["EPCISFILE_SUCCESS_SUBJECT"];
        }
        internal static string EPCISFileFailureSubject()
        {
            return ConfigurationSettings.AppSettings["EPCISFILE_FAILURE_SUBJECT"];
        }
        internal static string BlankFileSuccessSubject()
        {
            return ConfigurationSettings.AppSettings["BLANKFILE_SUCCESS_SUBJECT"];
        }
        internal static string BlankFileFailureSubject()
        {
            return ConfigurationSettings.AppSettings["BLANKFILE_FAILURE_SUBJECT"];
        }
        internal static string SNProvisioningProcessed()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["SNProvisioningProcessed"]);
        }
        internal static string AquestiveProcessed()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["AquestiveICSProcessed"]);
        }
        internal static string SNProvisioningError()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["SNProvisioningError"]);
        }
        internal static string AquestiveICSError()
        {
            return GetDirectoryPath(ConfigurationSettings.AppSettings["AquestiveICSError"]);
        }
        internal static bool InfiniteRun()
        {
            string configValue = string.Empty ;
            bool result = false;
            if(ConfigurationSettings.AppSettings["InfiniteRun"]!=null)
            {
                configValue =  ConfigurationSettings.AppSettings["InfiniteRun"];
                if(configValue.ToLower()=="true" || configValue.ToLower() == "1")
                {
                    result = true;
                }
            }

            return result;
        }
        internal static int TimeIntervalInSec()
        {
            string configValue = string.Empty;
            int result = 0;
            bool isNumeric = false;
            if (ConfigurationSettings.AppSettings["TimeIntervalInSec"] != null)
            {
                configValue = ConfigurationSettings.AppSettings["TimeIntervalInSec"];
                isNumeric = int.TryParse(configValue,out result);
            }
            return result;
        }

        internal static string GetDirectoryPath(string configValue)
        {
            if (!string.IsNullOrEmpty(configValue) && !Directory.Exists(configValue))
            {
                try
                {
                    Directory.CreateDirectory(configValue);
                }
                catch (Exception)
                { }
            }
            return configValue;
        }

        public static string TempSFTP()
        {
            string defaultPath = @"C:\SystechGS1\Log";
            string key = "TempSFTP";
            string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }


        public static string SFTPLocation()
        {
            string defaultPath = @"C:\SystechGS1\Log";
            string key = "SFTPLocation";
            string path = ConfigurationSettings.AppSettings.AllKeys.Any(a => a == key) ? ConfigurationSettings.AppSettings.GetValues(key).DefaultIfEmpty(defaultPath).FirstOrDefault() : defaultPath;
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

    }
}
