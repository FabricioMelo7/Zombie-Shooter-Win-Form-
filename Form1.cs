using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zombie_Shooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool goup; //This boolean will be used for the player to go up the screen
        bool godown; //This boolean will be used for the player to go down the screen
        bool goleft; //This boolean will be used for the player to go left the screen
        bool goright; //This boolean will be used for the player to go right the screen

        string facing = "up"; //this string is called facing and it will be used to guide the bullets
        double playerHealth = 100; //This double variable is called player health

        int speed = 10; //Speed of the player
        int ammo = 10; //Ammount of ammo the player have at the start of the game
        int zombieSpeed = 3; //Speed of the zombies
        int score = 0; // Player's score achieved in the game
        bool gameOver = false; //This boolean is false in the beginning and will be used when the game is finished

        Random random = new Random();   //Instance of the 'random' class and will be used to create a random number for this game



        

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (gameOver == true) return; //If the game is over then nothing will be executed in this event

             // If the left key is pressed, then the code bellow will be ran 
            if(e.KeyCode == Keys.Left)
            {
                goleft = true;
                facing = "left";
                player1.Image= Properties.Resources.left;
            }


            // If the right key is pressed, then the code bellow will be ran 
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
                facing = "right";
                player1.Image= Properties.Resources.right;

            }

            // If the up key is pressed, then the code bellow will be ran
            if (e.KeyCode == Keys.Up)
            {
                goup = true;
                facing = "up";
                player1.Image= Properties.Resources.up;

            }

            // If the down key is pressed, then the code bellow will be ran 
            if (e.KeyCode == Keys.Down)
            {
                godown = true;
                facing = "down";
                player1.Image = Properties.Resources.down;
            }



        }

        private void keyisup(object sender, KeyEventArgs e)
        {

            if (gameOver) return; //If the game is over then nothing will be executed in this event

            // below is the key up selection for the left key
            if (e.KeyCode == Keys.Left)
            {
                goleft = false; // change the go left boolean to false
            }

            // below is the key up selection for the right key
            if (e.KeyCode == Keys.Right)
            {
                goright= false; // change the go right boolean to false
            }

            // below is the key up selection for the up key
            if(e.KeyCode == Keys.Up)
            {
                goup= false; // change the go up boolean to false
            }

            // below is the key up selection for the down key
            if (e.KeyCode == Keys.Down)
            {
                goup = false; // change the go down boolean to false
            }

            //Below is the firing function, I will only include a KeyUp function for this because a KeyDown would allow the user to spam/hold space bar to fire.
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo --; //Everytime user shoots, ammo is reduced by 1
                shoot(facing); // This will pass 'facing'(Up, Down, Lef or Right) as an argument for the 'shoot' function to fire the weapon that direction


                if (ammo <= 1) //IF ammo is 1 or less
                {
                    dropAmmo(); //Involke the drop ammo function
                }
            }





        }

        private void gameEngine(object sender, EventArgs e)
        {

        }

        private void dropAmmo()
        {

        }

        private void shoot()
        {

        }

        private void makeZombies()
        {

        }
    }
}
