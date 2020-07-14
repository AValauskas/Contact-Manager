using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagerApp.Models
{
    public class Contact : ICloneable
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}", this.Name, this.LastName, this.Phone, this.Address);
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
