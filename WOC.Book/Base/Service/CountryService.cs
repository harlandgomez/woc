using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Woc.Book.Base.Service
{
  public class CountryService
    {
      public DataTable GetCountryDropdownInfo()
      {
          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              using (SqlCommand cmd = new SqlCommand("Select CountryID,Country from Country ORDER BY SortOrder", conn))
              {
                  cmd.CommandType = CommandType.Text;
                  using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                  {
                      DataTable table = new DataTable();
                      conn.Open();
                      ad.Fill(table);
                      conn.Close();
                      ad.Dispose();
                      conn.Dispose();
                      return table;
                  }
              }
          }

      }

      public Guid GetDefaultCountryID(String SettingCode)
      {
          using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
          {
              using (SqlCommand cmd = new SqlCommand("Select CountryID from Country Where CountryCode = (Select Coalesce(Value, DefaultValue, 'SG') FROM Setting WHERE SettingCode = '"+ SettingCode +"') ", conn))
              {
                  cmd.CommandType = CommandType.Text;
                  
                  conn.Open();

                  return (Guid)cmd.ExecuteScalar();
              }
          }

      }
    }
}
