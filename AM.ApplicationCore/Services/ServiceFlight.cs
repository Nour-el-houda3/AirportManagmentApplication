using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<DateTime> GetFlightDate(string destination)
        {
            List<DateTime> result = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination==destination)
            //    {
            //        result.Add(Flights[i].FlightDate);
            //    }
            //}
            //return result;


            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        result.Add(flight.FlightDate);
            //    }

            //}
            //return result;
            IEnumerable<DateTime>queryLambda = Flights.Where(f => f.Destination == destination)
                .Select(f=>f.FlightDate);
            return queryLambda;

            IEnumerable<DateTime> query = from f in Flights where f.Destination == destination select f.FlightDate;
            return query;  

        }
        public void showFlightDetails(Plane plane)
        {
            var query = from f in Flights where f.Plane == plane select f;
            foreach(var f in query)
            {
                Console.WriteLine("destiantion = "+f.Destination+""+"Flight Date = "+f.FlightDate);
            }
        }

        public int ProgrammeFlightNumber(DateTime startDate)
        {


            var query = from f in Flights
                        where (DateTime.Compare(f.FlightDate, startDate) > 0 && (f.FlightDate - startDate).TotalDays < 7)
                        select f;
            return query.Count();
            
            
        }
        public double DurationAverage(string Destination)
        {
            var query = from f in Flights where f.Destination == Destination select f.EstimatedDuration;
            return query.Average();
        }
        public IEnumerable<Flight> OrderDurationFlight()
        {
            var query = from f in Flights
                        orderby f.EstimatedDuration descending 
                        select f;
            return query;
        }
        public IEnumerable<Traveller>SeniorTravellers(Flight flight) {
        var query=from p in flight.Passengers.OfType<Traveller>()
                  orderby p.BirthDate ascending 
                   select p;
            return query.Take(3);
        }

        public void GetFlights(string filtertype, string filterValue)
        {
            switch (filtertype)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination.Equals(filterValue))

                            Console.WriteLine(f);

                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                    {
                        if (f.EstimatedDuration == int.Parse(filterValue))
                        {
                            Console.WriteLine(f);
                        }
                    }
                    break;

            }
        }

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupFlight()
        {
            var query = from f in Flights
                        group f by f.Destination;
               foreach(var g in query){
                Console.WriteLine("Destination = "+g.Key);
                foreach(var v in g)
                {
                    Console.WriteLine("decolage = " + v.FlightDate);
                }

            }
            return query;
                 
        }

       

        
        public Action<Plane>FlightDetailDel;
        public Func<string, double> DurationAverageDel;
        public ServiceFlight() {
            FlightDetailDel = plane =>
            {
                var query = from f in Flights where f.Plane == plane select f;
                foreach (var f in query)
                {
                    Console.WriteLine("destiantion = " + f.Destination + "" + "Flight Date = " + f.FlightDate);
                }
            };
            DurationAverageDel = Destination =>
            {
                var query = from f in Flights where f.Destination == Destination select f.EstimatedDuration;
                return query.Average();
            
            

            };
            
        }
       

    }
}

