using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.Service;

namespace Woc.Book.Base.Service
{
    public class SequenceService
    {
        public String GetNextSequence(String columnCode)
        {

            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {

                using (SqlCommand cmd = new SqlCommand("usp_WocBookSequence", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ColumnCode", columnCode);
                    cmd.Parameters.AddWithValue("@QueryTypeID", 1);
                    cmd.Connection.Open();

                    String nextSequence = cmd.ExecuteScalar().ToString();
                    conn.Close();

                    conn.Dispose();

                    return nextSequence;

                }
            }
        }
    }
}
