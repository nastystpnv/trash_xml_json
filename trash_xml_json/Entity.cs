using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trash_xml_json
{
    public class Entity
    {
        public string Name { get; set; }
        public Dictionary<string, string> Properties { get; set; }
        public Entity()
        {
            Properties = new Dictionary<string, string>();
        }
        public Entity(string name)
        {
            Name = name;
            Properties = new Dictionary<string, string>();
        }
    }
}
