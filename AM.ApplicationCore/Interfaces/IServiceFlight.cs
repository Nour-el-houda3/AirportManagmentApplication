using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServiceFlight
    {
        IEnumerable<DateTime> GetFlightDate(string destination);
        void GetFlights(string filtertype, string filterValue);

        public void showFlightDetails(Plane plane);
        public int ProgrammeFlightNumber(DateTime startDate);
        public double DurationAverage(string Destination);
        public IEnumerable<Flight> OrderDurationFlight();
        public IEnumerable<Traveller> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<string, Flight>> DestinationGroupFlight();
        


    }
}
