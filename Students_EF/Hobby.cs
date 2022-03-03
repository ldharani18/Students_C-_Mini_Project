using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_MP
{
    [Serializable]
    public abstract class Hobby
    {
        public abstract void Singing();
        public abstract void Dancing();
        public virtual void Yoga()//virtual is used to indicate that the base-class function Yoga can be overridden
        {
            Console.WriteLine("Practicing Yoga");
        }
    }
}
