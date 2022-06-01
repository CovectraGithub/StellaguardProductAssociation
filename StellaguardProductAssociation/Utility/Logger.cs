using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StellaguardProductAssociation.Utility
{
  public  class Logger
    {

        #region Helper Method WriteToErrorLog
        /// <summary>
        /// Writes exception and trace to errorlog in case of exception.
        /// </summary>
        /// <exception cref=""> All exceptions written to console window</exception>
        public void WriteToErrorLog(string Filename, string msg, string stkTrace)
        {
            try
            {
                string ExportXMLPath = ConfigSetting.GetLogPath();
                string errorPath = ExportXMLPath + "//ErrorLog.txt";
                if (/*NOT*/!File.Exists(errorPath))
                {
                    StreamWriter sw2 = File.CreateText(errorPath);
                    sw2.Close();
                }
                using (StreamWriter sw = File.AppendText(errorPath))
                {
                    sw.Write("FileName : " + Filename + "\r\n");
                    sw.Write("Message: " + msg + "\r\n");
                    sw.Write("StackTrace: " + stkTrace + "\r\n");
                    // sw.Write("InnerException: " + InnerException + "\r\n");
                    sw.Write("Date/Time: " + DateTime.Now.ToString() + "\r\n");
                    sw.Write("================================================\r\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to error log " + ex.Message);
            }
        }
        #endregion

        #region Helper Method WriteToProcessLog
        /// <summary>
        /// Writes the process summary of each file to the log file 
        /// </summary>
        /// <exception cref=""> All exceptions written to console window</exception>
        public void WriteToProcessLog(string Filename, string Status, DateTime LastRunTime)
        {
            try
            {
                TimeSpan processingTime = DateTime.Now.Subtract(LastRunTime);
                Console.WriteLine(Filename + " Processing Time" + processingTime.ToString());
                string exportXMLPath = ConfigSetting.GetLogPath();
                string processPath = exportXMLPath + "//ProcessLog.txt";
                if (/*NOT*/!File.Exists(processPath))
                {
                    StreamWriter sw2 = File.CreateText(processPath);
                    sw2.Close();
                }
                using (StreamWriter sw = File.AppendText(processPath))
                {
                    sw.Write("FileName : " + Filename + "\r\n");
                    sw.Write("Status: " + Status + "\r\n");
                    sw.Write("Date/Time: " + DateTime.Now.ToString() + "\r\n");
                    sw.Write("Processing Time: " + processingTime.Hours.ToString() + " Hour(s) " + processingTime.Minutes.ToString() + " min " + processingTime.Seconds.ToString() + " sec" + "\r\n");
                    sw.Write("================================================\r\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error writing to error log " + ex.Message);
            }
        }
        #endregion
    }
}
