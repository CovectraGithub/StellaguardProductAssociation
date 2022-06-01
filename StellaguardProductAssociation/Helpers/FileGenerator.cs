using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AuthentiTrack.UI.Helpers
{
    public static class FileGenerator
    {
        public static void GenerateCsvFile<T>(IEnumerable<T> contents, string path, bool hideHeader = true) where T:class, new()
        {
            using (TextWriter textWriter = File.CreateText(path))
            {
                var csv = new CsvWriter(textWriter);

                csv.Configuration.HasHeaderRecord = !hideHeader;

                csv.WriteRecords(contents);
            }
        }
    }
}