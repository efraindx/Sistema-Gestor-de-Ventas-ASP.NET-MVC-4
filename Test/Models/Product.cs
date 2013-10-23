using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        [Required]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public int ProductConditionID { get; set; }
        public virtual ProductCondition ProductCondition { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}