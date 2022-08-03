using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{
    public class ObjectKey
    {
        public string objectType { get; set; }
        public int int32Value { get; set; }
        public ObjectKey(string _objectType, int Val)
        {
            objectType = _objectType;

            int32Value = Val;
        }
    }
}
