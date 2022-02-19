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
    public class AppoitmentDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultCon"].ToString();

        //Gel All Patients
        public List<Appoitment> GetAllPatients()
        {
            List<Appoitment> PatientsList = new List<Appoitment>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllPatientRecords";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                adapter.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    PatientsList.Add(new Appoitment
                    {
                        AppoitmentID = Convert.ToInt32(dr["AppoitmentID"]),
                        Date = (DateTime) dr["Date"],
                        BillAmount = Convert.ToInt32(dr["BillAmount"]),
                        Diease = dr["Diease"].ToString(),
                        Prescription = dr["Prescription"].ToString()
                    });
                }

            }
            return PatientsList;
        }

    }
}