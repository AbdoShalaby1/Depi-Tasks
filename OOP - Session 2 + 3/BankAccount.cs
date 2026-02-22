using System;
using System.Collections.Generic;
using System.Text;

namespace DEPI_tasks
{
    internal class BankAccount
    {
        const string BankCode = "BNK001";
        readonly DateTime CreatedDate;
        private int _accountNumber = 1242413523;

        private string _fullName;
        private string _nationalID;
        private string _phoneNumber;
        private string _address;
        private double _balance;

        public string FullName {
            get {
                return _fullName;
            }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be null or whitespace", nameof(value)); ;
                _fullName = value;
            }
        }

        public string NationalId {
            get
            {
                return _nationalID;
            }
            set
            {
                if (value.Length != 14)
                    throw new ArgumentException("Length has to be 14", nameof(value)); ;
                _nationalID = value;
            }
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                if (value[0] != '0' || value[1] != '1' || value.Length != 11)
                    throw new ArgumentException("Invalid Format", nameof(value)); ;
                _phoneNumber = value;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Positive value allowed only!", nameof(value)); ;
                _balance = value;
            }
        }

        public string Address { get { return _address; } set { _address = value; } }

        public BankAccount()
        {
            _fullName = "Customer";
            _address = "Default";
            _nationalID = "12345678901234";
            _phoneNumber = "01012341234";
            _balance = 0;
        }

        public BankAccount(string fullName, string nationalID, string phoneNumber, string address, double balance)
        {
            _fullName = fullName;
            _nationalID = nationalID;
            _phoneNumber = phoneNumber;
            _address = address;
            _balance = balance;
        }

        public BankAccount(DateTime createdDate, int accountNumber, string fullName, string nationalID, string phoneNumber, string address)
        {
            CreatedDate = createdDate;
            _accountNumber = accountNumber;
            _fullName = fullName;
            _nationalID = nationalID;
            _phoneNumber = phoneNumber;
            _address = address;
        }

        public virtual void ShowAccountDetails()
        {
            Console.WriteLine($"Name: {_fullName} - Phone: {_phoneNumber}, {_balance}EGP");
        }

        public bool IsValidNationalID()
        {
            return _nationalID.Length == 14;
        }

        public bool IsValidPhoneNumber()
        {
            return _phoneNumber[0] == '0' && _phoneNumber[1] == '1' && _phoneNumber.Length == 11;
        }

    }
}
