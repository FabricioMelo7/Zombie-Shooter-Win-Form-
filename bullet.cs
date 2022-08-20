using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Zombie_Shooter
{
    internal class bullet
    {
        public string direction; //Creating publuic string called direction
        public int speed = 20; // this is the attack speed between each shot

        PictureBox Bullet = new PictureBox(); // Creating a new picture box for the bullet
        Timer tm = new Timer(); // A timer for the bullet.

        public int bulletLeft; //
        public int bulletTop;

        public void mkBullet(Form form)
        {
            // this function will add the bullet to the game play
            // it is required to be called from the main class
            // It uses variables from this class

            Bullet.BackColor = System.Drawing.Color.White; // set the colour white for the bullet
            Bullet.Size = new Size(5, 5); // set the size to the bullet to 5 pixel by 5 pixel
            Bullet.Tag = "bullet"; // set the tag to bullet
            Bullet.Left = bulletLeft;  // set bullet left distance
            Bullet.Top = bulletTop; // set bullet top distance
            Bullet.BringToFront(); // bring the bullet to front of other objects
            form.Controls.Add(Bullet); // add the bullet to the screen

            tm.Interval = speed; // set the timer interval to speed
            tm.Tick += new EventHandler(tm_Tick); // Assign the timer tick with an event
            tm.Start(); // start the timer as soon as the bullet is fired


        }

        public void tm_Tick(Object sender, EventArgs e)
        {
            //The switch statement identifies the direction the bullet will be fired towards
            switch (direction)
            {
                case "left":
                    Bullet.Left -= speed;
                    break;

                case "right":
                    Bullet.Left += speed;
                    break;

                case "up":
                    Bullet.Top -= speed;
                    break;

                case "down":
                    Bullet.Top += speed;
                    break;
            }

            // if the bullet is less the 16 pixel to the left OR
            // if the bullet is more than 860 pixels to the right OR
            // if the bullet is 10 pixels from the top OR
            // if the bullet is 616 pixels to the bottom OR
            // IF ANY ONE OF THE CONDITIONS ARE MET THEN THE FOLLOWING CODE WILL BE EXECUTED

            if (Bullet.Left < 16 || Bullet.Left > 860 || Bullet.Top < 10 || Bullet.Top > 616)
            {
                tm.Stop(); // stop the timer
                tm.Dispose(); // dispose the timer event and component from the program
                Bullet.Dispose(); // dispose the bullet
                tm = null;  // nullify the timer object
                Bullet = null;  // nullify the bullet object
            }



        }

    }
}
