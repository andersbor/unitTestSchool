using System;
using System.Xml.Schema;

namespace School
{
    public enum Gender
    {
        Male, Female
    }

    /// <summary>
    ///     Class invariant: name !=null and name != ""
    /// </summary>
    public class Student : IEquatable<Student>
    {
        private string _name;
        private int _semester;
        private string _address;

        public Student(String name, int semester)
        {
            CheckName(name);
            _name = name;
            _semester = semester;
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

        public int Semester
        {
            get { return _semester; }
            set
            {
                CheckSemester(value);
                _semester = value;
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

        private static void CheckSemester(int semester)
        {
            if (1 <= semester && semester <= 8)
                return;
            throw new ArgumentException("semester is less than zero");
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
            return string.Format("Student: {0}, {1}", _name, _semester);
        }
    }
}