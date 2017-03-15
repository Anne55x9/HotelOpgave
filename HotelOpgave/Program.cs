using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelOpgave
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new HotelContext())
            {
                Console.WriteLine("Opgave 2.1, List Hoteller med informationen:");

                var hotelList = from h in db.Hotel
                                select h;

                foreach (var item in hotelList)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 2.2, List gæsterne med deres informationer:");

                var gæstliste = from g in db.Guest
                                select g;

                foreach (var item in gæstliste)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 3.1, List Hoteller med dets ruminformationer:");


                var HotelVærelser =
                    from h2 in db.Hotel
                    join r in db.Room
                    on h2.Hotel_No equals r.Hotel.Hotel_No
                    orderby h2.Hotel_No, r.Room_No
                    select new
                    {
                        h2.Hotel_No,
                        h2.Name,
                        h2.Address,
                        r.Room_No,
                        r.Types,
                        r.Price
                    };

                foreach (var item in HotelVærelser)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 3.2, List alle reservationer hvert enkelt væresle har.");


                var værelsesbookinger =
                    from r in db.Room
                    join b in db.Booking
                    on r.Room_No equals b.Room.Room_No
                    orderby r.Room_No, b.Booking_id
                    select new
                    {
                        r.Hotel.Name,
                        r.Room_No,
                        r.Types,
                        r.Price,
                        b.Booking_id,
                        b.Date_From,
                        b.Date_To
                    };

                foreach (var item in værelsesbookinger)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 4.1, Indsæt gæster i databasen:");


                //// Indsætter gæst uden gæstenummer indskrevet og det bliver 0! Kan kun ske 1 gang da nul var ledigt så hust Gæstenummer.
                //var gæst = new Guest() { Name = "Anne Sofie", Address = "HejsaVej 25, 2100 kbh ø" };
                //db.Guest.Add(gæst);

                ////Indsætter gæst med gæstenummer indskrevet.
                //var gæst2 = new Guest() { Name = "Emil", Address = "HejsaVej 25, 2100 kbh ø", Guest_No = 31 };

               // db.Guest.Add(gæst2);

                ////Test af Gæstenummer eller ej, det skulle da gæsteklassen ikke autogenerere et nummer system for gæsterne:). 
                //var gæst3 = new Guest() { Name = "Dagbjørt", Address = "HejsaVej 25, 2100 kbh ø", Guest_No = 32};

                //db.Guest.Add(gæst3);

                //db.SaveChanges();

                var gæsteliste2 =
                    from g in db.Guest
                    select g;

                foreach (var item in gæsteliste2)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 4.2, Indsæt reservation fredag:");

                //var reserFredag = new Booking() { Room_No = 4, Guest_No = 31, Hotel_No = 2, Date_From = DateTime.Parse("2013-03-17"), Date_To = DateTime.Parse("2013-03-18") };

                //db.Booking.Add(reserFredag);
                //db.SaveChanges();

                Console.WriteLine("Opgave 4.3, Indsæt reservation lørdag:");

                //var reserLørdag = new Booking() { Room_No = 4, Guest_No = 31, Hotel_No = 2, Date_From = DateTime.Parse("2013-03-18"), Date_To = DateTime.Parse("2013-03-19") };
                //db.Booking.Add(reserLørdag);
                //db.SaveChanges();

                //var reserSøndag = new Booking() {Room_No = 3, Guest_No = 31, Hotel_No = 2, Date_From = DateTime.Parse("2013-03-19"), Date_To = DateTime.Parse("2013-03-20") };
                //db.Booking.Add(reserSøndag);
                //db.SaveChanges();

                ////Alternativt og bedst til csharp objekter:

                //var reserMandag = new Booking() { Room_No = 3, Guest_No = 31, Hotel_No = 2, Date_From = new DateTime(2013, 03, 17), Date_To = new DateTime(2013, 03, 18) };
                //db.Booking.Add(reserMandag);
                //db.SaveChanges();

                //var nyBookingliste =
                //    from b in db.Booking
                //    select new
                //    {
                //        b.Booking_id,
                //        b.Date_From,
                //        b.Date_To,
                //        b.Guest
                //    };

                //foreach (var item in nyBookingliste)
                //{
                //    Console.WriteLine(item.ToString());

                //}


                Console.WriteLine("Opgave 5.1, Opdater adressen for Arn guestno 30.");

                //var ArnAdresseÆndret =
                //    from g in db.Guest
                //    where g.Guest_No == 30
                //    select g;
                //Guest Arn = ArnAdresseÆndret.FirstOrDefault();

                //Arn.Address = "Elisagaardsvej 5, 4000 Roskilde";

                //foreach (var item in gæsteliste2)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                Console.WriteLine("HotelOpgave 5.2, opdater navn for Prindsen til Roskilde First Hotel");

                //var HotelPrindsenÆndret =
                //    from h in db.Hotel
                //    where h.Name.Contains("Prindsen")
                //    select h;
                //Hotel Prindsen = HotelPrindsenÆndret.FirstOrDefault();

                //Prindsen.Name = "Roskilde First Hotel";

                foreach (var item in hotelList)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 6.1, slet booking 55:");

                // var b55slet = (from b in db.Booking
                //                where b.Booking_id.Equals(55)
                //                select b).FirstOrDefault();

                //var b24slet = db.Booking.FirstOrDefault(x => x.Booking_id.Equals(24));

                // db.Booking.Remove(b55slet);

                //db.Booking.Remove(b24slet);

                //db.SaveChanges();

                var bookinglist =
                    from b in db.Booking
                    select b;

                foreach (var item in bookinglist)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("6.3 opgave, slet gæst no 26, Fejl da Booking har Gæstno som reference:");

                //var sletGæst26 = db.Guest.FirstOrDefault(x => x.Guest_No.Equals(26));

                //db.Guest.Remove(sletGæst26);

                //db.SaveChanges();

                //foreach (var item in gæsteliste2)
                //{
                //    Console.WriteLine(item.ToString());
                //}

                 Console.WriteLine("7.1 Opgave, slet gæst no 30 og booking id");

                var gæstno30slet =
                      from g in db.Guest
                      join b in db.Booking
                      on g.Guest_No equals b.Guest.Guest_No
                      where g.Guest_No == 30
                      select new
                      {
                          g.Guest_No,
                          b.Booking_id

                      };

                foreach (var item in gæstno30slet)
                {
                    Console.WriteLine(item.ToString());
                }



                //var sletb83 =
                //    (from b in db.Booking
                //     where b.Booking_id.Equals(83)
                //     select b).FirstOrDefault();

                //db.Booking.Remove(sletb83);

                db.SaveChanges();

                foreach (var item in bookinglist)
                {
                    Console.WriteLine(item.ToString());
                }

                //var gæstno30Slet =
                //    (from g in db.Guest
                //     where g.Guest_No == 30
                //     select g).FirstOrDefault();

                //db.Guest.Remove(gæstno30Slet);

                //db.SaveChanges();

                foreach (var item in gæsteliste2)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 8.1, alle bookinger på gæst:");


                var bookinglist3 =
                    from b in db.Booking
                    group b by b.Guest_No
                    into guestGroup
                    orderby guestGroup.Key
                    select new
                    {
                        guestNo = guestGroup.Key,
                        //Hvad er det højeste rumnummer personen har booket. Ikke relastist bare syntax eksempel :)       
                        countBookings = guestGroup.Count(),
                        
                     };

                foreach (var item in bookinglist3)
                {
                    Console.WriteLine(item.ToString());
                }


                Console.WriteLine("Opgave 8.1a, alle bookinger på gæst:");

                var bookingTest =
                    db.Booking.GroupBy(b => b.Guest_No)
                    .OrderBy(guestGoup => guestGoup.Key)
                    .Select(guestGroup => new
                    {
                        guestNo = guestGroup.Key,
                        countBookings = guestGroup.Count(),
                        bookingSum = guestGroup.Sum(x => x.Room.Price)

                        //priceBookings = guestGroup.Sum()
                    });


                foreach (var item in bookingTest)
                {
                    Console.WriteLine(item.ToString());
                }

                Console.WriteLine("Opgave 8.2, gæstersnavn med:");

             



                Console.ReadLine();
            }



        }
    }
}
