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
        public int AppoitmentID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int BillAmount { get; set; }
        
        [Required]
        public string Diease { get; set; }

        [Required]
        public string Prescription { get; set; }
    }
}