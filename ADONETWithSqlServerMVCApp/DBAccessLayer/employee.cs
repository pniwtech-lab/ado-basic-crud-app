using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ADONETWithSqlServerMVCApp.Models;

/**
 * This is used for Dummy page which is directly get data from database.
 */

namespace ADONETWithSqlServerMVCApp.DBAccessLayer
{
    public class Employee
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["DemoEmployeeDB"].ConnectionString;

        public List<EmployeeAccessLayer> GetData() 
        {
            List<EmployeeAccessLayer> li = new List<EmployeeAccessLayer>();

            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("sp_getdata", conn);
                conn.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeAccessLayer emp = new EmployeeAccessLayer();
                    emp.Emp_id = rdr.GetInt32(0);
                    emp.First_name = rdr.GetString(1);
                    emp.Last_name = rdr.GetString(2);
                    emp.Birth_day = rdr.GetValue(3).ToString();
                    emp.Salary = Convert.ToDouble(rdr.GetValue(4).ToString());

                    li.Add(emp);
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return li;
            
        }
    }
}