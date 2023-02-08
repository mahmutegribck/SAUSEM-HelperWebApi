using Helper.Business.Users.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Helps.Dtos
{
    public class GetHelpDto
    {
        public int HelpId { get; set; }
        public string HelpTitle { get; set; }
        public string HelpText { get; set; }
        public DateTime HelpDate { get; set; }
        public bool HelpCheck { get; set; }
        public int CategoryId { get; set; }
        public string ApplicationUserId { get; set; }

    }
}