using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TouristBoatManagementTut15Apdb.Models
{
    public class TourContext : DbContext
    {
        public TourContext() : base("DefaultConnection") { }

        public DbSet<Captain> captains { get; set; }
        public DbSet<Tour> tours { get; set; }
        public DbSet<Boat> boats { get; set; }
        public DbSet<CaptainPerfomanceVIewModel>captainPerfomanceVIews { get; set; }
    }
}