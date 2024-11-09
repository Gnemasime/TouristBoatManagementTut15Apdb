using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristBoatManagementTut15Apdb.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }
        public int BoatId { get; set; }
        public int CaptainId { get; set; }
        public DateTime TourDate { get; set; }
        public int PassengerCount { get; set; }
        public decimal TourIncome { get; set; }
        public bool IsCompleted { get; set; }
        public int Rating { get; set; }

        //ForeignKey Relationship
        public virtual Boat Boat { get; set; }
        public virtual Captain Captain { get; set; }


        // Add experience points for every tour
        public void AddExperiencePoints()
        {
            TourContext db = new TourContext();
            Captain captain = (from c in db.captains
                               where c.CaptainId == CaptainId
                               select c).FirstOrDefault();

            captain.ExperiencePoints += 150; // captain.ExperientePoints + 150;
            db.SaveChanges();
        }

        TourContext db = new TourContext();

        //method to pull experience points
        public int PullEXperiencePoints()
        {
            var points = (from p in db.captains
                          where p.CaptainId == CaptainId
                          select p.ExperiencePoints).FirstOrDefault();
            return points;
        }

        //method to calculate captain earnings 
        public decimal CalcCaptainEarnings()
        {
            if(PullEXperiencePoints() >=1000)
            {
                return (PullEXperiencePoints() / 1000) * 400;
            }
            else
            {
                return 0;
            }
        }

        //method to pull rate per passenger
        public decimal PullRatePerPassenger()
        {
            var rate = (from r in db.boats
                        where r.BoatId == BoatId
                        select r.RatePerPassenger).FirstOrDefault();
            return rate;
        }

        //method to calculate tour income based on passenger
        public decimal CalcTourIncome()
        {
            return PassengerCount * PullRatePerPassenger();
        }

        //method for ratings adjustment (bonus)
        public void ApplyRatingBonus()
        {
            TourContext db = new TourContext();
            Captain captain = (from c in db.captains
                               where c.CaptainId == CaptainId
                               select c).FirstOrDefault();

            //bonus for high ratings
            if(Rating > 3 && Rating <= 5)
            {
                captain.ExperiencePoints += 70;
                db.SaveChanges();
            }
           
        }

        //method for rating adjusments (penalty)
        public decimal ApplyRatingPenlty()
        {
            if(Rating >= 1 && Rating <3)
            {
                return CalcCaptainEarnings() - (CalcCaptainEarnings() * (3 / 100.0m));
            }
            else
            {
                return 0;
            }
        }
    } 
}