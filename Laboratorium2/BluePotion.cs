using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class BluePotion : Weapon, IPotion
    {
        public bool Used { get; private set; }
        public BluePotion(Game game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override string Name { get { return "Blue Potion"; } }
        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(10, random);
            Used = true;
        }


    }
}
