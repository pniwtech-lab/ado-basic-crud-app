using ADONETWithSqlServerMVCApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ADONETWithSqlServerMVCApp.DBAccessLayer
{
    public class EmployeeInfoAccess
    {
        readonly SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DemoEmployeeDB"].ConnectionString);

        public bool Add_record(EmployeeInfo employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_employee_add", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@Name", employee.Name);
                com.Parameters.AddWithValue("@Address", employee.Address);
                com.Parameters.AddWithValue("@City", employee.City);
                com.Parameters.AddWithValue("@Pin_code", employee.Pin_code);
                com.Parameters.AddWithValue("@Designation", employee.Designation);

                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public bool Update_record(EmployeeInfo employee)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_employee_update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@Emp_id", employee.Emp_id);
                com.Parameters.AddWithValue("@Name", employee.Name);
                com.Parameters.AddWithValue("@Address", employee.Address);
                com.Parameters.AddWithValue("@City", employee.City);
                com.Parameters.AddWithValue("@Pin_code", employee.Pin_code);
                com.Parameters.AddWithValue("@Designation", employee.Designation);

                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        public EmployeeInfo Get_employee_by_id(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_employee_by_id", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@Emp_id", id);
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                EmployeeInfo employeeInfo = new EmployeeInfo();
                DataRow row = ds.Tables[0].Rows[0];

                // set values from DataSet.
                employeeInfo.Emp_id = Convert.ToInt32(row["Emp_id"].ToString());
                employeeInfo.Name = row["Name"].ToString();
                employeeInfo.Address = row["Address"].ToString();
                employeeInfo.City = row["City"].ToString();
                employeeInfo.Pin_code = Convert.ToInt32(row["Pin_code"].ToString());
                employeeInfo.Designation = row["Designation"].ToString();

                return employeeInfo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet Show_data()
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_employee_all", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (SqlException)
            {
                return null;
            }
        }

        public bool Delete_record(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_employee_delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                com.Parameters.AddWithValue("@Emp_id", id);
                conn.Open();
                com.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }
    }
}