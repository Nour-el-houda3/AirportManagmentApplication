// See https://aka.ms/new-console-template for more information


//Plane Plane1 = new Plane();
//Plane1.Capacity = 200;
//Plane1.ManufactureDate = new DateTime(2023, 01, 31);
//Plane1.planeType = PlaneType.Airbus;
//Plane Plane2 = new Plane(PlaneType.Boing, 500, new DateTime(2022, 05, 23));
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;
using AM.UI.Console;

///------------------------------------------------ TP1 ------------------------------------//

//Plane Plane3 = new Plane
//{
//    Capacity = 3,
//    ManufactureDate = new DateTime(2023, 02, 01),
//    planeType = PlaneType.Boing
//};

Passenger passenger1 = new Passenger
{
    FullName = new FullName {
        FirstName = "traveller5", LastName = "traveller5" },
    EmailAdress = "FooBar@esprit.tn"
};
//Console.WriteLine(passenger1.CheckProfile("Ameni", "Hajri"));

//Traveller traveller1 = new Traveller
//{
//    FirstName = "Ameni",
//    LastName = "Hajri",
// Nationality="tunisienne"
//};
//Console.WriteLine("traveller1:");
//traveller1.PassengerType();

//staff staff1 = new staff
//{

//    FirstName = "aa",
//    LastName = "bb",
//    Salary = 1000.0
//};
//Console.WriteLine("staff1:");
//staff1.PassengerType();

///------------------------------------------------ TP2 ------------------------------------//
ServiceFlight sf =new ServiceFlight();
sf.Flights = TestData.listFlights;
foreach(var item in sf.GetFlightDate("Paris"))
{
   Console.WriteLine(item);
}
sf.GetFlights("Destination", "Paris");
//sf.showFlightDetails(TestData.BoingPlane);
Console.WriteLine("total flights = "+sf.ProgrammeFlightNumber(new DateTime(2022, 02, 01)));
Console.WriteLine("Average estimated time = " + sf.DurationAverage("Paris"));
Console.WriteLine("Average estimated time with del = " + sf.DurationAverageDel("Paris"));
foreach (var item in sf.OrderDurationFlight()){ 
    Console.WriteLine(item); };

foreach(var item in sf.SeniorTravellers(TestData.flight1))
{
Console.WriteLine(item); };

sf.DestinationGroupFlight();
Console.WriteLine(passenger1.fullName.FirstName + passenger1.fullName.LastName);
passenger1.UpperFullName();
Console.WriteLine(passenger1.fullName.FirstName + passenger1.fullName.LastName);

AMContext ctx=new AMContext();  
//ajouter des objets aux DBSET
ctx.Flights.Add(TestData.flight1);
//persister les données
ctx.SaveChanges();

