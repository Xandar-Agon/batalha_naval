using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace batalha_naval
{
    class Player
    {
        private string Player_Name;
        private Board Player_Board;

        public Player(string name, int diff)
        {
            Player_Name = name;
            this.Player_Board = new Board(diff);
        }

        public string GetName()
        {
            return Player_Name;
        }

        public Board GetBoard()
        {
            return Player_Board;
        }
    }
}
