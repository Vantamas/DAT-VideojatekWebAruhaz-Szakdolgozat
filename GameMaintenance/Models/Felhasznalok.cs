using System;
using System.Collections.Generic;

#nullable disable

namespace GameMaintenance.Models
{
    public partial class Felhasznalok
    {
        public Felhasznalok()
        {
            Kosars = new HashSet<Kosar>();
        }

        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public int Jogosultsag { get; set; }
        public int Aktiv { get; set; }

        public virtual ICollection<Kosar> Kosars { get; set; }
    }
}
