using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristBoatManagementTut15Apdb.Models
{
    public class Captain
    {
        [Key]
        public int CaptainId { get; set; }
        public string Name { get; set; }
        public string LicenseType { get; set; }
        public int AssignedBoatId { get; set; }
        public int ExperiencePoints { get; set; }
        public decimal Earnings { get; set; }
    }
}