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
        public string HelpTitle { get; set; }
        public string HelpText { get; set; }
        public int CategoryId { get; set; }

    }
}
