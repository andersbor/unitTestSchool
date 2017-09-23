using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public abstract class Person 
    {
        protected string _name;
        private string _address;

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
    }
}
