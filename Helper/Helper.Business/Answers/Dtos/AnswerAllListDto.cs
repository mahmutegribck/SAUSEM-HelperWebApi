using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.Business.Answers.Dtos
{
    public class AnswerAllListDto
    {
        public int AnswerId { get; set; }

        public string AnswerTitle { get; set; }

        public string AnswerText { get; set; }

        public DateTime AnswerDate { get; set; }

        public int HelpId { get; set; }
    }
}
