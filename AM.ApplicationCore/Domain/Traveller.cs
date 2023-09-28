using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller:Passenger //heritage avec :
    {
        public string HelathInformation { get; set; }
        public string Nationality { get; set; }


        public override string ToString()
        {
            return "Nationality = " + this.Nationality+" HelathInformation = "+this.HelathInformation;
        }

        public virtual void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("I am a traveller member");
        }
    }
}
