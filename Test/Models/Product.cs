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
        [Required(ErrorMessage = "Campo requerido.")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public int ProductConditionID { get; set; }
        public virtual ProductCondition ProductCondition { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public double Price { get; set; }
        public string Owner { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int RatingPercent { get; set; }
    }
}