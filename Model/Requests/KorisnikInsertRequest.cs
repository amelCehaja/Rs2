using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model.Requests
{
    public class KorisnikInsertRequest
    {
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZČčĆćŽžĐđŠš ]+$", ErrorMessage = "Dozvoljena su samo slova!")]
        [StringLength(50, ErrorMessage = "Maksimalna dozvoljena duzina je 50 karaktera!")]
        public string Ime { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[a-zA-ZČčĆćŽžĐđŠš ]+$", ErrorMessage = "Dozvoljena su samo slova!")]
        [StringLength(50, ErrorMessage = "Maksimalna dozvoljena duzina je 50 karaktera!")]
        public string Prezime { get; set; }
        public DateTime? DatumRodenja { get; set; }
        [Required(ErrorMessage = "Spol je obavezan!")]
        [StringLength(1, MinimumLength = 1)]
        [RegularExpression(@"[MŽ]")]
        public string Spol { get; set; }
        [Required(AllowEmptyStrings = false)]
        [RegularExpression(@"^[\w -\.] +@([\w -] +\.)+[\w-]{2,4}$")]
        public string Email { get; set; }
        [RegularExpression(@"^[0-9]+$")]
        public string Telefon { get; set; }
        [RegularExpression(@"^[0-9]+$")]
        [StringLength(8, MinimumLength = 8)]
        public string BrojKartice { get; set; }
        public byte[] Slika { get; set; }
        public string Uloga { get; set; }
        [Required(AllowEmptyStrings =false)]
        [MinLength(5)]
        public string Password { get; set; }
        [Required(AllowEmptyStrings =false)]
        [MinLength(5)]
        public string Username { get; set; }
    }
}
