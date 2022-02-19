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
        public int ID { get; set; }
        public int MyProperty { get; set; }
    }
}