using System;
using System.Collections.Generic;

#nullable disable

namespace Ruleta.Models
{
    public partial class User
    {
        public User()
        {
            BetsRoulettesUsers = new HashSet<BetsRoulettesUser>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public double? Credit { get; set; }
        public bool Status { get; set; }
        public int IdUser { get; set; }

        public virtual ICollection<BetsRoulettesUser> BetsRoulettesUsers { get; set; }
    }
}
