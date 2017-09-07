using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location, Random random) : base(game, location, 6, random)
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
                    game.HitPlayer(2, random);
                    return;
                }
                else if (random.Next(0, 2) == 0)
                {
                    base.location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                }
                else if (random.Next(0, 2) == 0)
                {
                    Direction randomDirection = (Direction)random.Next(0, 3);
                    base.location = Move(randomDirection, game.Boundaries);
                }
                if (NearPlayer())
                {
                    game.HitPlayer(2, random);
                }
            }
            return;
        }


    }
}
