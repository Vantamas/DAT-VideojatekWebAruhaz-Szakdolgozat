using System;
using System.Collections.Generic;

#nullable disable

namespace GameMaintenance.Models
{
    public partial class Osszesjatek
    {
        public Osszesjatek()
        {
            Kosars = new HashSet<Kosar>();
        }

        public int Id { get; set; }
        public string Nev { get; set; }
        public string Kategoria { get; set; }
        public int Ar { get; set; }
        public string Leiras { get; set; }
        public byte[] Kep { get; set; }
        public DateTime Megjelenes { get; set; }

        public virtual ICollection<Kosar> Kosars { get; set; }

    }
}
