using CMS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CMS.DAL
{
    public class PatientDAL
    {
        string conString = ConfigurationManager.ConnectionStrings["DefaultCon"].ToString();
        
        //Gel All Patients
        public List<Patients> GetAllPatients()
        {
            List<Patients> PatientsList = new List<Patients>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllPatients";
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                adapter.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    PatientsList.Add(new Patients
                    {
                        PatientID = Convert.ToInt32(dr["PatientID"]),
                        PatientName = dr["PatientName"].ToString(),
                        PatientAddress = dr["PatientAddress"].ToString(),
                        PatientAge = Convert.ToInt32(dr["PatientAge"]),
                        PatientGender = dr["PatientGender"].ToString(),
                        PatientPhone = Convert.ToInt32(dr["PatientPhone"])
                    });
                }

            }
            return PatientsList;
        }

        //Create a new Patient
        public bool InsertPatient(Patients patient)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertPatients", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                command.Parameters.AddWithValue("@PatientAddress", patient.PatientAddress);
                command.Parameters.AddWithValue("@PatientAge", patient.PatientAge);
                command.Parameters.AddWithValue("@PatientGender", patient.PatientGender);
                command.Parameters.AddWithValue("@PatientPhone", patient.PatientPhone);

                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Get a Patient By ID
        public List<Patients> GetPatientByID(int id)
        {
            List<Patients> PatientsList = new List<Patients>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetPatientID";
                command.Parameters.AddWithValue("@PatientID", id);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dtProducts = new DataTable();
                connection.Open();
                adapter.Fill(dtProducts);
                connection.Close();

                foreach (DataRow dr in dtProducts.Rows)
                {
                    PatientsList.Add(new Patients
                    {
                        PatientID = Convert.ToInt32(dr["PatientID"]),
                        PatientName = dr["PatientName"].ToString(),
                        PatientAddress = dr["PatientAddress"].ToString(),
                        PatientAge = Convert.ToInt32(dr["PatientAge"]),
                        PatientGender = dr["PatientGender"].ToString(),
                        PatientPhone = Convert.ToInt32(dr["PatientPhone"])
                    });
                }

            }
            return PatientsList;
        }

        //Update a Patient
        public bool UpdatePatient(Patients patient)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("UpdatePatient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientID", patient.PatientID);
                command.Parameters.AddWithValue("@PatientName", patient.PatientName);
                command.Parameters.AddWithValue("@PatientAddress", patient.PatientAddress);
                command.Parameters.AddWithValue("@PatientAge", patient.PatientAge);
                command.Parameters.AddWithValue("@PatientGender", patient.PatientGender);
                command.Parameters.AddWithValue("@PatientPhone", patient.PatientPhone);

                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete a Patient
        public string DeletePatient(int id)
        {
            string result = "";
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_DeletePatient", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@PatientID", id);
                command.Parameters.Add("@ReturnMessage", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

                connection.Open();
                command.ExecuteNonQuery();
                result = command.Parameters["@ReturnMessage"].Value.ToString();
                connection.Close();  
            }
            return result;
        }      
    
    }
}