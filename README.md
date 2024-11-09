Scenario 3: Tourist Boat Management System
1. Identify and Create the Main Domain Classes
a. Boat: BoatID, BoatType (Speedboat, Yacht), MaxCapacity, FuelLevel,
RatePerPassenger (R150 per passenger).
b. Captain: CaptainID, Name, LicenseType, AssignedBoatID,
ExperiencePoints, Earnings.
c. Tour: TourID, BoatID, CaptainID, TourDate, PassengersCount, TourIncome,
IsCompleted, Rating.
2. Apply Data Annotations
a. Required fields, validation on fuel, and capacity constraints for passengers
(must be ≤ MaxCapacity).
3. Implement Business Logic Methods
a. AddExperiencePoints(): Add 150 points per completed tour.
b. CalcCaptainEarnings(): R400 per 1000 points.
c. CalcTourIncome(): Based on passenger count.
d. ApplyRatingAdjustment(): Deduct 3% of earnings for low ratings or add 70
points for high ratings.
4. ViewModel for Performance
a. Create a CaptainPerformanceViewModel that displays each captain’s
name, LicenseType, experience points, total earnings, and average tour
rating
