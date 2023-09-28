using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public double Prix { get; set; } 
        public int Siege { get; set; }
        public bool Vip { get; set;}

        public Passenger passenger { get; set; }

        public Flight flight { get; set; }
        //type de cle etra == type de cle prim
        public int FlightFK { get; set; }
        public string PassengerFK { get; set; }  
    }
}
