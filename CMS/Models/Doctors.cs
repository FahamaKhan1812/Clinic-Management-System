using CMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Doctors
    {
        [Key]
        public int DoctorID { get; set; }
        public string DoctorName { get; set; }

        public List<Doctors> GetDoctors()
        {
            List<Doctors> doctor = new DoctorDAL().GetAllDoctors();
            return doctor;
        }
    }
}