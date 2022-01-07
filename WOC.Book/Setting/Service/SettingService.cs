using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

//WOC
using Woc.Book.Base.Service;
using Woc.Book.Setting.BusinessEntity;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Setting.Constant;

namespace Woc.Book.Setting.Service
{
    public class SettingService
    {
        public String GetSettingValue(String settingCode)
        {
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("usp_WocBookSetting", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SettingCode", settingCode);
                    cmd.Parameters.AddWithValue("@TransactionMode", 1);
                    cmd.Connection.Open();

                    String settingValue = cmd.ExecuteScalar().ToString();
                    conn.Close();

                    conn.Dispose();

                    return settingValue;
                }
            }

        }

        public String SaveData(IAdminEntity iAdminEntity)
        {

            try
            {
                Settings settings = new Settings();
                settings = (Settings)iAdminEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookSetting", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@SettingCode", SqlDbType.NVarChar);
                            command.Parameters["@SettingCode"].Value = settings.SettingCode;

                            command.Parameters.Add("@Value", SqlDbType.NVarChar);
                            command.Parameters["@Value"].Value = settings.Value;

                            command.Parameters.Add("@DefaultValue", SqlDbType.NVarChar);
                            command.Parameters["@DefaultValue"].Value = settings.DefaultValue;

                            command.Parameters.Add("@Description", SqlDbType.NVarChar);
                            command.Parameters["@Description"].Value = settings.Description;

                            command.Parameters.Add("@LocaleAware", SqlDbType.Bit);
                            command.Parameters["@LocaleAware"].Value = settings.LocaleAware;

                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 3;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return Constant.Constant.MessageSaved;
            }
            catch
            {

                return Constant.Constant.MessageUnSaved;
            }

        }

        public List<Settings> SearchData(String parameter)
        {
            Settings settings = new Settings();
            List<Settings> listSetting = new List<Settings>();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Setting where " + parameter, conn))
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
                                settings.SettingID = new Guid(table.Rows[i]["SettingID"].ToString());
                                settings.SettingCode = table.Rows[i]["SettingCode"].ToString();
                                settings.Value = table.Rows[i]["Value"].ToString();
                                settings.Description = table.Rows[i]["Description"].ToString();
                                settings.DefaultValue = table.Rows[i]["DefaultValue"].ToString();
                                listSetting.Add(settings);
                                settings = new Settings();
                            }

                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return listSetting;
        }

        public Settings GetData(String parameter)
        {
            Settings settings = new Settings();
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from Setting where " + parameter, conn))
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
                                settings.SettingID = new Guid(table.Rows[i]["SettingID"].ToString());
                                settings.SettingCode = table.Rows[i]["SettingCode"].ToString();
                                settings.Value = table.Rows[i]["Value"].ToString();
                                settings.Description = table.Rows[i]["Description"].ToString();
                                settings.DefaultValue = table.Rows[i]["DefaultValue"].ToString();
                            }

                        }

                        conn.Close();
                        ad.Dispose();
                        conn.Dispose();

                    }
                }
            }

            return settings;
        }

        public String UpdateData(IAdminEntity iAdminEntity)
        {

            try
            {
                Settings settings = new Settings();
                settings = (Settings)iAdminEntity;
                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookSetting", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {

                            command.Parameters.Add("@SettingCode", SqlDbType.NVarChar);
                            command.Parameters["@SettingCode"].Value = settings.SettingCode;

                            command.Parameters.Add("@Value", SqlDbType.NVarChar);
                            command.Parameters["@Value"].Value = settings.Value;

                            command.Parameters.Add("@DefaultValue", SqlDbType.NVarChar);
                            command.Parameters["@DefaultValue"].Value = settings.DefaultValue;

                            command.Parameters.Add("@Description", SqlDbType.NVarChar);
                            command.Parameters["@Description"].Value = settings.Description;

                            command.Parameters.Add("@LocaleAware", SqlDbType.Bit);
                            command.Parameters["@LocaleAware"].Value = settings.LocaleAware;

                            command.Parameters.Add("@TransactionMode", SqlDbType.Int);
                            command.Parameters["@TransactionMode"].Value = 4;

                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                        }
                    }

                    connection.Close();
                }

                return Constant.Constant.MessageSaved;
            }
            catch
            {

                return Constant.Constant.MessageUnSaved;
            }

        }
    }
}
