using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeRequestWebApp.Models
{
    public class MakeRequest
    {
        public ChangeSet ChangeSet { get; set; }

        public MakeRequest(HashSet<FormProp> _Changes)
        {
            ChangeSet = new ChangeSet();

            ChangeSet.Changes = new List<string>();

            ChangeSet.Updated = new Dictionary<string, string>();

            foreach (FormProp prop in _Changes)
            {
                Console.WriteLine("_Changes: " + prop.PropName + " " + prop.Value);

                ChangeSet.Changes.Add(prop.PropName);

                ChangeSet.Updated.Add(prop.PropName, prop.Value);
            }
        }
    }

    public class ChangeSet
    {
        public List<string> Changes { get; set; }

        public Dictionary<string, string> Updated { get; set; }


    }
}
