using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class DbInitializer
    {
        public static void Initialize(RentalContext rent, EquipmentContext equip)
        {
            if(rent.Rentals.Any() || equip.Equipments.Any() )
            {
                return; // DB has already been seeded
            }

            var rentals = new Rental[]
            {
                new Rental{FirstName="Sydney", LastName="Berry", PhoneNumber="1234567890", DateFor=DateTime.Parse("2020-09-01")},
                new Rental{FirstName="Jenny", LastName="Nguyen", PhoneNumber="1234567890", DateFor=DateTime.Parse("2021-11-01")},
                new Rental{FirstName="Noah", LastName="Fence", PhoneNumber="1234567890", DateFor=DateTime.Parse("2021-02-09")}
            };
            rent.Rentals.AddRange(rentals);
            rent.SaveChanges();

            var equipments = new Equipment[]
            {
                new Equipment{EquipmentName="Soccer Ball", Description="Used for kicking", Quantity=6},
                new Equipment{EquipmentName="Football", Description="yaaaay sports", Quantity=4},
                new Equipment{EquipmentName="Stopwatch", Description="Typically used for workouts or track & field training", Quantity=3}
            };
            equip.Equipments.AddRange(equipments);
            equip.SaveChanges();

            // need to add start and end times
            /*var reservations = new Reservation[]
            {
                new Reservation{FirstName="Sydney", LastName="Berry", PhoneNumber=1234567891},
                new Reservation{FirstName="Jenny", LastName="Nguyen", PhoneNumber=1434562891},
                new Reservation{FirstName="Noah", LastName="Fence", PhoneNumber=1432562891}
            };
            reserve.Reservations.AddRange(reservations);
            reserve.SaveChanges();

            

            var tournaments = new Tournament[]
            {
                new Tournament{DateFor=DateTime.Parse("2021-05-01"), ActivityType=Activity.SOCCER, Description="10 team limit"},
                new Tournament{DateFor=DateTime.Parse("2022-05-01"), ActivityType=Activity.CRICKET, Description="10 team limit"}

            };
            tourn.Tournaments.AddRange(tournaments);
            tourn.SaveChanges();*/
        }
    }
}
