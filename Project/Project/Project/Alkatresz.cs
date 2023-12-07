using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Alkatresz
    {
        public string Tipus { get; set; }
        public string Nev { get; set; }
        public string Parameter { get; set; }
        public int Ar { get; set; }
        public Alkatresz(string tipus, string nev, string parameter, int ar)
        {
            Tipus = tipus;
            Nev = nev;
            Parameter = parameter;
            Ar = ar;
        }

        public string ToString()
        {
            return $"{this.Tipus}; {this.Nev}; {this.Parameter}; {this.Ar}";
        }
    }
}
