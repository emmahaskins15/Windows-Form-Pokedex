using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex
{
    internal class Caught
    {
        // Fields
        private int _id;
        private string _name;

        // Constructor
        public Caught()
        {
            _id = 0;
            _name = "";
        }

        public Caught(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}
