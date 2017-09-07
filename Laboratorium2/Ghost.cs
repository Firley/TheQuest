using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location, Random random) : base(game,location,8,random)
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
                    game.HitPlayer(3, random);
                    return;
                }
                if(random.Next(0, 2) == 0)
                {
                    base.location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
                }
                if (NearPlayer())
                {
                    game.HitPlayer(3, random);
                }
            }
            return;
        }
    }
}
