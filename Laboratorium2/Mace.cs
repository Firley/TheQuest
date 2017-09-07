using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class Mace : Weapon
    {
        public Mace(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Mace"; } }
        public override void Attack(Direction direction, Random random)
        {
            int i = 3;
            while (i >= 0)
            {
                DamageEnemy(direction, 10, 7, random);
                direction = direction + 1;
                if ((int)direction > 3)
                {
                    direction = 0;
                }
                --i;
            }


        }
    }
}
