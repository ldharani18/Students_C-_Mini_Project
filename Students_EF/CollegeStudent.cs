using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_MP
{
    [Serializable]
    class CollegeStudent:Student,IComparable<CollegeStudent>
    {
        public long MobileNo { get; set; }
        public string Mail_Id { get; set; }
        public string Dept { get; set; }
        public string Year { get; set; }
        public int X_mark { get; set; }
        public int XII_mark { get; set; }
        public double CGPA { get; set; }

        public int CompareTo(CollegeStudent other)
        {
            if (this.CGPA >= other.CGPA)
            {
                return 1;
            }
            return 0;
        }
    }
}
