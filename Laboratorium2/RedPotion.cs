using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class RedPotion : Weapon, IPotion
    {
        public bool Used { get; private set; }
        public RedPotion(Game game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override string Name { get { return "Red Potion"; } }
        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(12, random);
            Used = true;
        }
    }
}
