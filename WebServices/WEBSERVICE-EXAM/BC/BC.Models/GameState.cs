using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Models
{
    public enum GameState
    {
        WaitingForOpponent = 0,
        TurnBlue = 1,
        TurnRed = 2,
        WonByBlue = 3,
        WonByRed = 4,
        Draw = 5
    }
}
