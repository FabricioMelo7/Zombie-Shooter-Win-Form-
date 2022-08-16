namespace Zombie_Shooter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ammoLabel = new System.Windows.Forms.Label();
            this.killsLabel = new System.Windows.Forms.Label();
            this.healthLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.zombie1 = new System.Windows.Forms.PictureBox();
            this.zombie2 = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.zombie3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.zombie1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie3)).BeginInit();
            this.SuspendLayout();
            // 
            // ammoLabel
            // 
            this.ammoLabel.AutoSize = true;
            this.ammoLabel.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ammoLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ammoLabel.Location = new System.Drawing.Point(22, 9);
            this.ammoLabel.Name = "ammoLabel";
            this.ammoLabel.Size = new System.Drawing.Size(102, 28);
            this.ammoLabel.TabIndex = 0;
            this.ammoLabel.Text = "Ammo: 0";
            this.ammoLabel.Click += new System.EventHandler(this.ammoLabel_Click);
            // 
            // killsLabel
            // 
            this.killsLabel.AutoSize = true;
            this.killsLabel.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killsLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.killsLabel.Location = new System.Drawing.Point(348, 9);
            this.killsLabel.Name = "killsLabel";
            this.killsLabel.Size = new System.Drawing.Size(94, 28);
            this.killsLabel.TabIndex = 1;
            this.killsLabel.Text = "Kills: 0";
            // 
            // healthLabel
            // 
            this.healthLabel.AutoSize = true;
            this.healthLabel.Font = new System.Drawing.Font("Old English Text MT", 18F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.healthLabel.Location = new System.Drawing.Point(660, 9);
            this.healthLabel.Name = "healthLabel";
            this.healthLabel.Size = new System.Drawing.Size(80, 28);
            this.healthLabel.TabIndex = 2;
            this.healthLabel.Text = "Health";
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.progressBar1.Location = new System.Drawing.Point(746, 14);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(165, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // zombie1
            // 
            this.zombie1.Image = global::Zombie_Shooter.Properties.Resources.zdown;
            this.zombie1.Location = new System.Drawing.Point(113, 149);
            this.zombie1.Name = "zombie1";
            this.zombie1.Size = new System.Drawing.Size(71, 71);
            this.zombie1.TabIndex = 4;
            this.zombie1.TabStop = false;
            this.zombie1.Tag = "zombie";
            // 
            // zombie2
            // 
            this.zombie2.Image = global::Zombie_Shooter.Properties.Resources.zdown;
            this.zombie2.Location = new System.Drawing.Point(709, 149);
            this.zombie2.Name = "zombie2";
            this.zombie2.Size = new System.Drawing.Size(71, 71);
            this.zombie2.TabIndex = 5;
            this.zombie2.TabStop = false;
            this.zombie2.Tag = "zombie";
            // 
            // player1
            // 
            this.player1.Image = global::Zombie_Shooter.Properties.Resources.up;
            this.player1.Location = new System.Drawing.Point(411, 308);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(71, 100);
            this.player1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player1.TabIndex = 6;
            this.player1.TabStop = false;
            // 
            // zombie3
            // 
            this.zombie3.Image = global::Zombie_Shooter.Properties.Resources.zup;
            this.zombie3.Location = new System.Drawing.Point(411, 540);
            this.zombie3.Name = "zombie3";
            this.zombie3.Size = new System.Drawing.Size(71, 71);
            this.zombie3.TabIndex = 7;
            this.zombie3.TabStop = false;
            this.zombie3.Tag = "zombie";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.gameEngine);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.ClientSize = new System.Drawing.Size(923, 666);
            this.Controls.Add(this.zombie3);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.zombie2);
            this.Controls.Add(this.zombie1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.healthLabel);
            this.Controls.Add(this.killsLabel);
            this.Controls.Add(this.ammoLabel);
            this.Name = "Form1";
            this.Text = "Kill or Die";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.zombie1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zombie3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ammoLabel;
        private System.Windows.Forms.Label killsLabel;
        private System.Windows.Forms.Label healthLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox zombie1;
        private System.Windows.Forms.PictureBox zombie2;
        private System.Windows.Forms.PictureBox player1;
        private System.Windows.Forms.PictureBox zombie3;
        private System.Windows.Forms.Timer timer1;
    }
}

