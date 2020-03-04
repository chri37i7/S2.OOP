using System;

namespace CourtBooking.Entities
{
    public class Booking
    {
        protected int id;
        protected int courtNumber;
        protected DateTime bookingTime;
        protected int booker;

        public Booking(int id, int courtNumber, DateTime bookingTime, int booker)
        {
            Id = id;
            CourtNumber = courtNumber;
            BookingTime = bookingTime;
            Booker = booker;
        }

        public virtual int Id
        {
            get
            {
                return id;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateNumber(value);
                if(isValid)
                {
                    if(id != value)
                    {
                        id = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Id), errorMessage);
                }
            }
        }

        public virtual int CourtNumber
        {
            get
            {
                return courtNumber;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateNumber(value);
                if(isValid)
                {
                    if(courtNumber != value)
                    {
                        courtNumber = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(CourtNumber), errorMessage);
                }
            }
        }

        public virtual DateTime BookingTime
        {
            get
            {
                return bookingTime;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateTime(value);
                if(isValid)
                {
                    if(bookingTime != value)
                    {
                        bookingTime = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(BookingTime), errorMessage);
                }
            }
        }

        public virtual int Booker
        {
            get
            {
                return booker;
            }
            set
            {
                (bool isValid, string errorMessage) = ValidateNumber(value);
                if(isValid)
                {
                    if(booker != value)
                    {
                        booker = value;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(Booker), errorMessage);
                }
            }
        }

        public override string ToString()
        {
            return $"Booking ID: {id}, Court Number: {courtNumber}, Booking Time: {bookingTime}, Booker: {booker}";
        }

        public virtual (bool, string) ValidateNumber(int number)
        {
            if(number < 0)
            {
                return (false, "The value cannot be lower than zero");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public virtual (bool, string) ValidateTime(DateTime time)
        {
            if(time.Year == DateTime.MinValue.Year)
            {
                return (false, "The date cannot be at the start of time.");
            }
            if(time.Year == DateTime.MaxValue.Year)
            {
                return (false, "The date cannot be at the end of time");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}