using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Laboratorium2
{
    class Player : Mover
    {
        private Weapon equippedWeapon;
        public int HitPoints { get; private set; }
        private List<Weapon> inventory = new List<Weapon>();
        public bool PlayerShieldActive { get; private set; }

        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                {
                    names.Add(weapon.Name);
                }
                return names;
            }
        }
        public Player(Game game, Point location) : base(game, location)
        {
            HitPoints = 2000;
            PlayerShieldActive = false;
        }

        public void Hit(int maxDamage, Random random)
        {
            if (PlayerShieldActive)
            {
                HitPoints -= random.Next(1, maxDamage);
                HitPoints += random.Next(0, 2);
            }
            else
                HitPoints -= random.Next(1, maxDamage);
        }

        public void ActiveShield()
        {
            PlayerShieldActive = true;
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
            {
                if (weapon.Name == weaponName)
                {
                    equippedWeapon = weapon;
                }
            }
        }

        public void Move(Direction direction)
        {
            base.location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                if (Nearby(game.WeaponInRoom.Location, 25))
                {
                    game.WeaponInRoom.PickUpWeapon();
                    inventory.Add(game.WeaponInRoom);
                    if (inventory.Count == 1)
                    {
                        Equip(game.WeaponInRoom.Name);
                    }
                }
            }

        }

        public void Attack(Direction direction, Random random)
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.Attack(direction, random);
                if (equippedWeapon is IPotion)
                {
                    inventory.Remove(equippedWeapon);
                    if (inventory.Count > 0)
                    {
                        equippedWeapon = inventory[0];
                    }
                    else
                        equippedWeapon = null;
                }
                if (equippedWeapon is IItem)
                {
                    inventory.Remove(equippedWeapon);
                    if (inventory.Count > 0)
                    {
                        equippedWeapon = inventory[0];
                    }
                    else
                        equippedWeapon = null;
                    game.ActivePlayerShield();
                }
            }
        }


    }
}
