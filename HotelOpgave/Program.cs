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

                Console.ReadLine();
            }



        }
    }
}
