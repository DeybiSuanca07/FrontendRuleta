using System;
using System.Collections.Generic;

#nullable disable

namespace Ruleta.Models
{
    public partial class BetsRoulettesUser
    {
        public double? Bet { get; set; }
        public int? RouletteId { get; set; }
        public int? UserId { get; set; }
        public int IdBetRouletteUser { get; set; }

        public virtual Roulette Roulette { get; set; }
        public virtual User User { get; set; }
    }
}
