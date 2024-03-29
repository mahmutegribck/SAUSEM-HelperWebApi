﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Helps.Dtos
{
    public class UpdateHelpDto
    {
        public string HelpTitle { get; set; }

        public string HelpText { get; set; }

        public DateTime HelpDate { get; set; }

        public int CategoryId { get; set; }
    }
}
