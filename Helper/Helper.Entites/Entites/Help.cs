using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Helper.Entites.Identity;
using System.ComponentModel;

namespace Helper.Entites.Entites
{
    public class Help
    {
        public Help()
        {
            this.Tags = new HashSet<Tag>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required] 
        public int HelpId { get; set; }

        [Required]
        public string HelpTitle { get; set; }

        [Required]
        public string HelpText { get; set; }

        [Required]
        public DateTime HelpDate { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool HelpCheck { get; set; }


        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }


        public Category Category { get; set; }
        public int CategoryId { get; set; }


        public ICollection<Answer> Answer { get; set; }


        public ICollection<Tag> Tags { get; set; }
    }
}
