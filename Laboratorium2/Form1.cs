using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorium2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Game game;
        private Random random = new Random();

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(145, 75, 880, 250), random);
            game.NewLevel(random);
            UpdateCharacters();
        }

        public void UpdateCharacters()
        {
            playerPicture.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            int enemiesShown = ShowEnemies();
            ShowWeapons();

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You have been defeated.");
                Application.Exit();
            }
            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeat all enemy at this level.");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private int ShowEnemies()
        {
            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            bool showWizard = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    batPicture.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghost)
                {
                    ghostPicture.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghoul)
                {
                    ghostPicture.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                else
                {
                    wizardPicture.Location = enemy.Location;
                    wizardHitPoints.Text = enemy.HitPoints.ToString();
                }
            }

            if (showBat == false)
            {
                batPicture.Visible = false;
                batLabel.Text = "";
                batHitPoints.Text = "";
            }
            else
            {
                batPicture.Visible = true;
                batLabel.Text = "Bat";
            }

            if (showGhost == false)
            {
                ghostPicture.Visible = false;
                ghostLabel.Text = "";
                ghostHitPoints.Text = "";
            }
            else
            {
                ghostPicture.Visible = true;
                ghostLabel.Text = "Ghost";
            }

            if (showGhoul == false)
            {
                ghoulPicture.Visible = false;
                ghoulLabel.Text = "";
                ghoulHitPoints.Text = "";
            }
            else
            {
                ghoulPicture.Visible = true;
                ghoulLabel.Text = "";
            }
            if (showWizard == false)
            {
                wizardPicture.Visible = false;
                wizardLabel.Text = "";
                wizardHitPoints.Text = "";
            }
            else
            {
                wizardPicture.Visible = true;
                wizardLabel.Text = "";
            }

            return enemiesShown;
        }

        void ShowWeapons()
        {
            swordPicture.Visible = false;
            bowPicture.Visible = false;
            redPotionPicture.Visible = false;
            machePicture.Visible = false;
            axePicture.Visible = false;
            bombPicture.Visible = false;
            quiverPicture.Visible = false;
            shieldInventoryPicture.Visible = false;
            Control weaponControl = null;

            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = swordPicture;
                    break;
                case "Bow":
                    weaponControl = bowPicture;
                    break;
                case "Red Potion":
                    weaponControl = redPotionPicture;
                    break;
                case "Blue Potion":
                    weaponControl = bluePotionPicture;
                    break;
                case "Mace":
                    weaponControl = machePicture;
                    break;
                case "Axe":
                    weaponControl = axePicture;
                    break;
                case "Bomb":
                    weaponControl = bombPicture;
                    break;
                case "Quiver":
                    weaponControl = quiverPicture;
                    break;
                case "Shield":
                    weaponControl = shiledPicture;
                    break;
            }

            swordInventoryPicture.Visible = game.CheckPlayerInventory("Sword");
            bowInventoryPicture.Visible = game.CheckPlayerInventory("Bow");
            redPotionInventoryPicture.Visible = game.CheckPlayerInventory("Red Potion");
            bluePotionInventoryPicture.Visible = game.CheckPlayerInventory("Blue Potion");
            maceInventoryPicture.Visible = game.CheckPlayerInventory("Mace");
            axeInventoryPicture.Visible = game.CheckPlayerInventory("Axe");
            quiverInventoryPicture.Visible = game.CheckPlayerInventory("Quiver");
            shieldInventoryPicture.Visible = game.CheckPlayerInventory("Shield");

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
            {
                weaponControl.Visible = false;
            }
            else
            {
                weaponControl.Visible = true;
            }
        }

        private BorderStyle InventoryPicturesBorderStyle()
        {
            swordInventoryPicture.BorderStyle = BorderStyle.None;
            bowInventoryPicture.BorderStyle = BorderStyle.None;
            maceInventoryPicture.BorderStyle = BorderStyle.None;
            axeInventoryPicture.BorderStyle = BorderStyle.None;
            bombInventoryPicture.BorderStyle = BorderStyle.None;
            redPotionInventoryPicture.BorderStyle = BorderStyle.None;
            bluePotionInventoryPicture.BorderStyle = BorderStyle.None;
            quiverInventoryPicture.BorderStyle = BorderStyle.None;
            shieldInventoryPicture.BorderStyle = BorderStyle.None;
            return BorderStyle.FixedSingle;
        }

        private void InventoryPitureSettings(string name, PictureBox inventoryPicture)
        {
            if (game.CheckPlayerInventory(name))
            {
                game.Equip(name);
                inventoryPicture.BorderStyle = InventoryPicturesBorderStyle();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void swordInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Sword", swordInventoryPicture);
        }

        private void bowInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Bow", swordInventoryPicture);
        }

        private void maceInventoryPicrue_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Mace", swordInventoryPicture);
        }

        private void axeInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Axe", swordInventoryPicture);
        }

        private void bombInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Bomb", swordInventoryPicture);
        }

        private void redPotionInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Red Potion", swordInventoryPicture);
        }

        private void bluePotionInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Blue Potion", swordInventoryPicture);
        }

        private void quiverInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Quiver", swordInventoryPicture);
        }

        private void shieldInventoryPicture_Click(object sender, EventArgs e)
        {
            InventoryPitureSettings("Shield", swordInventoryPicture);
        }

        private void upMove_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void rightMove_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void downMove_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void leftMove_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void upAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void rightAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void downAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void leftAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }
    }
}
