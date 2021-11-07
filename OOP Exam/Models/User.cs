﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace OOP_Exam.Models
{
    public class User : IComparable
    {
        private static int _nextID = 1;
        public int ID
        {
            get
            {
                return _id;
            }
        }
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value ?? "";
            }
        }
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value ?? "";
            }
        }
        public string Username
        {
            get
            {
                return _userName;
            }
            set
            {
                if (Regex.IsMatch(value, @"^[a-zA-Z0-9_]+$"))
                {
                    _userName = value;
                }
                else
                    throw new ArgumentException("Give proper username >:(");
            }
        }
        public string Email { get; set; } //Find proper regex or write method for email check
        public decimal Balance //Alert user when they broke
        {
            get
            {
                return _balance;
            }
            set
            {
                _balance = value;
            }
        } 

        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _email;
        private decimal _balance;

        public User(string firstName, string lastName, string email, decimal balance)
        {
            _id = _nextID;
            _nextID++;
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _balance = balance;
        }

        public override string ToString()
        {
            return $"{_userName} {_lastName} {_email}";
        }

        //public int CompareTo(object obj)
        //{
        //    if (this.ID < obj.)
        //        return 1;
        //    else if (this.ID > obj.ID)
        //        return -1;
        //    else
        //        return 0;
        //}

        public int CompareTo(object obj)
        {
            return obj is User user ? ID.CompareTo(user.ID) : 1; //Daniel!!!!! It work by why?! I kinda understand
        }
    }
}
