using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Celebio
{
    public class User
    {
        [Key, StringLength(50), Required]
        public string username { get; set; }

        [StringLength(255), Required]
        public string name {get; set;}

        [StringLength(255), Required]
        public string surname {get; set;}
        
        [Required, EmailAddress]
        public string email { get; set; }

        [Required]
        public int password { get; set; } //6 Digit Nubmer (pin)

        [StringLength(255)]
        public string bio { get; set; }

        [StringLength(10)]
        public string gender { get; set; }

        public int age { get; set; }

        [StringLength(255)]
        public string nationality { get; set; }

    }

}
