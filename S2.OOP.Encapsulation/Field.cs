using System;
using System.Collections.Generic;
using System.Text;

namespace S2.OOP.Encapsulation
{
    public enum Crop
    {
        Potatoes,
        Wheat,
        Oak,
        Carrots
    }

    class Field
    {
        // Fields
        private double width;
        private double length;
        private Crop crop;
        private double yield;


        public Field(double width, double length, Crop crop)
        {
            Width = width;
            Length = length;
            Crop = crop;
        }


        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateNumber(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Width), validationResult.errorMessage);
                }
                if(width != value)
                {
                    width = value;
                }
            }
        }

        public double Length
        {
            get
            {
                return length;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateNumber(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Length), validationResult.errorMessage);
                }
                if(length != value)
                {
                    length = value;
                }
            }
        }

        public double Area
        {
            get
            {
                (bool isValid, string errorMessage) validationResult = ValidateNumber(length);
                if(!validationResult.isValid)
                {
                    throw new InvalidOperationException(validationResult.errorMessage);
                }
                validationResult = ValidateNumber(width);
                if(!validationResult.isValid)
                {
                    throw new InvalidOperationException(validationResult.errorMessage);
                }
                else
                {
                    return (length * width);
                }
            }
        }

        public Crop Crop
        {
            get
            {
                return crop;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateCrop(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentNullException(nameof(Crop), validationResult.errorMessage);
                }
                if(crop != value)
                {
                    crop = value;
                }
            }
        }

        public double Yield
        {
            get
            {
                return yield;
            }
        }

        public (bool, string) ValidateNumber(double number)
        {
            if(number <= 0)
            {
                return (false, "The number cannot be 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        public static (bool, string) ValidateCrop(Crop crop)
        {
            if(crop.Equals(null))
            {
                return (false, "The value cannot be null");
            }
            if(!Crop.IsDefined(typeof(Crop), crop))
            {
                return (false, "The crop cannot be undefined");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}