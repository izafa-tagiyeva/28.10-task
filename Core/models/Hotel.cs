using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.models
{
    public class Hotel
    {

        private static int _id = 0;
        public int Id { get; }
        public string Name { get; set; }

        public Hotel(string name)
        {

            Id = ++_id;
            Name = name;
        }

    }
}
/*Hotel class
-Id
- Name*/