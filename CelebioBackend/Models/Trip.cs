using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Celebio
{
    public class Trip
    {
        [Key]
        public int tripID { get; set; }

        [Required, StringLength(255)]
        public string from { get; set; }

        [Required, StringLength(255)]
        public string to { get; set; }

        [Required, StringLength(10)]
        public string vehicle { get; set; }

        [Required]
        public DateTime time { get; set; }

        public bool isOpen { get; set; }

        [Required]
        public string creatorID { get; set; }

        [ForeignKey("creatorID")]
        public User tripCreator { get; set; }

    }
}
