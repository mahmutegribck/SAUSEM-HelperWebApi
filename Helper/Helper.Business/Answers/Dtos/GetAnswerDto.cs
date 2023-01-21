using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Business.Answers.Dtos
{
    public class GetAnswerDto
    {
        public int AnswerId { get; set; }

        public int HelpId { get; set; }

        public string AnswerTitle { get; set; }

        public string AnswerText { get; set; }

        public DateTime AnswerDate { get; set; }

    }
}
