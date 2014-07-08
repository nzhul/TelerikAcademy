using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCommon
{
    public class Player
    {
        private string name;
        private int score;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }      

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Player():this("", 0)
        {
        }
        public Player(string name, int score)
        {
            this.Name = name;
            this.Score = score;
        }
    }
}
