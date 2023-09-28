using AM.UI.Console;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Display(Name ="Dare of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; set; }
        // [Key,StringLength(7)]
        [Key]//clé primaire
        [StringLength(7)]
        public string PassportNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        public FullName FullName { get; set; }
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public string? TelNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public override string ToString()
        {
            return "Firstname="+this.FullName.FirstName+"LastName="+this.FullName.LastName;
        }
        //public bool CheckProfile(string FirstName,string LastName)
        //    {
        //        return FirstName==this.FirstName && LastName==this.LastName
        //     ;
        //    }

        //public bool CheckProfile(string FirstName, string LastName, string email)
        //{
        //    return FirstName == this.FirstName && LastName == this.LastName
        //    && email == this.EmailAdress;
        //}
        public bool CheckProfile(string FirstName, string LastName, string email=null)
        {

            if (email == null) {
                return FirstName == this.FullName.FirstName && LastName == this.FullName.LastName;
                    }
            else { 
                return FirstName == this.FullName.FirstName && LastName == this.FullName.LastName
            && email == this.EmailAdress;
            }
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }

    }
}
