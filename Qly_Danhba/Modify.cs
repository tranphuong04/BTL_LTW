using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Qly_Danhba
{
    class Modify
    {
        SqlDataAdapter dataAdapter; // truy xuất dữ liệu vào bảng
        SqlCommand sqlCommand; // truy vấn và cập nhật tới CSDL

        public Modify()
        {
        }

        public DataTable getAllInformation()
        {
            DataTable dataTable = new DataTable();
            string query = "select * from DANHBA";
            using (SqlConnection sqlConnection = Connection.getConnection())
            {
                sqlConnection.Open();
                dataAdapter = new SqlDataAdapter(query, sqlConnection);
                dataAdapter.Fill(dataTable);
                sqlConnection.Close();
            }
            return dataTable;
        }

        public bool insert(Information information)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "insert into DANHBA values (@MaDN, @SDT, @tenCq, @nguoiDaiDien, @ghiChu)";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaDN", SqlDbType.Char).Value = information.MaDN;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.Char).Value = information.PhoneNumber;
                sqlCommand.Parameters.Add("@tenCq", SqlDbType.NVarChar).Value = information.Name;
                sqlCommand.Parameters.Add("@nguoiDaiDien", SqlDbType.NVarChar).Value = information.Represent;
                sqlCommand.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = information.Note;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool update(Information information)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "update DANHBA set SDT = @SDT, tenCq = @tenCq, nguoiDaiDien = @nguoiDaiDien, ghiChu = @ghiChu Where MaDN = @MaDN";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaDN", SqlDbType.Char).Value = information.MaDN;
                sqlCommand.Parameters.Add("@SDT", SqlDbType.Char).Value = information.PhoneNumber;
                sqlCommand.Parameters.Add("@tenCq", SqlDbType.NVarChar).Value = information.Name;
                sqlCommand.Parameters.Add("@nguoiDaiDien", SqlDbType.NVarChar).Value = information.Represent;
                sqlCommand.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = information.Note;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }

        public bool delete(string MaDN)
        {
            SqlConnection sqlConnection = Connection.getConnection();
            string query = "delete DANHBA Where MaDN = @MaDN";
            try
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                sqlCommand.Parameters.Add("@MaDN", SqlDbType.Char).Value = MaDN;
                sqlCommand.ExecuteNonQuery();
            }
            catch
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
            return true;
        }
    }
}
