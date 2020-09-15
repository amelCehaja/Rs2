using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class SetVjezba
    {
        public int Id { get; set; }
        public int BrojPonavljanja { get; set; }
        public int RedniBroj { get; set; }
        public int? TrajanjeOdmora { get; set; }
        public int VjezbaId { get; set; }
    }
}
