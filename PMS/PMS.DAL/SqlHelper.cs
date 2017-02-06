using PMS.Core.Constants;
using PMS.Core.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PMS.DAL
{
    public class SqlHelper
    {

        private static int defaultCommandTimeout = 340;

        #region "Public Methods"

        public static void ExecuteNonQuery(string storedProcedureName)
        {
            Exception thrownException = null;
            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, null, thrownException);
            }
        }

        public static string ExecuteScalar(string storedProcedureName, List<SqlParameter> inputParameters)
        {
            string returnData = string.Empty;
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    if (inputParameters != null)
                    {
                        foreach (SqlParameter prm in inputParameters)
                        {
                            cmd.Parameters.Add(prm);
                        }
                    }
                    returnData = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, inputParameters, thrownException);
            }
            return (returnData);
        }

        public static DataSet ExecuteSelectSql(string connString, string selectSql)
        {
            DataSet returnData = new DataSet();
            Exception thrownException = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = selectSql;
                    cmd.CommandTimeout = defaultCommandTimeout;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(returnData);
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.SQL, selectSql, null, thrownException);
            }
            return (returnData);
        }

        public static DataSet ExecuteSelectSql(string selectSql)
        {
            return ExecuteSelectSql(AppSettingHelper.GetConnectionString(), selectSql);
        }

        public static DataSet ExecuteStoredProcedure(string storedProcedureName)
        {
            DataSet returnData = new DataSet();
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName);
                    dataAdapter.Fill(returnData);
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, null, thrownException);
            }
            return (returnData);
        }

        public static DataSet ExecuteStoredProcedure(string storedProcedureName, string dataSetName)
        {
            DataSet returnData = new DataSet();
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    returnData.DataSetName = dataSetName;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    dataAdapter.Fill(returnData);
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, null, thrownException);
            }
            return (returnData);
        }

        public static object ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters, SqlDbType primaryKey)
        {
            int pkIndex;
            const string pk = "@PrimaryKey";
            object returnVal = null;
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    SqlParameter parameter;
                    parameter = new SqlParameter(pk, primaryKey);
                    parameter.Direction = ParameterDirection.ReturnValue;
                    parameters.Add(parameter);

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }
                    cmd.ExecuteNonQuery();

                    pkIndex = cmd.Parameters.IndexOf(pk);
                    if (pkIndex >= 0)
                    {
                        returnVal = cmd.Parameters[pkIndex].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                string msg = ex.Message;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
            return returnVal;
        }

        public static string ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters, string outputParmName
            , SqlDbType outputParmType, int Size = 0)
        {
            string returnVal = string.Empty;
            SqlParameter outputParm;
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }

                    if (Size == 0) outputParm = new SqlParameter("@" + outputParmName, outputParmType);
                    else outputParm = new SqlParameter("@" + outputParmName, outputParmType, Size);
                    outputParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParm);
                    cmd.ExecuteNonQuery();

                    returnVal = outputParm.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
            return returnVal;
        }


        public static DataSet ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters, string outputParmName, SqlDbType outputParmType, out string outValue, int Size = 0)
        {
            DataSet returnData = new DataSet();
            outValue = string.Empty;
            SqlParameter outputParm;
            Exception thrownException = null;

            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }

                    if (Size == 0) outputParm = new SqlParameter("@" + outputParmName, outputParmType);
                    else outputParm = new SqlParameter("@" + outputParmName, outputParmType, Size);
                    outputParm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(outputParm);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName);
                    dataAdapter.Fill(returnData);

                    outValue = outputParm.Value.ToString();
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
            return (returnData);
        }

        public static Boolean ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters)
        {
            int returnVal = 0;
            Exception thrownException = null;
            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }
                    WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters);
                    returnVal = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
            return returnVal > 0;
        }

        public static void ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters
            , int commandTimeoutInSeconds)
        {
            int returnVal = 0;
            Exception thrownException = null;
            try
            {
                string connString = AppSettingHelper.GetConnectionString();
                using (SqlConnection connection = new SqlConnection(connString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = commandTimeoutInSeconds;

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }
                    WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters);
                    returnVal = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
        }

        public static DataSet ExecuteStoredProcedure(string connectionString, string dbName, string storedProcedureName, List<SqlParameter> parameters,
            string dataSetName = null)
        {
            DataSet returnData = new DataSet();
            Exception thrownException = null;

            try
            {
                string conStr;
                if (!string.IsNullOrEmpty(connectionString)) conStr = connectionString;
                else conStr = AppSettingHelper.GetConnectionString(dbName);
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = storedProcedureName;
                    cmd.CommandTimeout = defaultCommandTimeout;

                    foreach (SqlParameter prm in parameters)
                    {
                        cmd.Parameters.Add(prm);
                    }

                    if (dataSetName != null) returnData.DataSetName = dataSetName;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters);
                    dataAdapter.Fill(returnData);
                }
            }
            catch (Exception ex)
            {
                thrownException = ex;
                throw ex;
            }
            finally
            {
                WriteExecutionInformation(DataAccessCallType.StoredProcedure, storedProcedureName, parameters, thrownException);
            }
            return (returnData);
        }

        public static DataSet ExecuteStoredProcedure(string dbName, string storedProcedureName, List<SqlParameter> parameters, string dataSetName)
        {
            DataSet returnVal;
            if (string.IsNullOrWhiteSpace(dataSetName))
            {
                returnVal = ExecuteStoredProcedure(string.Empty, dbName, storedProcedureName, parameters);
            }
            else
            {
                returnVal = ExecuteStoredProcedure(string.Empty, dbName, storedProcedureName, parameters, dataSetName);
            }
            return returnVal;
        }

        public static DataSet ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> parameters, string dataSetName)
        {
            return ExecuteStoredProcedure(string.Empty, storedProcedureName, parameters, dataSetName);
        }

        public static string GetEnvironment()
        {
            return AppSettingHelper.GetValue("Environment");
        }


        #endregion

        private static void WriteExecutionInformation(string dataAccessCallType, string itemName
            , List<SqlParameter> parameters = null, Exception exception = null)
        {
            if (AppSettingHelper.IsSqlLoggingEnable)
            {
                const string fileName = "DataAccessLog.txt";
                string assemblyPath = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
                string fullFileName = Path.Combine(assemblyPath, fileName);
                const string delimiter = "|";
                StringBuilder sb = new StringBuilder();
                System.IO.StreamWriter file = null;

                try
                {
                    if (!System.IO.File.Exists(fullFileName))
                    {
                        file = new System.IO.StreamWriter(fullFileName);
                        file.WriteLine("TimeStamp|Type|Name|Parameters[ParmName/ParmValue|]|Exception");
                    }
                    else
                    {
                        file = new System.IO.StreamWriter(fullFileName, true);
                    }
                    sb.Append(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss.fff tt"));
                    sb.Append(delimiter);
                    sb.Append(dataAccessCallType);
                    sb.Append(delimiter);
                    sb.Append(itemName);
                    if (parameters != null)
                    {
                        foreach (SqlParameter prm in parameters)
                        {
                            sb.Append(delimiter);
                            sb.Append(prm.ParameterName);
                            sb.Append(@"/");
                            sb.Append(prm.Value.ToString());
                        }
                    }
                    sb.Append(delimiter);
                    if (exception != null)
                    {
                        sb.Append(exception.Message);
                    }
                    file.WriteLine(sb.ToString());
                }
                catch
                {
                    // no action
                }
                finally
                {
                    if (file != null)
                    {
                        file.Close();
                    }
                }
            }
        }
    }

}