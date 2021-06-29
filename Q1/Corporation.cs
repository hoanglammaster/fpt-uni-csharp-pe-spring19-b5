using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public class Corporation
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Region { get; set; }

        public Corporation()
        {
        }

        public Corporation(int no, string name, string street, string region)
        {
            No = no;
            Name = name;
            Street = street;
            Region = region;
        }
    }
}
