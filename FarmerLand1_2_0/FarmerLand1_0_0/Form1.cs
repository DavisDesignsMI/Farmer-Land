/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmer Land
 * VERSION: 1.2.0
 * 
 * DESCRIPTION:
 * This is a farm tycoon-style app.
 * 
 * POSSIBLE FUTURE ADDITIONS:
 * --More crops?
 * --More upgrades?
 * --Sound effects
 * --Price info
 * --Default to maximized?
 * --Help button?
 * --Instructions?
 */

using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using FarmerLand1_0_0;

namespace FarmerLand
{
    public partial class Form1 : Form
    {
        //Initiate image objects
        public readonly Image ICORN = IMG.Corn;
        public readonly Image IWHEAT = IMG.Wheat;
        public readonly Image ICARROT = IMG.Carrot;
        public readonly Image ILAND = IMG.Empty_Land;
        public readonly Image IBARN = IMG.Empty_Barn;

        //Initiate crop field
        BusinessDistrict Buildings = new BusinessDistrict();
        Field Crops = new Field(10,10);
        Barn Animals = new Barn();

        //Initialize crop types
        public readonly int CORN = 1;
        public readonly int WHEAT = 3;
        public readonly int CARROTS = 5;

        //Initialize animal types
        public readonly int COW = 1;
        public readonly int SHEEP = 2;
        public readonly int PIG = 3;

        //Initialize cash variable
        public double Cash = 10000000;

        //Stores the number of ticks
        public int timeTick;
        public int rotTick;
        public int animalTick;

        //Stores timer1 interval
        public int interval = 1000;

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

            //Hide animal icons
            Cow.Hide();
            Sheep.Hide();
            Pig.Hide();

            //Hide last two animal 
            //purchase buttons
            BSheep.Hide();
            BPigs.Hide();

            //Initialize tick event handler
            timer1.Tick += new EventHandler(this.timer1_Tick);
            RotTimer.Tick += new EventHandler(this.RotTimer_Tick);

            UpdateTick();
        }

        //Timer tick events
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            timeTick++;

            //Reset progress bar
            ModifyProgressBarColor.SetState(progressBar1, 1);

            if (timeTick > 10)
            {
                //Set progress bar color to red
                ModifyProgressBarColor.SetState(progressBar1, 2);

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
        private void AnimalTimer_Tick(object sender, EventArgs e)
        {
            animalTick++;

            if (animalTick > 10)
            {
                animalTick = 0;
                progressBar2.Value = animalTick;
                Cash += Animals.Collect();
            }
            else
            {
                progressBar2.Value = animalTick * 10;
            }

            UpdateTick();
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
                //Reset progress bar color
                ModifyProgressBarColor.SetState(progressBar1, 1);
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
            if (BuyB(10000, Crops.tractor == 2))
            {
                //Buy item
                Crops.tractor = 2;

                //Show icon
                Tr.Show();
            }

            //Call Tick Update
            UpdateTick();
        }

        private void irrigationSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (BuyB(5000, Crops.irrigation == 2))
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
            if (BuyB(100000, Crops.greenHouse == 4))
            {
                //Adjust timer1
                timer1.Interval = (int)Math.Round(timer1.Interval * 0.8);

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
            if (BuyB(2000, Crops.gardener == 1.5))
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
            if (BuyB(3000, Crops.waterer == 1.5))
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
            if (BuyB(15000, Crops.planter == 1.5))
            {
                //Buy Item
                Crops.planter = 1.5;

                //Show icon
                Pl.Show();

                //Adjust timer1
                timer1.Interval = (int)Math.Round(timer1.Interval * 0.9);
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

        private void BCows_Click(object sender, EventArgs e)
        {
            if (Animals.TryBuy(COW, Cash))
            {
                Cash -= Animals.Buy(COW, Cash);
                AnimalTimer.Start();
                BSheep.Show();
                BCows.Hide();
                Cow.Show();
            }
            else
            {
                MessageBox.Show("This item is too expensive");
            }

            UpdateTick();
        }

        private void BSheep_Click(object sender, EventArgs e)
        {
            if (Animals.TryBuy(SHEEP, Cash))
            {
                Cash -= Animals.Buy(SHEEP, Cash);
                BPigs.Show();
                BSheep.Hide();
                Sheep.Show();
            }
            else
            {
                MessageBox.Show("This item is too expensive");
            }

            UpdateTick();
        }

        private void BPigs_Click(object sender, EventArgs e)
        {
            if (Animals.TryBuy(PIG, Cash))
            {
                Cash -= Animals.Buy(PIG, Cash);
                BPigs.Hide();
                Pig.Show();
            }
            else
            {
                MessageBox.Show("This item is too expensive");
            }

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

            if (Animals.owned.Count == 0)
            {
                pictureBox2.Image = IBARN;
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

        public bool BuyB(double cost, bool b)
        {
            if (cost <= Cash)
            {
                if (b)
                {
                    MessageBox.Show("You already own this item!");
                    return false;
                }
                else
                {
                    Cash -= cost;
                    return true;
                }
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
            Cash = eX * eY;
            UpdateTick();
            StopTimer();
            pictureBox1.Image = ILAND;

            MessageBox.Show("The city will bail you out, but try to be more careful next time!");
        }

        //============================================================================================
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
        //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        //============================================================================================
    }

    //============================================================================================
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
    //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //============================================================================================

    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}