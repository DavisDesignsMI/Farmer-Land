/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmer Land
 * 
 * DESCRIPTION:
 * This is a farm tycoon-style app.
 * 
 * NOTES:
 * Fields at index 0 is never used for programming simplicity.
 * 
 * POSSIBLE FUTURE ADDITIONS:
 * --More fields
 * --More crops
 * --More upgrades?
 * --Animal fields as end game item?
 * --Secondary windows to input data when purchasing dynamically?
 * --Crop timers
 * --Sound effects
 * --Price info
 * --Error handling/alerts
 * --Cleaner images (better backgrounds)
 * --Default to maximized?
 * --Readme file?
 * --Help button?
 * --Instructions?
 */

using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;
using System.Threading.Tasks;

namespace FarmerLand1_0_0
{
    public partial class Form1 : Form
    {
        //Initiate image objects
        public readonly Image ICORN = Images.Corn;
        public readonly Image IWHEAT = Images.Wheat;
        public readonly Image ICARROT = Images.Carrot;
        public readonly Image ILAND = Images.Empty_Land;

        //Initiate crop field
        BusinessDistrict Buildings = new BusinessDistrict();
        Field Crops = new Field(10,10);
        Barn Animals = new Barn();

        //Initialize crop types
        public readonly int CORN = 1;
        public readonly int WHEAT = 2;
        public readonly int CARROTS = 3;

        //Initialize cash variable
        public double Cash = 100;

        //Stores the number of ticks
        public int timeTick;
        public int rotTick;

        //Initiate update tick variable
        public int UpTick;

        //Initiate communication variables
        public double eX = 10;
        public double eY = 10;

        //============================================================================================

        //Form initialization
        public Form1()
        {
            InitializeComponent();

            //Set picture to empty land
            pictureBox1.Image = ILAND;

            CashOut.Text = "CASH: " + Cash.ToString();
        }

        //Form load
        private void Form1_Load(object sender, EventArgs e)
        {
            //Hide equipment icons
            Tr.Hide();
            Ir.Hide();
            Gr.Hide();

            //Hide employee icons
            Ga.Hide();
            Wa.Hide();
            Pl.Hide();

            //Initialize tick event handler
            timer1.Tick += new EventHandler(this.timer1_Tick);
            RotTimer.Tick += new EventHandler(this.RotTimer_Tick);

            UpdateTick();
        }

        //Timer tick events
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timeTick++;

            if (timeTick > 10)
            {
                timer1.Stop();
                RotTimer.Start();
            }
            else
            {
                progressBar1.Value = timeTick * 10;
            }
        }
        private void RotTimer_Tick(object sender, System.EventArgs e)
        {
            rotTick++;

            if (rotTick > 10)
            {
                RotTimer.Stop();
                Crops.rotten = true;
            }
            else
            {
                progressBar1.Value -= 10;
            }
        }

        //Give up button
        private void button1_Click(object sender, EventArgs e)
        {
            Lose();
        }

        //============================================================================================

        private void progressBar1_Click(object sender, EventArgs e)
        {
            //No Action
        }

        private void plantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No Action
        }

        //============================================================================================

        private void cornToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Crops.GetSeedCost(CORN, Cash))
            {
                //Plant
                Cash -= Crops.Plant(CORN, Cash);
                //Change Image
                pictureBox1.Image = ICORN;
                //Start grow timer
                StartGrow();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void wheatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Crops.GetSeedCost(WHEAT, Cash))
            {
                //Plant
                Cash -= Crops.Plant(WHEAT, Cash);
                //Change Image
                pictureBox1.Image = IWHEAT;
                //Start grow timer
                StartGrow();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void carrotsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Crops.GetSeedCost(CARROTS, Cash))
            {
                //Plant
                Cash -= Crops.Plant(CARROTS, Cash);
                //Change Image
                pictureBox1.Image = ICARROT;
                //Start grow timer
                StartGrow();
            }

            //Call Tick Update
            UpdateTick();
        }

        //============================================================================================

        private void harvestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TimerInfo())
            {
                //Stop timers
                StopTimer();
                //Harvest
                Cash += Crops.Harvest();
                //Reset picture
                pictureBox1.Image = ILAND;
            }
            else
            {
                MessageBox.Show("Crop is not ready to be harvested");
            }

            //Call Tick Update
            UpdateTick();
        }

        //============================================================================================

        private void tractorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Buy(10000))
            {
                //Buy Item
                Crops.tractor = 2;

                //Show icon
                Tr.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void irrigationSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Buy(5000))
            {
                //Buy Item
                Crops.irrigation = 2;

                //Show icon
                Ir.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void greenhouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Buy(100000))
            {
                //Buy Item
                Crops.greenHouse = 4;

                //Show icon
                Gr.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        //============================================================================================

        private void tractorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Buy(2000))
            {
                //Buy Item
                Crops.gardener = 1.5;

                //Show icon
                Ga.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void watererToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Buy(3000))
            {
                //Buy Item
                Crops.waterer = 1.5;

                //Show icon
                Wa.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void planterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Buy(15000))
            {
                //Buy Item
                Crops.planter = 1.5;

                //Show icon
                Pl.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        //============================================================================================

        private async void expandFieldToolStripMenuItem_ClickAsync(object sender, EventArgs e)
        {
            //Initiate expand form
            Expand ExpandForm = new Expand(Cash);
            ExpandForm.Show();

            //Wait until done
            while (!ExpandForm.complete)
            {
                await Task.Delay(25);
            }

            //Decide if cancel button or accept button was pressed
            if (!ExpandForm.cancel)
            {
                eX = ExpandForm.X;
                eY = ExpandForm.Y;

                Cash -= Crops.Expand(eX, eY, Cash);
            }

            ExpandForm.Hide();

            UpdateTick();
        }

        //============================================================================================
        //============================================================================================
        //============================================================================================

        public bool TimerInfo()
        {
            if (timeTick >= 10)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void StartGrow()
        {
            timer1.Start();
        }

        public void StopTimer()
        {
            //Stop timers
            timer1.Stop();
            RotTimer.Stop();

            //Reset time vars
            timeTick = 0;
            rotTick = 0;

            //Reset progressbar
            progressBar1.Value = 0;
        }

        public int UpdateTick()
        {
            if (Crops.seedType == 0)
            {
                //Reset image
                pictureBox1.Image = ILAND;
            }

            //Set x and y labels
            X1.Text = "Size X: " + eX;
            Y1.Text = "Size Y: " + eY;

            //Iterate uptick
            UpTick++;

            //Update cash label
            CashOut.Text = "CASH: " + Cash.ToString();

            //Return uptick value
            return UpTick;
        }

        public bool Buy(double cost)
        {
            if (cost <= Cash)
            {
                Cash -= cost;
                return true;
            }
            else
            {
                MessageBox.Show("This item is too expensive.  Try again later.");
                return false;
            }
        }

        public void Lose()
        {
            //Reset values but keep upgrades
            Cash = 100;
            UpdateTick();
            StopTimer();
            pictureBox1.Image = ILAND;

            MessageBox.Show("The bank will bail you out, but try to be more careful next time!");
        }

        //============================================================================================
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //============================================================================================
    }
}