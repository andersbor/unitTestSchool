﻿using System;

namespace School
{
    public enum Gender
    {
        Male, Female
    }

   

    /// <summary>
    ///     Class invariant: name !=null and name != ""
    /// </summary>
    public class Student : Person, IEquatable<Student>
    {
        private int _semester;

        public Student(String name, string address, int semester, Gender gender)
        {          
            Name = name;
            Address = address;
            Semester = semester;
            Gender = gender;
        }

        public int Semester
        {
            get { return _semester; }
            set
            {
                CheckSemester(value);
                _semester = value;
            }
        }

        private static void CheckSemester(int semester)
        {
            if (1 <= semester && semester <= 8)
                return;
            throw new ArgumentOutOfRangeException(nameof(semester), semester, "Illegal semester");
        }

        public bool Equals(Student other)
        {
            if (other == null) return false;
            return this._name.Equals(other._name) && this._semester == other._semester;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Student personObj = obj as Student;
            if (personObj == null)
            {
                return false;
            }
            return Equals(personObj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((_name != null ? _name.GetHashCode() : 0) * 397) ^ _semester;
            }
        }

        public override string ToString()
        {
            return string.Format("Student: {0}, {1}, {2}, {3}", Name, Address, Semester, Gender);
        }
    }
}