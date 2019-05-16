using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Celebio
{
    public class Traveller
    {
        [Key]
        public int travellerID { get; set; }

        public bool isAccepted { get; set; }

        public string appliedUser { get; set; }
        [ForeignKey("appliedUser")]
        public User traveller { get; set; }

        public int appliedTripID { get; set; }
        [ForeignKey("appliedTripID")]
        public Trip appliedTrip { get; set; }
    }
}
