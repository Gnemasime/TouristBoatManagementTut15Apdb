using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristBoatManagementTut15Apdb.Models
{
    public class CaptainPerfomanceVIewModel
    {
        [Key]
        public int CaptainViewId { get; set; }
        public string Name { get; set; }
        public string LicenseType {get;set;}
        public int ExperiencePoints { get; set; }
        public decimal TotalEarnings { get; set; }
        public int AverageTourRatings { get; set; }
    }
}