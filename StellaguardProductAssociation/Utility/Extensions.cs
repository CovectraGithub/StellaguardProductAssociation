using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System;
namespace StellaguardProductAssociation.Utility
{
    /// <summary>
    /// Extension methods class. Having this class available on all the projects to avoid null reference error.
    /// </summary>
    public static class MyExtensionMethods
    {
        /// <summary>
        /// Method to avoid calling StringHelper.ToString()
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static string ToStringSafe(this object s)
        {
            if (s == null) return string.Empty;
            else
            {
                string result = s.ToString().Trim();
                if (result == null) return string.Empty;
                else return result;
            }
        }
        
        /// <summary>
        /// Determines whether [is not empty] [the specified s].
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns>
        /// 	<c>true</c> if [is not empty] [the specified s]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsNotEmpty(this string s)
        {
            return !string.IsNullOrEmpty(s);
        }

        /// <summary>
        /// Converts the string to proper case.
        /// </summary>
        /// <param name="TextToFormat">The text to format.</param>
        /// <returns></returns>
        public static string ToProperCase(this string TextToFormat)
        {
            string properCase = string.Empty;
            if (TextToFormat != null)
            {
                properCase = new CultureInfo("en").TextInfo.ToTitleCase(TextToFormat.ToLower());
            }
            return properCase;
        }

        /// <summary>
        /// Converts the string to int
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static int ToIntSafe(this object s)
        {
            int outParameter = -1;
            if (s != null)
            {
                int.TryParse(s.ToString().Trim(), out outParameter);
            }

            return outParameter;
        }

