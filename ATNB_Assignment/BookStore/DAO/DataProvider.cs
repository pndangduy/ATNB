using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DAO
{
    public class DataProvider
    {
        #region Avariable

        private static DataProvider instance;

        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            set { instance = value; }
        }

        private SqlConnection objConnect;
        private SqlCommand objCommand;
        private SqlDataAdapter da;
        private DataTable dt;
        #endregion

        /// <summary>
        /// Constructor to input string SQL connect
        /// </summary>
        public DataProvider()
        {
            string connect = @"Data Source=DELL\SQLEXPRESS;Initial Catalog=BookManagement;Integrated Security=True";

            objConnect = new SqlConnection(connect);
        }

        #region Method
        /// <summary>
        /// Open connect 
        /// </summary>
        private void OpenConnect(ref string error)
        {
            try
            {
                if (objConnect.State == ConnectionState.Open)
                    objConnect.Close();
                objConnect.Open();
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

        /// <summary>
        /// Store produce to fill data to datable
        /// </summary>
        /// <param name="sProduceName">Query proc</param>
        /// <returns>Datable contain data</returns>
        public DataTable StoreProduceDataTable(string sProduceName, ref string error, params SqlParameter[] param)
        {
            dt = new DataTable();
            try
            {
                OpenConnect(ref error);
                objCommand = new SqlCommand(sProduceName, objConnect) { CommandType = CommandType.StoredProcedure };

                if (param != null)
                {
                    objCommand.Parameters.Clear();
                    foreach (SqlParameter p in param)
                        objCommand.Parameters.Add(p);
                }


                da = new SqlDataAdapter(objCommand);
                da.Fill(dt);
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                objConnect.Close();
                objCommand.Dispose();
            }
            return dt;
        }

        /// <summary>
        /// Store produce execute query
        /// </summary>
        /// <param name="sProduceName">Query proc</param>
        /// <param name="param">Input params</param>
        /// <returns>True : execute is success. False : execute isn't success</returns>
        public bool QueryStoreProduce(string sProduceName, ref string error, params SqlParameter[] param)
        {
            try
            {
                OpenConnect(ref error);
                objCommand = new SqlCommand(sProduceName, objConnect) { CommandType = CommandType.StoredProcedure };
                objCommand.Parameters.Clear();
                foreach (SqlParameter p in param)
                    objCommand.Parameters.Add(p);
                objCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return false;
            }
            finally
            {
                objConnect.Close();
            }
            return true;
        }
        #endregion
    }

}
