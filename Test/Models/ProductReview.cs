using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo requerido.")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        [Required(ErrorMessage = "Debe insertar un mensaje.")]
        public string Comment { get; set; }
        public string User { get; set; }
        public DateTime Date { get; set; }
        public int Rating { get; set; }
    }
}