using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristBoatManagementTut15Apdb.Models
{
    public class Boat
    {
        [Key]
        public int BoatId { get; set; }
        public string BoatType { get; set; }
      //  public int AssignedBoatId { get; set; }
        public int MaxCapacity { get; set; }
        public decimal FuelLevel { get; set; }
        public decimal RatePerPassenger { get; set; } = 150;
    }
}