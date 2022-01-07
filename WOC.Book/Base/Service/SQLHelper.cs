using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Woc.Book.Base.Service
{
    //*************************************

    public class SQLHelper
    {
        private string _connectionString;
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;
        private int _commandTimeOut = 30;

        public enum ExpectedType
        {

            StringType = 0,
            NumberType = 1,
            DateType = 2,
            BooleanType = 3,
            ImageType = 4
        }

        public SQLHelper()
        {
            try
            {

                _connectionString = UtilityService.Connection();

                _sqlConnection = new SqlConnection(_connectionString);
                _sqlCommand = new SqlCommand();
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.Connection = _sqlConnection;

                //ParseConnectionString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing data class." + Environment.NewLine + ex.Message);
            }
        }

        public void Dispose()
        {
            try
            {
                //Clean Up Connection Object
                if (_sqlConnection != null)
                {
                    if (_sqlConnection.State != ConnectionState.Closed)
                    {
                        _sqlConnection.Close();
                    }
                    _sqlConnection.Dispose();
                }

                //Clean Up Command Object
                if (_sqlCommand != null)
                {
                    _sqlCommand.Dispose();
                }

            }

            catch (Exception ex)
            {
                throw new Exception("Error disposing data class." + Environment.NewLine + ex.Message);
            }

        }

        public void CloseConnection()
        {
            if (_sqlConnection.State != ConnectionState.Closed) _sqlConnection.Close();
        }
        public object GetExecuteScalarByCommand(string Command)
        {

            object returnValue = 0;
            try
            {
                _sqlCommand.CommandText = Command;
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlConnection.Open();

                _sqlCommand.Connection = _sqlConnection;
                returnValue = _sqlCommand.ExecuteScalar();
                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
            return returnValue;
        }

        public object GetExecuteScalarBySQL(string strSQL)
        {
            _sqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, _sqlConnection);
                return myCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public void GetExecuteNonQueryByCommand(string Command)
        {
            try
            {
                _sqlCommand.CommandText = Command;
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlConnection.Open();

                _sqlCommand.Connection = _sqlConnection;
                _sqlCommand.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public void GetExecuteNonQueryBySQL(string sql)
        {
            try
            {
                _sqlCommand.CommandText = sql;
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.CommandType = CommandType.Text;

                _sqlConnection.Open();

                _sqlCommand.Connection = _sqlConnection;
                _sqlCommand.ExecuteNonQuery();

                CloseConnection();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public DataSet GetDatasetByCommand(string Command)
        {
            try
            {
                _sqlCommand.CommandText = Command;
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(_sqlCommand);
                DataSet ds = new DataSet();
                adpt.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetDataTableByCommand(string Command)
        {
            try
            {
                _sqlCommand.CommandText = Command;
                _sqlCommand.CommandTimeout = _commandTimeOut;
                _sqlCommand.CommandType = CommandType.StoredProcedure;

                _sqlConnection.Open();

                SqlDataAdapter adpt = new SqlDataAdapter(_sqlCommand);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlDataReader GetReaderBySQL(string strSQL)
        {
            _sqlConnection.Open();
            try
            {
                SqlCommand myCommand = new SqlCommand(strSQL, _sqlConnection);
                return myCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }
        }

        public SqlDataReader GetReaderByCmd(string Command)
        {
            SqlDataReader objSqlDataReader = null;
            try
            {
                _sqlCommand.CommandText = Command;
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.CommandTimeout = _commandTimeOut;

                _sqlConnection.Open();
                _sqlCommand.Connection = _sqlConnection;

                objSqlDataReader = _sqlCommand.ExecuteReader();
                return objSqlDataReader;
            }
            catch (Exception ex)
            {
                CloseConnection();
                throw ex;
            }

        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType)
        {
            try
            {
                _sqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommand(string ParameterName, SqlDbType ParameterType, int ParameterSize)
        {
            try
            {
                _sqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterType, ParameterSize));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddParameterToSQLCommandWithValue(string ParameterName, object ParameterValue)
        {
            try
            {
                _sqlCommand.Parameters.Add(new SqlParameter(ParameterName, ParameterValue));
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SetSQLCommandParameterValue(string ParameterName, object Value)
        {
            try
            {
                _sqlCommand.Parameters[ParameterName].Value = Value;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    //*************************************

}