        /// <summary>
        /// Converts the string to short
        /// </summary>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        public static short ToShortSafe(this object s)
        {
            short outParameter = -1;
            if (s != null)
            {
                short.TryParse(s.ToString().Trim(), out outParameter);
            }

            return outParameter;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static byte ToByteSafe(this object s)
        {
            byte outParameter = 0;
            if (s != null)
            {
                byte.TryParse(s.ToString().Trim(), out outParameter);
            }

            return outParameter;
        }

        /// <summary>
        /// Toes the decimal safe.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static decimal ToDecimalSafe(this object val)
        {
            decimal outParameter = 0M;
            if (val != null)
            {
                decimal.TryParse(val.ToStringSafe(), out outParameter);
            }
            return outParameter;
        }

        /// <summary>
        /// Toes the decimal safe.
        /// </summary>
        /// <param name="val">The val.</param>
        /// <returns></returns>
        public static DateTime ToDateTimeSafe(this object val)
        {
            DateTime outParameter = DateTime.MinValue;
            if (val != null)
            {
                DateTime.TryParse(val.ToStringSafe(), out outParameter);
            }
            return outParameter;
        }


        /// <summary>
        /// Truncate string after some length
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string TruncateAtWord(this string input, int length)
        {
            if (input == null || input.Length < length)
                return input;
            //put a space if not found in input string
            if (!input.Contains(" "))
            {
                input = input.Insert((length / 2), "\r\n");
                input = input.Insert((length - 1), " ");
            }
            //put a space if not found in input string
            int iNextSpace = input.LastIndexOf(" ", length);
            return string.Format("{0}...", input.Substring(0, (iNextSpace > 0) ? iNextSpace : length).Trim());
        }


        public static bool ToBooleanSafe(this object val)
        {
            bool result;
            if (val != null)
            {
                bool.TryParse(val.ToStringSafe(), out result);
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static bool ToBooleanSafe(this byte val)
        {
            bool result;
            if (val != null)
            {
                result = val == 1;
            }
            else
            {
                result = false;
            }
            return result;
        }

        public static short ConvertIntoSecond(this decimal minute)
        {
            return (minute * 60).ToShortSafe();
        }

        public static decimal ConvertIntoMinute(short second)
        {
            return (second / 60).ToDecimalSafe();
        }

        /// <summary>
        /// Convert datatable to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> ConvertToList<T>(this DataTable table) where T : new()
        {
            Type t = typeof(T);
            // Create a list of the entities we want to return
            List<T> returnObject = new List<T>();
            // Iterate through the DataTable's rows
            foreach (DataRow dr in table.Rows)
            {
                // Convert each row into an entity object and add to the list
                T newRow = dr.ConvertToEntity<T>();
                returnObject.Add(newRow);
            }
            // Return the finished list
            return returnObject;
        }

        /// <summary>
        /// Convert datarow to entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tableRow"></param>
        /// <returns></returns>
        public static T ConvertToEntity<T>(this DataRow tableRow) where T : new()
        {
            // Create a new type of the entity I want
            Type t = typeof(T);
            T returnObject = new T();
            foreach (DataColumn col in tableRow.Table.Columns)
            {
                string colName = col.ColumnName;
                // Look for the object's property with the columns name, ignore case
                PropertyInfo pInfo = t.GetProperty(colName.ToLower(),
                    BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                // did we find the property ?
                if (pInfo != null)
                {
                    object val = tableRow[colName];
                    // is this a Nullable<> type
                    bool IsNullable = (Nullable.GetUnderlyingType(pInfo.PropertyType) != null);
                    if (IsNullable)
                    {
                        if (val is System.DBNull)
                        {
                            val = null;
                        }
                        else
                        {
                            // Convert the db type into the T we have in our Nullable<T> type
                            val = Convert.ChangeType
                    (val, Nullable.GetUnderlyingType(pInfo.PropertyType));
                        }
                    }
                    else
                    {
                        // Convert the db type into the type of the property in our entity
                        val = Convert.ChangeType(val, pInfo.PropertyType);
                    }
                    // Set the value of the property with the value from the db
                    pInfo.SetValue(returnObject, val, null);
                }
            }
            // return the entity object with values
            return returnObject;

        }

        public static string AddNewLine(this string Container, string StringTobeAdded)
        {
            string Result = Container;
            if (!string.IsNullOrEmpty(StringTobeAdded))
            {
                if (string.IsNullOrEmpty(Container))
                {
                    Result = StringTobeAdded;
                }
                else
                {
                    Result = string.Format(Result + "{0}" + StringTobeAdded, Environment.NewLine);
                }
            }
            // Container = Result;
            return Result;
        }

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
              emptyProduct,
              (accumulator, sequence) =>
                from accseq in accumulator
                from item in sequence
                select accseq.Concat(new[] { item }));
        }

        public static DataTable ConvertToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        public static EnumAttribute GetEnumValueDescription<EnumAttribute>(this Enum enumObj) where EnumAttribute : class,new()
        {
            //get instanse of Enum:
            FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            if (null != fieldInfo)
            {
                //get custom attributes array:
                object[] attribArray = fieldInfo.GetCustomAttributes(typeof(EnumAttribute), false);

                //no attributes no description:
                if (attribArray.Length == 0)
                    return null;

                //try to cast the attribute into EnumDescriptonAttribute type:
                var attrib = (EnumAttribute)attribArray[0];

                if (null != attrib)
                {
                    //string result = string.Empty;
                    //switch (st)
                    //{
                    //    case GMSGlobals.StatusType.System:
                    //        result = attrib.Description;
                    //        break;
                    //    case GMSGlobals.StatusType.Internal:
                    //        result = attrib.InternalDescription;
                    //        break;
                    //    case GMSGlobals.StatusType.External:
                    //        result = attrib.ExternalDescription;
                    //        break;
                    //}

                    return attrib;
                }
                return null;
            }
            return null;
        }

        /// <summary>
        /// Remove un necessary space from string 
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string RemoveSpaceinCommSeperatedString(this string sourceString)
        {
            string resultString = string.Empty;
            string[] arrStrings = sourceString.Split(',');
            for (int intI = 0; intI < arrStrings.Length; intI++)
            {
                if (resultString == string.Empty ) {
                    resultString = arrStrings[intI].Trim();
                }else {
                    resultString = resultString + "," + arrStrings[intI].Trim();
                }
            }
            return resultString;

        }

    }

}