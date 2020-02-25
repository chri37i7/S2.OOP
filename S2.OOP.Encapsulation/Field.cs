using System;
using System.Collections.Generic;
using System.Text;

namespace S2.OOP.Encapsulation
{
    /// <summary>
    /// <see cref="Crop"/> of a <see cref="Field"/> class object
    /// </summary>
    public enum Crop
    {
        Potatoes,
        Wheat,
        Oak,
        Carrots
    }

    /// <summary>
    /// Represents a <see cref="Field"/> object, containing <see cref="width"/>, <see cref="length"/>, <see cref="crop"/>, <see cref="area"/>, and <see cref="yield"/>
    /// </summary>
    class Field
    {
        // Fields
        private double width;
        private double length;
        private Crop crop;
        private double area;
        private double yield;

        /// <summary>
        /// Creates a new <see cref="Field"/> with the provided <see cref="width"/>, <see cref="length"/>, and <see cref="crop"/>
        /// </summary>
        /// <param name="width"></param>
        /// <param name="length"></param>
        /// <param name="crop"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Field(double width, double length, Crop crop)
        {
            Width = width;
            Length = length;
            Crop = crop;
        }

        /// <summary>
        /// Gets or sets the value of <see cref="width"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Gets or sets the value of <see cref="length"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Gets the value of <see cref="area"/> by multiplying <see cref="width"/> and <see cref="length"/>
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
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
                    area = (length * width);

                    return area;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="crop"/>
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Gets the <see cref="yield"/> by multiplying the <see cref="area"/> with a certain kilos per square meter,
        /// determined by which <see cref="crop"/> is set.
        /// </summary>
        public double Yield
        {
            get
            {
                if(crop == Crop.Wheat)
                {
                    // 10 kilos per square meter
                    yield = (area * 20);
                    return yield;
                }
                if(crop == Crop.Potatoes)
                {
                    // 20 kilos per square meter
                    yield = (area * 40);
                    return yield;
                }
                if(crop == Crop.Oak)
                {
                    // 15 kilos per square meter
                    yield = (area * 15);
                    return yield;
                }
                if(crop == Crop.Carrots)
                {
                    // 66.66 kilos per square meter
                    yield = (area * 66.6666667);
                    return yield;
                }
                else
                {
                    // Return nothing
                    yield = 0;
                    return yield;
                }
            }
        }

        /// <summary>
        /// Used validate a number to see if its negative
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Used to validate a <see cref="crop"/> to see if its a valid <see cref="Crop"/>
        /// </summary>
        /// <param name="crop"></param>
        /// <returns></returns>
        public static (bool, string) ValidateCrop(Crop crop)
        {
            if(crop.Equals(null))
            {
                return (false, "The crop cannot be null");
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