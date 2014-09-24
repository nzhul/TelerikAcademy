using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Models
{
    public class Guess
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public string Number { get; set; }
        public DateTime DateMade { get; set; }
        public int CowsCount { get; set; }
        public int BullsCount { get; set; }
    }
}
