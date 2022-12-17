using Helper.Entites.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Answers.Dtos
{

    public class CreateAnswerDto
    {
        public int AnswerId { get; set; }

        public string AnswerTitle { get; set; }

        public string AnswerText { get; set; }

        public DateTime AnswerDate { get; set; }

        //public Help Help { get; set; }

        //public int HelpId { get; set; }
    }
}
