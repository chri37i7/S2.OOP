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
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Account number cannot be empty", nameof(AccountNumber));
                }
                if(value.Length != 10)
                {
                    throw new ArgumentOutOfRangeException(nameof(AccountNumber), "The number cannot be higher or lower than 10");
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
                if(string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The department number cannot be empty", nameof(DepartmentNumber));
                }
                if(value.Length != 4)
                {
                    throw new ArgumentOutOfRangeException(nameof(DepartmentNumber), "The department number cannot be higher or lower than 4");
                }
                if(value.Substring(0, 1).Contains("0"))
                {
                    throw new ArgumentException("The first letter of the department number cannot be 0", nameof(DepartmentNumber));
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
                if(value < 0.0m)
                {
                    throw new ArgumentOutOfRangeException(nameof(Balance), "The balance cannot be negative");
                }
                if(value != balance)
                {
                    balance = value; 
                }
            }
        }
    }
}
