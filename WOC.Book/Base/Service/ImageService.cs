using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// # End of Default 
using System.Data.SqlClient;
using System.Data;
using Woc.Book.Base.Service;
using Woc.Book.Base.BusinessEntity;
using Woc.Book.Base.Constant;
namespace Woc.Book.Base.Service
{
    public class ImageService
    {
        public DataTable GetImage(Guid companyID)
        {
            
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookImage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", companyID);
                    cmd.Parameters.AddWithValue("@QueryTypeID", 2);
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

        public byte[] GetImageBinary(Guid companyID)
        {
            using (SqlConnection conn = new SqlConnection(UtilityService.Connection()))
            {
                using (SqlCommand cmd = new SqlCommand("usp_WocBookImage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", companyID);
                    cmd.Parameters.AddWithValue("@QueryTypeID", 3);
                    conn.Open();

                    byte[] image = (byte[])cmd.ExecuteScalar();

                    conn.Close();
                    conn.Dispose();
                    return image;
                }
            }

        }

        public String SaveImage(IBusinessEntity iBusinessEntity)
        {
            Images images = new Images();
            images = (Images)iBusinessEntity;

            try
            {

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookImage", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            command.Parameters.Add("@FileName", SqlDbType.NVarChar, 200);
                            command.Parameters["@FileName"].Value = images.FileName;

                            command.Parameters.Add("@ImageFile", SqlDbType.Image);
                            command.Parameters["@ImageFile"].Value = images.ImageFile;

                            command.Parameters.Add("@ContentType", SqlDbType.NVarChar, 200);
                            command.Parameters["@ContentType"].Value = images.ContentType;

                            command.Parameters.Add("@FileSize", SqlDbType.Int);
                            command.Parameters["@FileSize"].Value = images.Filesize;

                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = images.CompanyID;

                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 1;

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

        public String UpdateImage(IBusinessEntity iBusinessEntity)
        {
            Images images = new Images();
            images = (Images)iBusinessEntity;

            try
            {

                using (SqlConnection connection = new SqlConnection(UtilityService.Connection()))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("usp_WocBookImage", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            command.Parameters.Add("@FileName", SqlDbType.NVarChar, 200);
                            command.Parameters["@FileName"].Value = images.FileName;

                            command.Parameters.Add("@ImageFile", SqlDbType.Image);
                            command.Parameters["@ImageFile"].Value = images.ImageFile;

                            command.Parameters.Add("@ContentType", SqlDbType.NVarChar, 200);
                            command.Parameters["@ContentType"].Value = images.ContentType;

                            command.Parameters.Add("@FileSize", SqlDbType.Int);
                            command.Parameters["@FileSize"].Value = images.Filesize;

                            command.Parameters.Add("@CompanyID", SqlDbType.UniqueIdentifier);
                            command.Parameters["@CompanyID"].Value = images.CompanyID;

                            command.Parameters.Add("@QueryTypeID", SqlDbType.Int);
                            command.Parameters["@QueryTypeID"].Value = 4;

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
