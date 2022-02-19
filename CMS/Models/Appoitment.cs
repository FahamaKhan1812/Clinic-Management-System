using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Appoitment
    {   
        [Key]
        public int AppointID { get; set; }
        
        //From Patient table
        public string PatientName { get; set; }
        public int PatientAge { get; set; }
        public string PatientGender { get; set; }
        
        //From Doctor table
        public string DoctorName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BillAmount { get; set; }
        
        [Required]
        public string Disease { get; set; }

        [Required]
        public string Prescription { get; set; }
    }
}