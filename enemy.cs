using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tudás_Harca
{
    internal class Enemy
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int dmg { get; set; }
        public string img { get; set; }

        public Enemy(string _name, int _hp, int _dmg, string _img)
        {
            this.name = _name;
            this.hp = _hp;
            this.dmg = _dmg;
            this.img = _img;
        }

        public void takeDamage(int dmgTaken)
        {
            this.hp -= dmg;
        }
    }
}
