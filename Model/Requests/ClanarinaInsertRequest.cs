using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Requests
{
    public class ClanarinaInsertRequest
    {
        [Required]
        public DateTime DatumDodavanja { get; set; }
        [Required]
        public DateTime DatumIsteka { get; set; }
        public double Cijena { get; set; }
        public int KorisnikId { get; set; }
        [Required]
        public int TipClanarineId { get; set; }
    }
}
