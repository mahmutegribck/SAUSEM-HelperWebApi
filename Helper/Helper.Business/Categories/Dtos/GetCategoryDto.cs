using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Business.Categories.Dtos
{
    public class GetCategoryDto
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
