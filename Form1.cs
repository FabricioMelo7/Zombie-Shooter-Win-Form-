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
            RestartGame();
           
        }
        #region VARIABLES
        bool goup; //This boolean will be used for the player to go up the screen
        bool godown; //This boolean will be used for the player to go down the screen
        bool goleft; //This boolean will be used for the player to go left the screen
        bool goright; //This boolean will be used for the player to go right the screen

        string facing = "up"; //this string is called facing and it will be used to guide the bullets
        int playerHealth = 100; //This double variable is called player health

        int speed = 10; //Speed of the player
        int ammo = 10; //Ammount of ammo the player have at the start of the game
        int zombieSpeed = 3; //Speed of the zombies
        int killScore = 0; // Player's score achieved in the game        

        int healPackNumber = 0;

        bool gameOver = false; //This boolean is false in the beginning and will be used when the game is finished
        List<PictureBox> heakthList = new List<PictureBox>();
        List<PictureBox> zombieList = new List<PictureBox>();
        Random random = new Random();   //Instance of the 'random' class and will be used to create a random number for this game

        
        
        #endregion



        #region KEY PRESS EVENTS
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

            //if (gameOver) return; //If the game is over then nothing will be executed in this event

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
                godown = false; // change the go down boolean to false
            }

            //Below is the firing function, I will only include a KeyUp function for this because a KeyDown would allow the user to spam/hold space bar to fire.
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo --; //Everytime user shoots, ammo is reduced by 1
                //shoot(facing); // This will pass 'facing'(Up, Down, Lef or Right) as an argument for the 'shoot' function to fire the weapon that direction
                shoot(facing);

                if (ammo <= 1) //IF ammo is 1 or less
                {
                    dropAmmo(); //Involke the drop ammo function
                }
                                
            }
            /*
             *The Code bellow drops a health pack for the player when his ehalth reaches 30
             *I implemented that once his hp reaches 30, the hp goes to 31 so that the if statement only allows one health pack to spawn,
             *Otherwise they would keep spawning until his hp went above 30
             */
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                if (playerHealth < 30 && gameOver == false && healPackNumber == 0)
                {
                    dropHeal();
                    healPackNumber++;

                }
                
                
            }

            //The code bellow restarts the game. Once the conditions are met, the "RestartGame" function is called
            if (e.KeyCode == Keys.Enter && gameOver== true)
            {
                RestartGame();
            }

        }
        #endregion


        private void gameEngine(object sender, EventArgs e) // This section could be considered "functionality rules" of the game, such as when hp hits 0, the game ends
        {

            if (playerHealth >= 1) // if player health is greater than 1
            {
                progressBar1.Maximum = 100; // Giving a maximum value to the HP bar, prevents an exception from happening.(Hp going above the maximum "Limit" )
                progressBar1.Value = playerHealth; // assign the progress bar to the player health integer
               
            }
            else //If Player is dead...
            {
                //if the player health is below 1/ THE PLAYER IS DEAD
                player1.Image = Properties.Resources.dead; //The player's image will be set to the 'dead'
                timer1.Stop(); // stop the timer
                gameOver = true; // change game over to true
            }

            ammoLabel.Text = "Ammo: " + ammo; // Shows the ammount of ammo on the ammoLabel
            killsLabel.Text = "Kills: " + killScore; // show the total kills on the killsLabel


            #region Health Bar
            //Bellow is Changing the colour of the health bar depending on the ammount of health
            // if the player's health is above 50, health bar is green            

            switch (playerHealth)
            {
                case int n when (n >= 45):
                    progressBar1.ForeColor = Color.Green;
                    break;

                case int n when (n <= 46):
                    progressBar1.ForeColor = Color.Red;
                    break;
            }
            //If the player's health is bellow 50, health bar is red
                  




            #endregion

            #region Player Movement
            //Moving the player to the left (.left refers to the left edge of player1 sprite and the distance to the border of the screen to its left )
            if (goleft == true && player1.Left > 0)
            {
                
                player1.Left -= speed; //This will reduce the distance of player1's left border and the edge of the screen by the value of 'speed'. 
                                        //This will then move the player towards the border of the screen.
            }

            //Moving to the right( if the calculation of the .left and the player1 totalwith is less than the client total with)
            //?????????????????????????????????? WTF IS THE DEAL TIH player1.left + player.Width ????????
            #region "player1.Left + player1.Width" ?????
            /* The method's arguments seems very counter intuitive. At first I thought simply using (player1.Right > 0) 
             * would work as it made sense, but 
             * when I tried to implement the 'player1.Right -= speed', I was given an error where it says that "control.Right is read only". 
             * I could't see how to change the 'write' permission innitially, and even if I forced a way around this, it would eventually take 
             * longer to write and might
             * come up with bugs of its on. For now I will keep the "player1.Left + player.Width < 930" and try to fully understand it later on.
             */
            #endregion
            if (goright == true && player1.Left + player1.Width < 930) 
            {
                                
                player1.Left += speed;
            }

            //Moving the player upwards
            if (goup == true && player1.Top > 55)
            {
                player1.Top -= speed;
            }

            //Moving the player down
            if (godown == true && player1.Top + player1.Height < 675)
            {
                player1.Top += speed;
            }
            #endregion

            //The code bellow is for the mechanic of picking up ammo, Zombie movements, Giving ammo to the player and removing the ammo from the map
            #region LOOP 1 mechanics
            /*
             * The foreach loop will keep looping through and check if the conditions are met in order to execute the code within it.
             * The loop will in a way, name every object it is looking at as "x". I looks at it and if the conditions are not met, it moves on to the next one.
             */
            // run the first for each loop below
            // X is a control(object) and we will search for all controls in this loop
            foreach (Control x in this.Controls)
            {
                // if the X is a picture box and X has a tag AMMO
                if (x is PictureBox && x.Tag == "ammo")
                {
                    // check if x is hitting the player picture box
                    if (((PictureBox)x).Bounds.IntersectsWith(player1.Bounds)) //VERY INTERSTING METHOD TO DETERMINE SOME SORT OF COLLISION OF 2 ITEMS
                    {
                        // once the player picks ammo,
                        this.Controls.Remove((PictureBox)x); // remove the ammo picture box

                        ((PictureBox)x).Dispose(); // dispose the picture box completely from the program
                        ammo += 5; //add 5 ammo to the integer and the player
                    }
                }

                //This is check if the player walked into a health pack and heal the player
                if (x is PictureBox && x.Tag == "heal")// Identifies a picture box with the "heal" tag
                {
                    if (gameOver == true) { ((PictureBox)x).Dispose(); this.Controls.Remove((PictureBox)x); } // This removes healthPacks from the screen once the player dies

                    if (((PictureBox)x).Bounds.IntersectsWith(player1.Bounds))// Checks if the player is within bounds of the healthPack
                    {
                        this.Controls.Remove((PictureBox)x); //Removes the healPack from screen

                        ((PictureBox)x).Dispose(); //Removes the healthPack data from the system
                        playerHealth += 30; // Heals the player by 30
                        healPackNumber--;
                                               
                        
                    }
                }

                // if the bullets hits the 4 borders of the game
                // if x is a picture box and x has the tag of bullet

                if (x is PictureBox && x.Tag == "bullet")
                {
                    // if the bullet is less than 1 pixel to the left
                    // if the bullet is more than 930 pixels to the right
                    // if the bullet is 10 pixels from the top
                    // if the bullet is 700 pixels to the buttom

                    if (((PictureBox)x).Left < 1 || ((PictureBox)x).Left > 930 || ((PictureBox)x).Top < 10 || ((PictureBox)x).Top > 700)
                    {
                        this.Controls.Remove(((PictureBox)x)); //Remove the bullet from the display
                        ((PictureBox)x).Dispose(); //Dispose the bullet from the program

                    }
                }

                // below is the if statement which will be checking if the player hits a zombie

                if (x is PictureBox && x.Tag == "zombie")
                {
                    // below is the if statament thats checking the bounds of the player and the zombie

                    if (((PictureBox)x).Bounds.IntersectsWith(player1.Bounds))
                    {
                        playerHealth -= 1; // if the zombie hits the player then we decrease the health by 1 every second
                    }

                    //move zombie towards the player picture box
                    if (((PictureBox)x).Left > player1.Left) // If the distance between the zombie left side to edge of screen is bigger-
                                                             // -than the distance between the player's left side to the edge of screen
                                                             // The zombie on the right of the player will target the player's left side
                    {
                        ((PictureBox)x).Left -= zombieSpeed;    // move zombie towards the left of the player
                        ((PictureBox)x).Image = Properties.Resources.zleft; // change the zombie image to the left
                    }

                    if (((PictureBox)x).Right < player1.Right) //MOVE ZOMBIES TO THE RIGHT
                    {
                        ((PictureBox)x).Left += zombieSpeed;    // move zombie towards the right of the player
                        ((PictureBox)x).Image = Properties.Resources.zright;    // change the image to the right image

                    }

                    if (((PictureBox)x).Top > player1.Top) // MOVE THE ZOMBIES TO THE TOP
                    {
                        ((PictureBox)x).Top -= zombieSpeed;// move zombie upwards towards the players top
                        ((PictureBox)x).Image = Properties.Resources.zup; //change the zombie picture to the top pointing image
                    }

                    if (((PictureBox)x).Top < player1.Top) // MOVE THE ZOMBIES TO THE BOTTOM
                    {
                        ((PictureBox)x).Top += zombieSpeed; // move the zombie towards the bottom of the player
                        ((PictureBox)x).Image= Properties.Resources.zdown; // change the image to the down zombie
                    }
                }

                //The code bellow is the second loop, this is nested inside the first loop
                // The bullet and zombie needs to be different than each other
                // And then I can determine if they hit eachother.

                foreach (Control k in this.Controls)
                {
                    // The if statement bellow identifies the bullet and zombie
                    if ((k is PictureBox && k.Tag == "bullet") && (x is PictureBox && x.Tag == "zombie"))
                    {
                        // The if statement bellow checkes if the bullet has hit the zombie
                        if (x.Bounds.IntersectsWith(k.Bounds))
                        {
                            killScore++; //Increase the kill score by 1

                            this.Controls.Remove(k); // the "this." reffers the code the bullet which hit zombie, and then removes it form the screen
                            k.Dispose(); //This removes the bullet from the program all together

                            this.Controls.Remove(x); //The "this." reffers the code to the zombie that was hit by the bullet in the if statement, and removes it from the screen
                            x.Dispose(); //This removes the zombie from the program all together
                            zombieList.Remove(((PictureBox)x));
                            makeZombies(); //This function will be called to create another zombie in the screen after the other one have been killed.


                        }
                    }
                }

            }
             #endregion

        }

        private void dropAmmo()
        {
            //This functions creates an ammo image in the game

            PictureBox ammo = new PictureBox();// create a new instance of the picture box
            ammo.Image = Properties.Resources.ammo_Image; // assignment the ammo image to the picture box
            ammo.SizeMode = PictureBoxSizeMode.AutoSize; // set the size to auto size
            ammo.Left = random.Next(10, 890); // set the location to a random left
            ammo.Top = random.Next(50, 600); // set the location to a random top
            ammo.Tag = "ammo"; // set the tag to ammo
            this.Controls.Add(ammo); // add the ammo picture box to the screen
            ammo.BringToFront(); // bring it to front
            player1.BringToFront(); // bring the player to front

        }

        private void shoot(string direct)
        {
            //This function creates new bullets in the game
            if (gameOver != true)
            {
                bullet shoot = new bullet(); // create a new instance of the bullet class
                shoot.direction = direct; // assignment the direction to the bullet
                shoot.bulletLeft = player1.Left + (player1.Width / 2); // place the bullet to left half of the player
                shoot.bulletTop = player1.Top + (player1.Height / 2); // place the bullet on top half of the player
                shoot.mkBullet(this); //Involke the mkBullet frok the class, giving "this" form as the argument
            }

        }

        private void makeZombies()
        {

            // when this function is called it will make zombies in the game

            PictureBox zombie = new PictureBox();// create a new picture box called zombie
            zombie.Image = Properties.Resources.zdown; // the default picture for the zombie is zdown
            zombie.Tag = "zombie"; // add a tag to it called zombie
            zombie.Left = random.Next(0, 900);  // generate a number between 0 and 900 and assignment that to the new zombies left
            zombie.Top = random.Next(0, 800);  // generate a number between 0 and 800 and assignment that to the new zombies top
            zombie.SizeMode = PictureBoxSizeMode.AutoSize; // set auto size for the new picture box
            zombieList.Add(zombie);
            this.Controls.Add(zombie);   // add the picture box to the screen
            player1.BringToFront();  // bring the player to the front

        }

        private void dropHeal()
        {
            //This functions creates an Heal image in the game

            PictureBox heal = new PictureBox();// create a new instance of the picture box
            heal.Image = Properties.Resources.heal; // assignment the heal image to the picture box
            heal.SizeMode = PictureBoxSizeMode.AutoSize; // set the size to auto size
            heal.Left = random.Next(10, 890); // set the location to a random left
            heal.Top = random.Next(50, 600); // set the location to a random top
            heal.Tag = "heal"; // set the tag to heal
            this.Controls.Add(heal); // add the heal picture box to the screen
            heal.BringToFront(); // bring it to front
            player1.BringToFront(); // bring the player to front

        }


        //The method bellow is used to restart the game.
        //The method restart some variables, clears zombies from the screen, Make other zombies and restarts the timer
        private void RestartGame()
        {
            player1.Image = Properties.Resources.up;

            foreach (PictureBox i in zombieList)
            {
                this.Controls.Remove(i);

            }

            zombieList.Clear();

            for(int i = 0; i < 3; i++)
            {
                makeZombies();
            }

            goup = false;
            godown = false;
            goleft = false;
            goright = false;
            gameOver = false;
            healPackNumber = 0;

            playerHealth = 100;
            killScore = 0;
            ammo = 10;

            timer1.Start();
            
        }


        private void ammoLabel_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
                     



        }
    }
}
