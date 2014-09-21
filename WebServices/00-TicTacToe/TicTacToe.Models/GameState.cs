namespace TicTacToe.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum GameState
    {
        WaitingForSecondPayer = 0,
        TurnX = 1,
        TurnO = 2,
        WonByX = 3,
        WonByO = 4,
        Draw = 5
    }
}
