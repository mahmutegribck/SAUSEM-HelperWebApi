using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Entities.Entities
{
    public class Help
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int HelpId { get; set; }

        [Required]
        public string HelpTitle { get; set; }

        [Required]
        public string HelpCategory { get; set; }

        [Required]
        public string HelpTag { get; set; }

        [Required]
        public string HelpText { get; set; }

        // [Required]
        //public int UserId { get; set; }     
        public User User { get; set; }
    }
}
