using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderForm
{
    public class user
    {
        public string id { get; set; }
        public string name { get; set; }

        public user(string ID, string name)
        {
            this.id = ID;
            this.name = name;
        }
    }
}
