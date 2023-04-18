using System;
using System.Collections.Generic;

#nullable disable

namespace GameMaintenance.Models
{
    public partial class Registry
    {
        public int Id { get; set; }
        public string FelhasznaloNev { get; set; }
        public string TeljesNev { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
        public string Email { get; set; }
        public string Key { get; set; }
    }
}
