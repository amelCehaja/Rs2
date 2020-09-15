using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Requests
{
    public class TipClanarineInsertRequest
    {
        [Required]
        [StringLength(25)]
        public string Naziv { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public double Cijena { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int Trajanje { get; set; }
    }
}
