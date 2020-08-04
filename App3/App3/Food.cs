using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Food
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

        public override string ToString()
        {
            return Name + Note;
        }

        
    }
}
