using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BITS_Project.Models;

namespace BITS_Project.Data
{
    public class DbInitializer
    {
        public static void Initialize(BitsContext context)
        {
            if(context.Rentals.Any())
            {
                return; // DB has already been seeded
            }

            var rentals = new Rental[]
            {
                new Rental{FirstName="Sydney", LastName="Berry", PhoneNumber="1234567890", DateFor=DateTime.Parse("2020-09-01")},
                new Rental{FirstName="Jenny", LastName="Nguyen", PhoneNumber="1234567890", DateFor=DateTime.Parse("2021-11-01")},
                new Rental{FirstName="Noah", LastName="Fence", PhoneNumber="1234567890", DateFor=DateTime.Parse("2021-02-09")}
            };
            context.Rentals.AddRange(rentals);
            context.SaveChanges();

            var equipments = new Equipment[]
            {
                new Equipment{EquipmentName="Soccer Ball", Description="Used for kicking", Quantity=6},
                new Equipment{EquipmentName="Football", Description="yaaaay sports", Quantity=4},
                new Equipment{EquipmentName="Stopwatch", Description="Typically used for workouts or track & field training", Quantity=3}
            };

            context.Equipments.AddRange(equipments);
            context.SaveChanges();

            // need to add start and end times
            /*var reservations = new Reservation[]
            {
                new Reservation{FirstName="Sydney", LastName="Berry", PhoneNumber=1234567891},
                new Reservation{FirstName="Jenny", LastName="Nguyen", PhoneNumber=1434562891},
                new Reservation{FirstName="Noah", LastName="Fence", PhoneNumber=1432562891}
            };
            reserve.Reservations.AddRange(reservations);
            reserve.SaveChanges();
            */
            

            var tournaments = new Tournament[]
            {
                new Tournament{DateFor=DateTime.Parse("2021-05-01"), ActivityType=Activity.SOCCER, MaxTeams=10, MaxTeamSize=5, MinTeamSize=5},
                new Tournament{DateFor=DateTime.Parse("2022-05-01"), ActivityType=Activity.CRICKET, Description="10 team limit"}

            };
            context.Tournaments.AddRange(tournaments);
            context.SaveChanges();
        }
    }
}
