using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class Shield : Weapon, IItem
    {
        public bool Used { get; private set; }
        public Shield(Game game, Point location) : base(game, location)
        {
            Used = false;
        }

        public override string Name { get { return "Shield"; } }
        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(5, random);
            game.ActivePlayerShield();
            Used = true;
            
        }
    }
}
