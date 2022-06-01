using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StellaguardProductAssociation.Utility
{
    public class Constant
    {
        public static string PARSE_START_SUBJECT = ConfigSetting.GetParseStartSubject();
        public static string PARSE_START_BODY = ConfigSetting.GetParseStartBody();
        public static string PARSE_SUCCESS_SUBJECT = ConfigSetting.GetParseSuccessSubject();
        public static string PARSE_SUCCESS_BODY = ConfigSetting.GetParseSuccessBody();
        public static string PARSE_ERROR_SUBJECT = ConfigSetting.GetParseErrorSubject();
        public static string PARSE_ERROR_BODY = ConfigSetting.GetParseErrorBody();
        public static string SEND_ASN_ERROR_SUBJECT = ConfigSetting.GetSendASNErrorSubject();
        public static string SEND_ASN_SUCCESS_SUBJECT = ConfigSetting.GetSendASNSuccessSubject();
        public static string GENERATE_ASN_ERROR_SUBJECT = ConfigSetting.GetGenerateASNErrorSubject();
        public static string GENERATE_ASN_SUCCESS_SUBJECT = ConfigSetting.GetGenerateASNSuccessSubject();

        public static string EMAIL_ATTACHMENT_FOLDER_PATH = ConfigSetting.GetAttachmentFolderPath();
        public static string SN_IMPORT_SUCCESS_SUBJECT = ConfigSetting.GetSNImportEmailSuccessSubject();
        public static string SN_IMPORT_REQUEST_REJECTION_SUBJECT = ConfigSetting.GetSNImportEmailRequestRejectionSubject();
        public static string SN_IMPORT_ERROR_SUBJECT = ConfigSetting.GetSNImportEmailErrorSubject();
        public static string SN_IMPORT_ERRORONCONFIRMATION_SUBJECT = ConfigSetting.GetSNImportEmailErrorInConfirmationSubject();

        public static string CERTIFICATE_FOLDER_PATH = ConfigSetting.GetCertificateFolderPath();

   
        public static string CAPTURE_SUCCESS_SUBJECT = ConfigSetting.GetCaptureSuccessSubject();
        public static string CSVCAPTURE_SUCCESS_SUBJECT = ConfigSetting.GetCSVCaptureSuccessSubject();
        public static string CAPTURE_ERROR_SUBJECT = ConfigSetting.GetCaptureErrorSubject();
        public static string CSVCAPTURE_ERROR_SUBJECT = ConfigSetting.GetCSVCaptureErrorSubject();
        public static string LOTSUMMARY_SUCCESS_SUBJECT = ConfigSetting.GetLotSummarySuccessSubject();
        public static string LOTSUMMARY_ERROR_SUBJECT = ConfigSetting.GetLotSummaryErrorSubject();
        
        public static string AQUESTIVEICS_INBOX_PATH = ConfigSetting.AquestiveICSInboxPath();
        public static string AQUESTIVEICS_PROCESSED = ConfigSetting.AquestiveProcessed();
        public static string AQUESTIVEICS_ERROR = ConfigSetting.AquestiveICSError();

        public static string SN_PROVISIONING_INBOX_PATH = ConfigSetting.SNProvisioningInboxPath();
        public static string SN_PROVISIONING_OUTBOX_PATH = ConfigSetting.SNProvisioningOutboxPath();
        public static string NON_PROVISIONING_FILE_PATH = ConfigSetting.NonProvisioningFilePath();
        public static string SN_PROVISIONING_REQUEST_CONFIGURATION_CODE = ConfigSetting.SNProvisioningRequestConfigurationCode();
        public static string SN_PROVISIONING_SUCCESS_SUBJECT = ConfigSetting.SNProvisioningSuccessSubject();
        public static string SN_PROVISIONING_FAILURE_SUBJECT = ConfigSetting.SNProvisioningFailureSubject();
        public static string EPCISFILE_SUCCESS_SUBJECT = ConfigSetting.EPCISFileSuccessSubject();
        public static string EPCISFILE_FAILURE_SUBJECT = ConfigSetting.EPCISFileFailureSubject();
        public static string BLANKFILE_SUCCESS_SUBJECT = ConfigSetting.BlankFileSuccessSubject();
        public static string BLANKFILE_FAILURE_SUBJECT = ConfigSetting.BlankFileFailureSubject();

        public static string SN_PROVISIONING_PROCESSED = ConfigSetting.SNProvisioningProcessed();
        public static string SN_PROVISIONING_ERROR = ConfigSetting.SNProvisioningError();
        public static bool INFINITE_RUN = ConfigSetting.InfiniteRun();
        public static int TIME_INTERVAL_IN_SEC = ConfigSetting.TimeIntervalInSec();
        //  public const string 
    }
}
