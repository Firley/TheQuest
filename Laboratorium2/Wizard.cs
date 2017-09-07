using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class Wizard : Enemy
    {
        public Wizard(Game game, Point location, Random random) : base(game, location, 10, random)
        { }

        public override void Move(Random random)
        {
            if (this.Dead)
            {
                return;
            }
            if (game.PlayerHitPoints >= 1)
            {
                if (NearPlayer())
                {
                    game.HitPlayer(4, random);
                    return;
                }
                base.location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                if (NearPlayer())
                {
                    game.HitPlayer(4, random);
                }
            }
            return;
        }

    }
}

