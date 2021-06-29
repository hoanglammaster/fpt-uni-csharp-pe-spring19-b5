using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q1
{
    public class Corporation
    {
        public int CorNo { get; set; }
        public string CorName { get; set; }
        public string Street { get; set; }
        public string RegiName { get; set; }
        public DateTime ExpDate { get; set; }
        public Corporation()
        {
        }

        public Corporation(int corNo, string corName, string street, string regiName,DateTime expDate)
        {
            CorNo = corNo;
            CorName = corName;
            Street = street;
            RegiName = regiName;
            ExpDate = expDate;
        }
    }
}
