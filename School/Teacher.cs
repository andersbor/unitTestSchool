using System;

namespace School
{
    public class Teacher: Person
    {
        private int _salary;

        public Teacher(string name, string address, Gender gender, int salary)
            :base(name, address, gender)
        {
            Salary = salary;
        }

        public int Salary
        {
            get { return _salary; }
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "negative salary");
                _salary = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + ", " + Salary;
        }
    }
}
