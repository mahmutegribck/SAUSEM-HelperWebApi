using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Helper.Entites.Identity;

namespace Helper.Entites.Entites
{

    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AnswerId { get; set; }

        [Required]
        public string AnswerTitle { get; set; }

        [Required]
        public string AnswerText { get; set; }

        [Required]
        public DateTime AnswerDate { get; set; }



        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public Help Help { get; set; }
        public int HelpId { get; set; }



    }
}
