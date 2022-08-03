using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{
    public class FormProp
    {
        public string PropName { get; set; }
        public string Value { get; set; }
        public Type Type { get; set; }
        public bool IsEdited { get; set; } = false;

        public FormProp(string name, object Obj)
        {
            PropName = name;

            Type = Obj.GetType();

            Value = Obj.ToString();
        }
    }
}
