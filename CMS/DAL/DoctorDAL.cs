using CMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CMS.DAL
{
    public class DoctorDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultCon"].ToString();

        //Gel All Doctors
        public List<Doctors> GetAllDoctors()
        {
            List<Doctors> DoctorsList = new List<Doctors>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllDoctors";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                adapter.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    DoctorsList.Add(new Doctors
                    {
                        DoctorID = Convert.ToInt32(dr["DoctorID"]),
                        DoctorName = dr["DoctorName"].ToString()
                    });
                }

            }
            return DoctorsList;
        }
    }
}