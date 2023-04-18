using System;
using System.Collections.Generic;

#nullable disable

namespace GameMaintenance.Models
{
    public partial class Kosar
    {
        public int Id { get; set; }
        public int VasarloId { get; set; }
        public int JatekId { get; set; }
        public int Darab { get; set; }

        public virtual Osszesjatek Jatek { get; set; }
        public virtual Felhasznalok Vasarlo { get; set; }
    }
}
