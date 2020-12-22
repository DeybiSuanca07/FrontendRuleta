using System;
using System.Collections.Generic;

#nullable disable

namespace Ruleta.Models
{
    public partial class Roulette
    {
        public Roulette()
        {
            BetsRoulettesUsers = new HashSet<BetsRoulettesUser>();
        }

        public string Name { get; set; }
        public bool? Status { get; set; }
        public int IdRoulette { get; set; }

        public virtual ICollection<BetsRoulettesUser> BetsRoulettesUsers { get; set; }
    }
}
