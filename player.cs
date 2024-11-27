using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tudás_Harca
{
    internal class Player
    {

        public int hp { get; set; }
        public int dmg { get; set; }
        public string name { get; set; }

        public Player(int _hp, int _dmg, string _name)
        {
            hp = _hp;
            dmg = _dmg;
            name = _name;
        }

        public void takeDamage(int dmgTaken)
        {
            this.hp -= dmg;
        }
    }
}
