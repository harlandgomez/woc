using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Contract.BusinessEntity;
using Woc.Book.Base.Service;
using Woc.Book.Base.Constant;

namespace Woc.Book.Contract.Service
{
  public  class ContractService
    {
      public String SaveData(INewBookEntity iBusinessEntity)
      {

          try
          {
              Contracts contracts = new Contracts();
              contracts = (Contracts) iBusinessEntity;
              String contractID = string.Empty;

              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookContract", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {

                          command.Parameters.Add("@BookingCode", SqlDbType.NVarChar);
                          command.Parameters["@BookingCode"].Value = contracts.BookingCode;

                          command.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@AgentID"].Value = contracts.AgentID;

                          command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                          command.Parameters["@StartDate"].Value = contracts.StartDate;

                          command.Parameters.Add("@StopDate", SqlDbType.DateTime);
                          command.Parameters["@StopDate"].Value = contracts.StopDate;

                          command.Parameters.Add("@TripType", SqlDbType.NVarChar);
                          command.Parameters["@TripType"].Value = contracts.TripType;

                          command.Parameters.Add("@TripFrom", SqlDbType.NVarChar);
                          command.Parameters["@TripFrom"].Value = contracts.TripFrom;

                          command.Parameters.Add("@TripTo", SqlDbType.NVarChar);
                          command.Parameters["@TripTo"].Value = contracts.TripTo;

                          command.Parameters.Add("@Seater", SqlDbType.Int);
                          command.Parameters["@Seater"].Value = contracts.Seater;

                          command.Parameters.Add("@InvoiceText", SqlDbType.NVarChar);
                          command.Parameters["@InvoiceText"].Value = contracts.InvoiceText;

                          command.Parameters.Add("@PersonInCharge", SqlDbType.NVarChar);
                          command.Parameters["@PersonInCharge"].Value = contracts.PersonInCharge;

                          command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                          command.Parameters["@Contact"].Value = contracts.Contact;

                          command.Parameters.Add("@RatesType", SqlDbType.NVarChar);
                          command.Parameters["@RatesType"].Value = contracts.RatesType;

                          command.Parameters.Add("@Rates", SqlDbType.Money);
                          command.Parameters["@Rates"].Value = contracts.Rates;

                          command.Parameters.Add("@Remarks1", SqlDbType.NVarChar);
                          command.Parameters["@Remarks1"].Value = contracts.Remarks1;

                          command.Parameters.Add("@Remarks2", SqlDbType.NVarChar);
                          command.Parameters["@Remarks2"].Value = contracts.Remarks2;

                          command.Parameters.Add("@DriverClaim", SqlDbType.NVarChar);
                          command.Parameters["@DriverClaim"].Value = contracts.DriverClaim;

                          command.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                          command.Parameters["@PONumber"].Value = contracts.PONumber;

                          command.Parameters.Add("@CreatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@CreatedBy"].Value = contracts.CreatedBy;

                          //days
                          command.Parameters.Add("@Mon", SqlDbType.Bit);
                          command.Parameters["@Mon"].Value = contracts.Monday;

                          command.Parameters.Add("@Tue", SqlDbType.Bit);
                          command.Parameters["@Tue"].Value = contracts.Tuesday;

                          command.Parameters.Add("@Wed", SqlDbType.Bit);
                          command.Parameters["@Wed"].Value = contracts.Wednesday;

                          command.Parameters.Add("@Thu", SqlDbType.Bit);
                          command.Parameters["@Thu"].Value = contracts.Thursday;

                          command.Parameters.Add("@Fri", SqlDbType.Bit);
                          command.Parameters["@Fri"].Value = contracts.Friday;

                          command.Parameters.Add("@Sat", SqlDbType.Bit);
                          command.Parameters["@Sat"].Value = contracts.Saturday;

                          command.Parameters.Add("@Sun", SqlDbType.Bit);
                          command.Parameters["@Sun"].Value = contracts.Sunday;

                          //Start
                          command.Parameters.Add("@StartMon", SqlDbType.NVarChar);
                          command.Parameters["@StartMon"].Value = contracts.StartMonday;

                          command.Parameters.Add("@StartTue", SqlDbType.NVarChar);
                          command.Parameters["@StartTue"].Value = contracts.StartTuesday;

                          command.Parameters.Add("@StartWed", SqlDbType.NVarChar);
                          command.Parameters["@StartWed"].Value = contracts.StartWednesday;

                          command.Parameters.Add("@StartThu", SqlDbType.NVarChar);
                          command.Parameters["@StartThu"].Value = contracts.StartThursday;

                          command.Parameters.Add("@StartFri", SqlDbType.NVarChar);
                          command.Parameters["@StartFri"].Value = contracts.StartFriday;

                          command.Parameters.Add("@StartSat", SqlDbType.NVarChar);
                          command.Parameters["@StartSat"].Value = contracts.StartSaturday;

                          command.Parameters.Add("@StartSun", SqlDbType.NVarChar);
                          command.Parameters["@StartSun"].Value = contracts.StartSunday;

                          //End
                          command.Parameters.Add("@EndMon", SqlDbType.NVarChar);
                          command.Parameters["@EndMon"].Value = contracts.EndMonday;

                          command.Parameters.Add("@EndTue", SqlDbType.NVarChar);
                          command.Parameters["@EndTue"].Value = contracts.EndTuesday;

                          command.Parameters.Add("@EndWed", SqlDbType.NVarChar);
                          command.Parameters["@EndWed"].Value = contracts.EndWednesday;

                          command.Parameters.Add("@EndThu", SqlDbType.NVarChar);
                          command.Parameters["@EndThu"].Value = contracts.EndThursday;

                          command.Parameters.Add("@EndFri", SqlDbType.NVarChar);
                          command.Parameters["@EndFri"].Value = contracts.EndFriday;

                          command.Parameters.Add("@EndSat", SqlDbType.NVarChar);
                          command.Parameters["@EndSat"].Value = contracts.EndSaturday;

                          command.Parameters.Add("@EndSun", SqlDbType.NVarChar);
                          command.Parameters["@EndSun"].Value = contracts.EndSunday;

                          command.Parameters.Add("@ContractStartTime", SqlDbType.NVarChar);
                          command.Parameters["@ContractStartTime"].Value = contracts.ContractStartTime;

                          command.Parameters.Add("@ContractEndTime", SqlDbType.NVarChar);
                          command.Parameters["@ContractEndTime"].Value = contracts.ContractEndTime;

                          command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                          command.Parameters["@TransactionMode"].Value = 1;

                          command.Parameters.Add("@ContractID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@ContractID"].Direction = ParameterDirection.Output;

                          command.Transaction = transaction;
                          command.ExecuteNonQuery();

                          contractID = command.Parameters["@ContractID"].Value.ToString();

                          transaction.Commit();
                      }
                  }

