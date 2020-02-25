using System;
using System.Collections.Generic;
using System.Text;

namespace S2.OOP.Encapsulation
{
    class Account
    {
        // Fields
        private string accountNumber;
        private string departmentNumber;
        private decimal balance;

        public Account(string accountNumber, string departmentNumber, decimal balance)
        {
            AccountNumber = accountNumber;
            DepartmentNumber = departmentNumber;
            Balance = balance;
        }

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