using System;
using System.Collections.Generic;
using System.Text;

namespace S2.OOP.Encapsulation
{
    /// <summary>
    /// Represents a <see cref="Account"/> object, containing <see cref="accountNumber"/>, <see cref="departmentNumber"/>, and <see cref="balance"/>
    /// </summary>
    class Account
    {
        // Fields
        private string accountNumber;
        private string departmentNumber;
        private decimal balance;

        /// <summary>
        /// Creates a new <see cref="Account"/> with the provided <see cref="accountNumber"/>, <see cref="departmentNumber"/>, and <see cref="balance"/>
        /// </summary>
        /// <param name="accountNumber"></param>
        /// <param name="departmentNumber"></param>
        /// <param name="balance"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Account(string accountNumber, string departmentNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            DepartmentNumber = departmentNumber;
            Balance = balance;
        }

        /// <summary>
        /// Gets or sets the value of <see cref="accountNumber"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateAccountNumber(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(validationResult.errorMessage, nameof(AccountNumber));
                }
                if(accountNumber != value)
                {
                    accountNumber = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="departmentNumber"/>
        /// </summary>
        /// <exception cref="ArgumentException"></exception>
        public string DepartmentNumber
        {
            get
            {
                return departmentNumber;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateDepartmentNumber(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentException(validationResult.errorMessage, nameof(DepartmentNumber));
                }
                if(value != departmentNumber)
                {
                    departmentNumber = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the value of <see cref="balance"/>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public decimal Balance
        {
            get
            {
                return balance;
            }
            set
            {
                (bool isValid, string errorMessage) validationResult = ValidateBalance(value);
                if(!validationResult.isValid)
                {
                    throw new ArgumentOutOfRangeException(nameof(Balance), validationResult.errorMessage);
                }
                if(value != balance)
                {
                    balance = value; 
                }
            }
        }

        /// <summary>
        /// Used to validate a <see cref="accountNumber"/> to see if its a valid number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateAccountNumber(string number)
        {
            if(string.IsNullOrEmpty(number))
            {
                return (false, "Account number cannot be empty");
            }
            if(number.Length != 10)
            {
                return (false, "The number cannot be higher or lower than 10");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Used to validate a <see cref="departmentNumber"/> to see if its valid number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static (bool, string) ValidateDepartmentNumber(string number)
        {
            if(string.IsNullOrEmpty(number))
            {
                return (false, "The department number cannot be empty");
            }
            if(number.Length != 4)
            {
                return (false, "The department number cannot be higher or lower than 4");
            }
            if(number.Substring(0, 1).Contains("0"))
            {
                return (false, "The first letter of the department number cannot be 0");
            }
            else
            {
                return (true, string.Empty);
            }
        }

        /// <summary>
        /// Used to validate a <see cref="balance"/> to see if its valid number
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static (bool, string) ValidateBalance(decimal balance)
        {
            if(balance < 0.0m)
            {
                return (false, "The balance cannot be negative");
            }
            else
            {
                return (true, string.Empty);
            }
        }
    }
}