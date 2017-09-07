using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Laboratorium2
{
    class Game
    {
        public IEnumerable<Enemy> Enemies { get; private set; }
        public Weapon WeaponInRoom { get; private set; }

        private Player player;
        public Point PlayerLocation { get {return player.Location; } }
        public int PlayerHitPoints { get { return player.HitPoints; } }
        public IEnumerable<string> PlayerWeapons { get { return player.Weapons; } }

        private int level = 0;
        public int Level { get { return level; } }

        private Rectangle boundaries;
        public Rectangle Boundaries { get { return boundaries; } }

        public Game(Rectangle boundaries,Random random)
        {
            this.boundaries = boundaries;
            player = new Player(this, this.GetRandomLocation(random));
        }
        public void  Move(Direction direction, Random random)
        {
            player.Move(direction);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        public void Equip(string weaponName)
        {
            player.Equip(weaponName);
        }

        public bool CheckPlayerInventory(string weaponName)
        {
            return player.Weapons.Contains(weaponName);
        }

        public void HitPlayer(int maxDamage, Random random)
        {
            player.Hit(maxDamage, random);
        }

        public void ActivePlayerShield()
        {
            player.ActiveShield();
        }

        public void IncreasePlayerHealth(int health, Random random)
        {
            player.IncreaseHealth(health, random);
        }

        public void Attack(Direction direction, Random random)
        {
            player.Attack(direction,random);
            foreach (Enemy enemy in Enemies)
            {
                enemy.Move(random);
            }
        }

        private Point GetRandomLocation(Random random)
        {
            return new Point(boundaries.Left + random.Next(boundaries.Right / 10 - boundaries.Left / 10) * 10,
                boundaries.Top + random.Next(boundaries.Bottom / 10 - boundaries.Top / 10) * 10);
        }


        public void NewLevel(Random random)
        {
            level++;
            switch(level)
            {
                case 1:
                    Enemies = new List<Enemy>() {new Bat(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Sword(this, GetRandomLocation(random));
                    break;
                case 2:
                    Enemies = new List<Enemy>() {new Bat(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Shield(this, GetRandomLocation(random));
                    break;
                case 3:
                    Enemies = new List<Enemy>() {new Ghost(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    break;
                case 4:
                    Enemies = new List<Enemy>() { new Ghoul(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    break;
                case 5:
                    Enemies = new List<Enemy>() { new Bat(this, GetRandomLocation(random), random), new Ghost(this, GetRandomLocation(random), random) };
                    if (!CheckPlayerInventory("Bow"))
                    {
                        WeaponInRoom = new Bow(this, GetRandomLocation(random));
                    }
                    else
                    {
                        WeaponInRoom = new BluePotion(this, GetRandomLocation(random));
                    }
                    break;
                case 6:
                    Enemies = new List<Enemy>() { new Bat(this, GetRandomLocation(random), random), new Ghoul(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    break;
                case 7:
                    Enemies = new List<Enemy>() { new Ghost(this, GetRandomLocation(random), random), new Ghoul(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    break;
                case 8:
                    Enemies = new List<Enemy>() { new Bat(this, GetRandomLocation(random), random), new Ghost(this, GetRandomLocation(random), random), new Ghoul(this, GetRandomLocation(random), random) };
                    if (!CheckPlayerInventory("Mace"))
                    {
                        WeaponInRoom = new Mace(this, GetRandomLocation(random));
                    }
                    else
                    {
                        WeaponInRoom = new RedPotion(this, GetRandomLocation(random));
                    }
                    break;
                case 9:
                    Enemies = new List<Enemy>() { new Wizard(this, GetRandomLocation(random),random) };
                    WeaponInRoom = new Axe(this, GetRandomLocation(random));
                    break;
                case 10:
                    Enemies = new List<Enemy>() { new Wizard(this, GetRandomLocation(random), random), new Bat(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Quiver(this, GetRandomLocation(random));
                    break;
                case 11:
                    Enemies = new List<Enemy>() { new Wizard(this, GetRandomLocation(random), random), new Ghoul(this, GetRandomLocation(random), random) };
                    WeaponInRoom = new Bomb(this, GetRandomLocation(random));
                    break;
                case 12:
                    Application.Exit();
                    break;
            }
        }
    }
}
