using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Laboratorium2
{
    class Bomb : Weapon, IItem
    {
        public Bomb(Game game, Point location) : base(game, location) { }
        public bool Used { get; private set; }
        public override string Name { get { return "Bomb"; } }
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
            target = Move(direction, target, game.Boundaries);
            return false;
        }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, 30, 20, random);
            Used = true;
        }
    }
}

