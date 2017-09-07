using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class Axe : Weapon
    {
        public Axe(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Axe"; } }
        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, 10, 5, random))
            {
                direction = direction + 1;
                if ((int)direction > 3)
                {
                    direction = 0;
                }
                DamageEnemy(direction, 10, 5, random);
            }
        }
    }
}
