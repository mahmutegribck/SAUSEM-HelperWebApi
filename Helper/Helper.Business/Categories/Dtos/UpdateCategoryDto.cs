using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Categories.Dtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
