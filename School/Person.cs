﻿using System;

namespace School
{
    public enum Gender
    {
        Male, Female
    }

    public class Person
    {
        private string _name;
        private string _address;

        public Person(string name, string address, Gender gender)
        {
            Name = name;
            Address = address;
            Gender = gender;
        }

        public String Name
        {
            get { return _name; }
            set
            {
                CheckName(value);
                _name = value;
            }
        }

        public string Address
        {
            get { return _address; }
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value), "name is null");
                _address = value;
            }
        }

        public Gender Gender { get; set; }

        private static void CheckName(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name is null or empty");
            }
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", Name, Address, Gender);
        }
    }
}
