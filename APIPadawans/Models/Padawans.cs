using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPadawans.Models
{
    public class Padawans
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int Age { get; set; }

        public bool Complete { get; set; }

        public bool CutHair { get; set; }
    }
}
