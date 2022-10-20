using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RestaurantManagement.DataAccessLayer
{
    public class DatabaseConnection
    {
        private const string connectionString = "Data Source=DESKTOP-2F9QKVJ\\TUYETVI;Initial Catalog=QuanLyNhaHang;User ID=sa;Password=0703";
        private SqlCommand sqlCommand;
        private SqlConnection connection;


        public DatabaseConnection()
        {
            connection = new SqlConnection(connectionString);
            sqlCommand = connection.CreateCommand();
        }
        
        private void InitSqlCommand(String cmd, CommandType commandType, params SqlParameter[] parameters)
        {
            sqlCommand.CommandText = cmd;
            sqlCommand.CommandType = commandType;

            sqlCommand.Parameters.Clear();
            if (parameters != null)
                foreach (SqlParameter param in parameters)
                    sqlCommand.Parameters.Add(param);
        }

        public bool MyExecuteNonQuery(String cmd, CommandType commandType, ref String error, params SqlParameter[] parameters)
        {
            try
            {
                connection.Open();

                InitSqlCommand(cmd, commandType, parameters);

                int rows = sqlCommand.ExecuteNonQuery();

                if (rows > 0)
                    return true;
            }
            catch (SqlException e)
            {
                error = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public object MyExecuteScalar(String cmd, CommandType commandType, ref String error, params SqlParameter[] parameters)
        {
            try
            {
                connection.Open();

                InitSqlCommand(cmd, commandType, parameters);

                return sqlCommand.ExecuteScalar();
            }
            catch (SqlException e)
            {
                error = e.Message;
            }
            finally
            {
                connection.Close();
            }
            return null;
        }

        public DataTable MyExecuteQueryDataTable(String cmd, CommandType commandType, ref String error, params SqlParameter[] parameters)
        {
            DataTable dataTable = new DataTable();

            try
            {
                connection.Open();

                InitSqlCommand(cmd, commandType, parameters);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
                dataAdapter.Fill(dataTable);
            }
            catch(SqlException e)
            {
                error = e.Message;
            }
            finally
            {
                connection.Close();
            }

            return dataTable;
        }
    }
}
