using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class Sword : Weapon
    {
        public Sword(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Sword"; } }
        public override void Attack(Direction direction, Random random)
        {
            if (!DamageEnemy(direction, 10, 3, random))
            {
                direction = (Direction)(direction + 1);
                if ((int)direction > 3)
                {
                    direction = (Direction)0;
                }
                if (!DamageEnemy(direction, 10, 3, random))
                {
                    direction = (Direction)(direction + 2);
                    if ((int)direction > 3)
                    {
                        direction = (Direction)0;
                    }
                    DamageEnemy(direction, 10, 5, random);
                }
            }



        }
    }
}
