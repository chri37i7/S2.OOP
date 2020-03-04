using System;
using CourtBooking.Service;
using CourtBooking.Entities;
using System.Collections.Generic;

namespace CourtBooking.ManualTest
{
    public class Program
    {
        public static BookingService service = new BookingService();

        public static void Main()
        {
            WriteMany();

            WriteSingle(1);
        }

        public static void WriteMany()
        {
            // Create list containing objects
            List<Booking> bookings = service.GetMany();

            // Output objects in list
            foreach(Booking booking in bookings)
            {
                Console.WriteLine(booking);
            }
        }

        public static void WriteSingle(int id)
        {
            // Create single object
            Booking booking = service.GetSingle(id);

            // Output object
            Console.WriteLine($"\n{booking}");
        }
    }
}