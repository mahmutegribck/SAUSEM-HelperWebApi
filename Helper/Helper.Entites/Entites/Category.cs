using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Entites.Entites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Help> Helps { get; set; }
    }
}
