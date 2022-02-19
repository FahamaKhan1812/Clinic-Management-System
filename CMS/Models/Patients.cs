using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CMS.Models
{
    public class Patients
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        public string PatientName { get; set; }

        [Required]
        public string PatientAddress { get; set; }
        
        [Required]
        public int PatientAge { get; set; }
        
        [Required]
        public string PatientGender { get; set; }
        
        [Required]
        public int PatientPhone { get; set; }
    }
}