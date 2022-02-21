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

        //Gel All PatientRecords
        public List<Appoitment> GElAllRecords()
        {
            List<Appoitment> AppoitmentRecords = new List<Appoitment>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "GetAllPatientRecords";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtRecords = new DataTable();
                connection.Open();
                adapter.Fill(dtRecords);
                connection.Close();

                foreach (DataRow dr in dtRecords.Rows)
                {
                    AppoitmentRecords.Add(new Appoitment
                    {
                        AppointID = Convert.ToInt32(dr["AppointID"]),
                        PatientName = dr["PatientName"].ToString(),
                        PatientAge = Convert.ToInt32(dr["PatientAge"]),
                        PatientGender = dr["PatientGender"].ToString(),
                        DoctorName = dr["DoctorName"].ToString(),
                        Date = (DateTime) dr["Date"],
                        BillAmount = Convert.ToInt32(dr["BillAmount"])
                    });
                }

            }
            return AppoitmentRecords;
        }

    }
}