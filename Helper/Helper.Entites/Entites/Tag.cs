using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Entites.Entites
{
    public class Tag
    {
        public Tag() 
        {
            this.Helps = new HashSet<Help>();
        }
        public int TagId { get; set; }  
        public string TagName { get; set; }

        public ICollection<Help> Helps { get; set; }
    }
}
