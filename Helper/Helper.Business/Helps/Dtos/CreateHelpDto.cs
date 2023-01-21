using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Helper.Business.Helps.Dtos
{
    public class CreateHelpDto
    {
       // public int HelpId { get; set; }
        public string HelpTitle { get; set; }
        //public string HelpCategory { get; set; }
        public string HelpTag { get; set; }
        public string HelpText { get; set; }

        public int CategoryId { get; set; }

        //public User User { get; set; }
        //public Category Category { get; set; }
    }
}
