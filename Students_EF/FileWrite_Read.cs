using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_MP
{
    interface FileWrite_Read
    {
        void WriteToBinaryFile<T>(string filePath, List<T> objectToWrite, bool append = false);
        List<T> ReadFromBinaryFile<T>(string filePath);
    }
}
