using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using Woc.Book.ErrorHandler.BusinessEntity;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Service;
namespace Woc.Book.ErrorHandler.Service
{
   public class ErrorHandlerService
    {
       public void SaveData(IBusinessEntity iBusinessEntity)
       {
            ErrorHandlers errorHandlers = new ErrorHandlers();
            errorHandlers = (ErrorHandlers)iBusinessEntity;
            using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("usp_WocBookInsertErrorHandler", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {

                        command.Parameters.Add("@StackTrace", SqlDbType.NVarChar);
                        command.Parameters["@StackTrace"].Value = errorHandlers.StackTrace;

                        command.Parameters.Add("@Message", SqlDbType.NVarChar);
                        command.Parameters["@Message"].Value = errorHandlers.Message;

                        command.Parameters.Add("@Source", SqlDbType.NVarChar);
                        command.Parameters["@Source"].Value = errorHandlers.Source;

                        command.Parameters.Add("@Module", SqlDbType.NVarChar);
                        command.Parameters["@Module"].Value = errorHandlers.Module;

                        command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
                        command.Parameters["@UserID"].Value = GetUserID(errorHandlers.UserID);


                        command.Transaction = transaction;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

                connection.Close();
            }
      }


      internal Guid GetUserID(String loginID)
       {
          
           string StrSql = "SELECT UserID FROM Users WHERE (loginId = @loginId)";

    
           using (var connection = new SqlConnection(UtilityService.Connection()))

           using (var command = new SqlCommand(StrSql, connection))
           {
               connection.Open();
               command.Parameters.Add("@loginId", SqlDbType.NVarChar).Value = loginID;
                return (Guid)command.ExecuteScalar();
           }

           

       } 

    }
}
