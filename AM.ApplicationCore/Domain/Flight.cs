using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string? Airline { get; set; }
        public string Destination { get; set; }
        public string? Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }

        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }

        public Plane Plane { get; set; }
        [ForeignKey("MyPlane")]
        public int PlaneId { get; set; }
        public Plane MyPlane { get; set; }
        
        //public ICollection<Passenger> Passengers { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Destination =  "+ this.Destination +" EstimatedDuration = "+this.EstimatedDuration;
        }
    }
}
