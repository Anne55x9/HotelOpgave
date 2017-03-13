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
                var hotelList = from h in db.Hotel
                                select h;

                foreach (var item in hotelList)
                {
                    Console.WriteLine(item.ToString());
                }

                var gæstliste = from g in db.Guest
                                select g;

                foreach (var item in gæstliste)
                {
                    Console.WriteLine(item.ToString());
                }
                  
                Console.ReadLine();
            }

        }
    }
}
