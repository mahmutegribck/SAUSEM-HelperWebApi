using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Helper.Entites.Entites
{
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        public ICollection<Help> Helps { get; set; }
    }
}
