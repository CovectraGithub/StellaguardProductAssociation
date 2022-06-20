using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using StellaguardProductAssociation.Utility;

namespace StellaguardProductAssociation.DAL
{
   public class DBHelper
    {
       public string ConnectionString = ConfigSetting.GetConnectionString();
        public SqlConnection Connection { get; set; }
        public bool MustCloseConnection { get; set; }
        public int CommandTimeout = 36000; // Ten hours
        public DBHelper(string connectionString = null, bool mustCloseConnection = true)
      {
          if (connectionString != null)
          {
              ConnectionString = connectionString;
          }
          Connection = new SqlConnection(ConnectionString);
          MustCloseConnection = mustCloseConnection;
      }
      public void CloseConnection()
      {
          try
          {
              if (MustCloseConnection)
              { Connection.Close(); }
          }
          catch (Exception)
          {
              
              throw;
          }
      }
      public void OpenConnection()
      {
          try
          {
              //checking if connection is open then do nothing
              if (Connection.State!=ConnectionState.Open)
              { Connection.Open(); }
          }
          catch (Exception)
          {

              throw;
          }
      }
      public void ExplicitelyCloseConnection()
      {
          try
          {
			  if (Connection != null)
			  {
				  Connection.Close();
				  Connection.Dispose();
			  }
          }
          catch (Exception ex)
          {
			  throw ex;
          }
      }
      

      public DataSet ExecuteDataSet(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
      {
            DataSet ds = new DataSet();
           try
           {
           SqlCommand command = new SqlCommand();

           command.Connection = Connection;
          command.CommandTimeout = CommandTimeout;
          command.CommandText = commandText;
          command.CommandType = commandType;
          if (commandParameters != null)
          {
              AttachParameters(command, commandParameters);
          }
          OpenConnection();
          using (SqlDataAdapter da = new SqlDataAdapter(command))
            {
               
                da.Fill(ds);
                command.Parameters.Clear();
                CloseConnection();
                
            }
            }
            catch (Exception ex)
            {
                //Log exception in Exception Logger.
               // ex.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            }
            finally
            {
                CloseConnection();
            }
            return ds;
        }
       public object ExecuteNonQuery(CommandType commandType, string commandText, params SqlParameter[] commandParameters)
      {
            object result;
           try
           {
           SqlCommand command = new SqlCommand();
          command.Connection = Connection;
          command.CommandTimeout = CommandTimeout;
          command.CommandText = commandText;
          command.CommandType = commandType;
          if(commandParameters!=null)
          {
              AttachParameters(command, commandParameters);
          }
          OpenConnection();
             result = command.ExecuteNonQuery();
          CloseConnection();
            }
            catch (Exception ex)
            {
                //Log exception in Exception Logger.
                //ex.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return result;
      }
       public object ExecuteNonQuery(CommandType commandType, string commandText)
       {
            object result;
            try
            {
            SqlCommand command = new SqlCommand();
           command.Connection = Connection;
           command.CommandTimeout = CommandTimeout;
           command.CommandText = commandText;
           command.CommandType = commandType;
           OpenConnection();
                result = command.ExecuteNonQuery();
           CloseConnection();
            }
            catch (Exception ex)
            {
                //Log exception in Exception Logger.
                //ex.Log(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
            return result;
       }
      private void AttachParameters(SqlCommand command, SqlParameter[] commandParameters)
      {
          if (command == null) throw new ArgumentNullException("command");
          if (commandParameters != null)
          {
              foreach (SqlParameter p in commandParameters)
              {
                  if (p != null)
                  {
                      // Check for derived output value with no value assigned
                      if ((p.Direction == ParameterDirection.InputOutput ||
                          p.Direction == ParameterDirection.Input) &&
                          (p.Value == null))
                      {
                          p.Value = DBNull.Value;
                      }
                      command.Parameters.Add(p);
                  }
              }
          }
      }
    }
}
