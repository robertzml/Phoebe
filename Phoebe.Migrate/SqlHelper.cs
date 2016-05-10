using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Phoebe.Migrate
{
    public class SqlHelper
    {
        #region Field
        private SqlConnection sourceConnection = new SqlConnection("data source=localhost;initial catalog=Phoebe;persist security info=True;user id=uphoebe;password=uphoebe123456;");

        private SqlConnection destinationConnection = new SqlConnection("data source=localhost;initial catalog=Phoebe3;persist security info=True;user id=uphoebe;password=uphoebe123456;");
        #endregion //Field

        #region Method

        public DataTable Read(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, sourceConnection);
            adapter.Fill(dt);

            return dt;
        }

        public string Insert(List<string> sql)
        {
            try
            {
                destinationConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = destinationConnection;
                foreach(var item in sql)
                {
                    command.CommandText = item;
                    command.ExecuteNonQuery();
                }               
            }
            catch (Exception e)
            {
                return e.Message;
            }
            finally
            {
                destinationConnection.Close();
            }

            return "ok";
        }

        public string Delete(string sql)
        {
            try
            {
                SqlCommand command = new SqlCommand(sql, destinationConnection);
                destinationConnection.Open();
                command.ExecuteNonQuery();
                destinationConnection.Close();
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "ok";
        }
        #endregion //Method
    }
}