                  connection.Close();
              }

              return contractID;
          }
          catch
          {

              return Woc.Book.Base.Constant.Constant.MessageUnSaved;
          }

      }

      public String SaveScheduleData(List<ContractSchedules> contractSchedules)
      {

          try
          {
              
              DataTable table = new DataTable();
              table.Columns.Add(new DataColumn("ContractID", typeof(Guid)));
              table.Columns.Add(new DataColumn("ScheduleDate", typeof(DateTime)));
              table.Columns.Add(new DataColumn("StartTime", typeof(DateTime)));
              table.Columns.Add(new DataColumn("EndTime", typeof(DateTime)));

              foreach (ContractSchedules contractschedule in contractSchedules)
              {
                  DataRow row = table.NewRow();
                  row["ContractID"] = contractschedule.ContractID;
                  row["ScheduleDate"] = contractschedule.ScheduleDate;
                  row["StartTime"] = contractschedule.StartTime;
                  row["EndTime"] = contractschedule.EndTime;
                  table.Rows.Add(row);
              }

              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  // Create a SqlDataAdapter based on a SELECT query.
                  SqlDataAdapter adapter = new SqlDataAdapter();

                  // Create a SqlCommand to execute the stored procedure.
                  adapter.InsertCommand = new SqlCommand("usp_WocBookContractSchedule", connection);
                  adapter.InsertCommand.CommandType = CommandType.StoredProcedure;

                  adapter.InsertCommand.Parameters.Add("@ContractID", SqlDbType.UniqueIdentifier, 16, "ContractID");
                  adapter.InsertCommand.Parameters.Add("@ScheduleDate", SqlDbType.DateTime, 16, "ScheduleDate");
                  adapter.InsertCommand.Parameters.Add("@StartTime", SqlDbType.DateTime, 16, "StartTime");
                  adapter.InsertCommand.Parameters.Add("@EndTime", SqlDbType.DateTime, 16, "EndTime");

                  // Update the database.
                  adapter.Update(table);
              }

              return Woc.Book.Base.Constant.Constant.MessageSaved;
          }
          catch
          {

              return Woc.Book.Base.Constant.Constant.MessageUnSaved;
          }

      }

      public List<Contracts> SearchData(String parameter)
      {
          Contracts contracts = new Contracts();
          List<Contracts> ListContract = new List<Contracts>();
          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              StringBuilder sqlBuilder = new StringBuilder();
              sqlBuilder.Append("SELECT A.PrefixCode ");
              sqlBuilder.Append(", C.ContractID ");
              sqlBuilder.Append(", A.Agent ");
              sqlBuilder.Append(", C.BookingCode AS Ref ");
              sqlBuilder.Append(", CASE C.TripType WHEN '2' THEN C.TripFrom + ' <> ' + C.TripTo ELSE C.TripFrom + ' > ' + C.TripTo END AS [Route]  ");
              sqlBuilder.Append(", C.Seater ");
              sqlBuilder.Append(", CASE C.RatesType WHEN '1' THEN Rates ELSE '' END AS [ContractRate] ");
              sqlBuilder.Append(", CASE C.RatesType WHEN '2' THEN Rates ELSE '' END AS [DailyRate] ");
              sqlBuilder.Append("FROM [Contract] AS C ");
              sqlBuilder.Append("INNER JOIN Agent AS A ON (A.AgentID = C.AgentID) ");
              sqlBuilder.Append("WHERE ");

              using (SqlCommand cmd = new SqlCommand(sqlBuilder.ToString() + parameter, conn))
              {
                  cmd.CommandType = CommandType.Text;
                  using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                  {
                      DataTable table = new DataTable();
                      conn.Open();
                      ad.Fill(table);

                      if (table.DefaultView.Count > 0)
                      {

                          for (int i = 0; i < table.Rows.Count; i++)
                          {
                              contracts.ContractID = new Guid(table.Rows[i]["ContractID"].ToString());
                              contracts.Prefix = table.Rows[i]["PrefixCode"].ToString();
                              contracts.Agent = table.Rows[i]["Agent"].ToString();
                              contracts.BookingCode = table.Rows[i]["Ref"].ToString();
                              contracts.Route = table.Rows[i]["Route"].ToString();
                              contracts.Seater = table.Rows[i]["Seater"].ToString();
                              contracts.ContractRate = table.Rows[i]["ContractRate"].ToString();
                              contracts.DailyRate = table.Rows[i]["DailyRate"].ToString();
                              ListContract.Add(contracts);
                              contracts = new Contracts();
                          }

                      }

                      conn.Close();
                      ad.Dispose();
                      conn.Dispose();

                  }
              }
          }

          return ListContract;
      }

      public Contracts GetData(String parameter)
      {
          Contracts contracts = new Contracts();
          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              using (SqlCommand cmd = new SqlCommand("SELECT * FROM Contract WHERE " + parameter, conn))
              {
                  cmd.CommandType = CommandType.Text;
                  using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                  {
                      DataTable table = new DataTable();
                      conn.Open();
                      ad.Fill(table);

                      if (table.DefaultView.Count > 0)
                      {

                          for (int i = 0; i < table.Rows.Count; i++)
                          {
                              contracts.ContractID = new Guid(table.Rows[i]["ContractID"].ToString());
                              contracts.AgentID = new Guid(table.Rows[i]["AgentID"].ToString());
                              contracts.Seater = table.Rows[i]["Seater"].ToString();
                              contracts.BookingCode = table.Rows[i]["BookingCode"].ToString();
                              contracts.StartDate = Convert.ToDateTime(table.Rows[i]["StartDate"]);
                              contracts.StopDate = Convert.ToDateTime(table.Rows[i]["StopDate"]);
                              contracts.TripType = table.Rows[i]["TripType"].ToString();
                              contracts.TripFrom = table.Rows[i]["TripFrom"].ToString();
                              contracts.TripTo = table.Rows[i]["TripTo"].ToString();
                              contracts.InvoiceText = table.Rows[i]["InvoiceText"].ToString();
                              contracts.PersonInCharge = table.Rows[i]["PersonInCharge"].ToString();
                              contracts.Contact = table.Rows[i]["Contact"].ToString();
                              contracts.RatesType = table.Rows[i]["RatesType"].ToString();
                              contracts.Rates = Convert.ToDecimal(table.Rows[i]["Rates"].ToString());
                              contracts.Remarks1 = table.Rows[i]["Remarks1"].ToString();
                              contracts.Remarks2 = table.Rows[i]["Remarks2"].ToString();
                              contracts.DriverClaim = table.Rows[i]["DriverClaim"].ToString();
                              contracts.PONumber = table.Rows[i]["PONumber"].ToString();
                              contracts.Monday = (bool)table.Rows[i]["Mon"];
                              contracts.Tuesday = (bool)table.Rows[i]["Tue"];
                              contracts.Wednesday = (bool)table.Rows[i]["Wed"];
                              contracts.Thursday = (bool)table.Rows[i]["Thu"];
                              contracts.Friday = (bool)table.Rows[i]["Fri"];
                              contracts.Saturday = (bool)table.Rows[i]["Sat"];
                              contracts.Sunday = (bool)table.Rows[i]["Sun"];

                              contracts.StartMonday = table.Rows[i]["StartMon"].ToString();
                              contracts.StartTuesday = table.Rows[i]["StartTue"].ToString();
                              contracts.StartWednesday = table.Rows[i]["StartWed"].ToString();
                              contracts.StartThursday = table.Rows[i]["StartThu"].ToString();
                              contracts.StartFriday = table.Rows[i]["StartFri"].ToString();
                              contracts.StartSaturday = table.Rows[i]["StartSat"].ToString();
                              contracts.StartSunday = table.Rows[i]["StartSun"].ToString();

                              contracts.EndMonday = table.Rows[i]["EndMon"].ToString();
                              contracts.EndTuesday = table.Rows[i]["EndTue"].ToString();
                              contracts.EndWednesday = table.Rows[i]["EndWed"].ToString();
                              contracts.EndThursday = table.Rows[i]["EndThu"].ToString();
                              contracts.EndFriday = table.Rows[i]["EndFri"].ToString();
                              contracts.EndSaturday = table.Rows[i]["EndSat"].ToString();
                              contracts.EndSunday = table.Rows[i]["EndSun"].ToString();
                              contracts.ContractStartTime = table.Rows[i]["ContractStartTime"].ToString();
                              contracts.ContractEndTime = table.Rows[i]["ContractEndTime"].ToString();

                          }

                      }

                      conn.Close();
                      ad.Dispose();
                      conn.Dispose();

                  }
              }
          }

          return contracts;
      }

      public String UpdateData(INewBookEntity iBusinessEntity)
      {

          try
          {
              Contracts contracts = new Contracts();
              contracts = (Contracts)iBusinessEntity;

              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookContract", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {

                          command.Parameters.Add("@BookingCode", SqlDbType.NVarChar);
                          command.Parameters["@BookingCode"].Value = contracts.BookingCode;

                          command.Parameters.Add("@AgentID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@AgentID"].Value = contracts.AgentID;

                          command.Parameters.Add("@StartDate", SqlDbType.DateTime);
                          command.Parameters["@StartDate"].Value = contracts.StartDate;

                          command.Parameters.Add("@StopDate", SqlDbType.DateTime);
                          command.Parameters["@StopDate"].Value = contracts.StopDate;

                          command.Parameters.Add("@TripType", SqlDbType.NVarChar);
                          command.Parameters["@TripType"].Value = contracts.TripType;

                          command.Parameters.Add("@TripFrom", SqlDbType.NVarChar);
                          command.Parameters["@TripFrom"].Value = contracts.TripFrom;

                          command.Parameters.Add("@TripTo", SqlDbType.NVarChar);
                          command.Parameters["@TripTo"].Value = contracts.TripTo;

                          command.Parameters.Add("@Seater", SqlDbType.Int);
                          command.Parameters["@Seater"].Value = contracts.Seater;

                          command.Parameters.Add("@InvoiceText", SqlDbType.NVarChar);
                          command.Parameters["@InvoiceText"].Value = contracts.InvoiceText;

                          command.Parameters.Add("@PONumber", SqlDbType.NVarChar);
                          command.Parameters["@PONumber"].Value = contracts.PONumber;

                          command.Parameters.Add("@PersonInCharge", SqlDbType.NVarChar);
                          command.Parameters["@PersonInCharge"].Value = contracts.PersonInCharge;

                          command.Parameters.Add("@Contact", SqlDbType.NVarChar);
                          command.Parameters["@Contact"].Value = contracts.Contact;

                          command.Parameters.Add("@RatesType", SqlDbType.NVarChar);
                          command.Parameters["@RatesType"].Value = contracts.RatesType;

                          command.Parameters.Add("@Rates", SqlDbType.Money);
                          command.Parameters["@Rates"].Value = contracts.Rates;

                          command.Parameters.Add("@Remarks1", SqlDbType.NVarChar);
                          command.Parameters["@Remarks1"].Value = contracts.Remarks1;

                          command.Parameters.Add("@Remarks2", SqlDbType.NVarChar);
                          command.Parameters["@Remarks2"].Value = contracts.Remarks2;

                          command.Parameters.Add("@DriverClaim", SqlDbType.NVarChar);
                          command.Parameters["@DriverClaim"].Value = contracts.DriverClaim;

                          command.Parameters.Add("@Mon", SqlDbType.Bit);
                          command.Parameters["@Mon"].Value = contracts.Monday;

                          command.Parameters.Add("@Tue", SqlDbType.Bit);
                          command.Parameters["@Tue"].Value = contracts.Tuesday;

                          command.Parameters.Add("@Wed", SqlDbType.Bit);
                          command.Parameters["@Wed"].Value = contracts.Wednesday;

                          command.Parameters.Add("@Thu", SqlDbType.Bit);
                          command.Parameters["@Thu"].Value = contracts.Thursday;

                          command.Parameters.Add("@Fri", SqlDbType.Bit);
                          command.Parameters["@Fri"].Value = contracts.Friday;

                          command.Parameters.Add("@Sat", SqlDbType.Bit);
                          command.Parameters["@Sat"].Value = contracts.Saturday;

                          command.Parameters.Add("@Sun", SqlDbType.Bit);
                          command.Parameters["@Sun"].Value = contracts.Sunday;
                          

                          command.Parameters.Add("@StartMon", SqlDbType.NVarChar);
                          command.Parameters["@StartMon"].Value = contracts.StartMonday;

                          command.Parameters.Add("@StartTue", SqlDbType.NVarChar);
                          command.Parameters["@StartTue"].Value = contracts.StartTuesday;

                          command.Parameters.Add("@StartWed", SqlDbType.NVarChar);
                          command.Parameters["@StartWed"].Value = contracts.StartWednesday;

                          command.Parameters.Add("@StartThu", SqlDbType.NVarChar);
                          command.Parameters["@StartThu"].Value = contracts.StartThursday;

                          command.Parameters.Add("@StartFri", SqlDbType.NVarChar);
                          command.Parameters["@StartFri"].Value = contracts.StartFriday;

                          command.Parameters.Add("@StartSat", SqlDbType.NVarChar);
                          command.Parameters["@StartSat"].Value = contracts.StartSaturday;

                          command.Parameters.Add("@StartSun", SqlDbType.NVarChar);
                          command.Parameters["@StartSun"].Value = contracts.StartSunday;

                          command.Parameters.Add("@EndMon", SqlDbType.NVarChar);
                          command.Parameters["@EndMon"].Value = contracts.EndMonday;

                          command.Parameters.Add("@EndTue", SqlDbType.NVarChar);
                          command.Parameters["@EndTue"].Value = contracts.EndTuesday;

                          command.Parameters.Add("@EndWed", SqlDbType.NVarChar);
                          command.Parameters["@EndWed"].Value = contracts.EndWednesday;

                          command.Parameters.Add("@EndThu", SqlDbType.NVarChar);
                          command.Parameters["@EndThu"].Value = contracts.EndThursday;

                          command.Parameters.Add("@EndFri", SqlDbType.NVarChar);
                          command.Parameters["@EndFri"].Value = contracts.EndFriday;

                          command.Parameters.Add("@EndSat", SqlDbType.NVarChar);
                          command.Parameters["@EndSat"].Value = contracts.EndSaturday;

                          command.Parameters.Add("@EndSun", SqlDbType.NVarChar);
                          command.Parameters["@EndSun"].Value = contracts.EndSunday;

                          command.Parameters.Add("@UpdatedBy", SqlDbType.UniqueIdentifier);
                          command.Parameters["@UpdatedBy"].Value = contracts.UpdatedBy;

                          command.Parameters.Add("@ContractStartTime", SqlDbType.NVarChar);
                          command.Parameters["@ContractStartTime"].Value = contracts.ContractStartTime;

                          command.Parameters.Add("@ContractEndTime", SqlDbType.NVarChar);
                          command.Parameters["@ContractEndTime"].Value = contracts.ContractEndTime;

                          command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                          command.Parameters["@TransactionMode"].Value = 2;

                          command.Transaction = transaction;
                          command.ExecuteNonQuery();

                          transaction.Commit();
                      }
                  }

                  connection.Close();
              }

              return contracts.ContractID.ToString();
          }
          catch
          {

              return Woc.Book.Base.Constant.Constant.MessageUnSaved;
          }

      }


      public String DeleteContractSchedules(String contractID)
      {

          try
          {
              using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
              {
                  connection.Open();
                  using (SqlCommand command = new SqlCommand("usp_WocBookContractSchedule", connection))
                  {
                      command.CommandType = CommandType.StoredProcedure;


                      using (SqlTransaction transaction = connection.BeginTransaction())
                      {

                          command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                          command.Parameters["@TransactionMode"].Value = 2;

                          command.Parameters.Add("@ContractID", SqlDbType.UniqueIdentifier);
                          command.Parameters["@ContractID"].Value = contractID;

                          command.Transaction = transaction;
                          command.ExecuteNonQuery();

                          transaction.Commit();
                      }
                  }

                  connection.Close();
              }

              return Woc.Book.Base.Constant.Constant.MessageSaved;
          }
          catch
          {

              return Woc.Book.Base.Constant.Constant.MessageUnSaved;
          }

      }

    }

}
