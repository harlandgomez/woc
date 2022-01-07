<%@ WebService Language="C#" Class="ComboboxDataPrefixCode" %>
using System;
using System.Collections.Generic;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Woc.Book.Base.Service;
using System.Web.Script.Services;
using System.Web.Services;
using Telerik.Web.UI;

[ScriptService]
public class ComboboxDataPrefixCode : System.Web.Services.WebService
{
    [WebMethod]
    public RadComboBoxItemData[] GetPrefixCode(RadComboBoxContext context)
    {
        string sql;
        using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
        {
            sql = "Select Distinct PrefixName, PrefixCode FROM CompanyPrefix";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                {
                    DataTable table = new DataTable();
                    conn.Open();
                    ad.Fill(table);

                    List<RadComboBoxItemData> result = new List<RadComboBoxItemData>(table.Rows.Count);

                    if (table.DefaultView.Count > 0)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            RadComboBoxItemData item = new RadComboBoxItemData();
                            item.Text = row["PrefixName"].ToString();
                            item.Value = row["PrefixCode"].ToString();
                            result.Add(item);

                        }

                    }

                    conn.Close();
                    ad.Dispose();
                    conn.Dispose();

                    return result.ToArray();
                }
            }
        }

    }
}

