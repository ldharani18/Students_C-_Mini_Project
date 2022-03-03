using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_MP
{
    [Serializable]
    class SchoolStudent:Student
    {
        public double Average_Mark { get; set; }
        public int Rank_No { get; set; }

    }
}
