using System;
using System.Collections.Generic;
using System.Net;
using CourtBooking.Entities;
using Newtonsoft.Json;

namespace CourtBooking.Service
{
    public class BookingService
    {
        protected readonly string url = @"https://api.aspitcloud.dk/bookings";
        protected string result;

        public virtual Booking GetSingle(int id)
        {
            // Url
            string urlForSingle = $"{url}/{id}";

            // Get json data from url using WebClient
            using(WebClient client = new WebClient())
            {
                result = client.DownloadString(urlForSingle);
            }

            // Deserialize and create object
            Booking booking = JsonConvert.DeserializeObject<Booking>(result);

            // Return object
            return booking;
        }

        public virtual List<Booking> GetMany()
        {
            // List for objects
            List<Booking> bookings;

            // Get json data using webclient
            using(WebClient client = new WebClient())
            {
                result = client.DownloadString(url);
            }

            // Deserialize data, and create list containing objects
            bookings = JsonConvert.DeserializeObject<List<Booking>>(result);

            // Return object list
            return bookings;
        }
    }
}