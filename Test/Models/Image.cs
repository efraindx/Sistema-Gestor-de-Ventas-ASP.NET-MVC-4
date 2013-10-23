using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Required]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public string ImagePath { get; set; }
    }
}