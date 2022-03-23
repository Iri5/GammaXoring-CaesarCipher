using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    interface ICipher
    {
        public string Encode(string openData, string key);
        public string Decode(string encryptedData, string key);
    }
}
