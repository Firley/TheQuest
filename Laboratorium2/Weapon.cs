using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Laboratorium2
{
    abstract class Weapon : Mover
    {
        public bool PickedUp { get; private set; }
        public Weapon(Game game, Point location) : base(game, location)
        { PickedUp = false; }
        public void PickUpWeapon()
        {
            PickedUp = true;
        }
        public abstract string Name { get; }
        public abstract void Attack(Direction direction, Random random);

        protected bool Nearby(Point enemyLocation, Point target, int distance)
        {
            return (Math.Abs(enemyLocation.X - target.X) <= distance && (Math.Abs(enemyLocation.Y - target.Y) <= distance));
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            location = target;
             return Move(direction, boundaries);
        }

        protected virtual bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
            {
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location,target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

    }
}
