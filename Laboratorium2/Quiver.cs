using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    class Quiver : Bow
    {
        public Quiver(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Bow"; } }

        protected override bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 10; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Attack(Direction direction, Random random)
        {
            for (int i = 0; i < 3; i++)
            {
                DamageEnemy(direction, 30, 2, random);
            }
        }
    }
}
