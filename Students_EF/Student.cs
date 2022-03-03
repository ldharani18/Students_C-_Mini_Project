using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters;
using System.IO;//to use stream 

namespace Students_MP
{
    [Serializable]
    public class Student:Hobby,FileWrite_Read
    {
        public int Roll_No { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public DateTime DOB { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Class_and_Section { get; set; }


        public void WriteToBinaryFile<T>(string filePath, List<T> objectToWrite, bool append = false)
        {
            using (Stream stream = File.Open(filePath, append ? FileMode.Append : FileMode.Create))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, objectToWrite);
            }
        }
        public List<T> ReadFromBinaryFile<T>(string filePath)
        {
            using (Stream stream = File.Open(filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (List<T>)binaryFormatter.Deserialize(stream);
            }
        }
        //overriding of inherited functions
        public override void Singing()
        {
            Console.WriteLine("Singing");
        }
        public override void Dancing()
        {
            Console.WriteLine("Dancing");
        }
        public override void Yoga()
        {
            Console.WriteLine("Practicing yoga");
        }

    }
}
