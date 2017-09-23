using System;

namespace School
{
    /// <summary>
    ///     Class invariant: name !=null and name != ""
    /// </summary>
    public class Student : Person, IEquatable<Student>
    {
        private int _semester;

        public Student(String name, string address, int semester, Gender gender)
            : base(name, address, Gender.Male)
        {
            Semester = semester;
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
            return this.Name.Equals(other.Name) && this._semester == other._semester;
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
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ _semester;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + Semester;
        }
    }
}