/* CREATED BY: Davis M. Brace  (Davis Designs of Michigan LLC)
 * STARTED ON: 04/25/2019
 * TITLE: Farmer Land
 * 
 * DESCRIPTION:
 * This is an extension of Farmerland which allows the user to input new dimensions for a field.
 */

using System;
using System.Windows.Forms;

namespace FarmerLand1_0_0
{
    public partial class Expand : Form
    {
        //Initiate double vars
        public double X;
        public double Y;
        public double Cost;
        public double Cash;

        //Initiate bool vars
        public bool complete = false;
        public bool cancel = false;

        public Expand(double cash)
        {
            Cash = cash;
            InitializeComponent();
            TickUpdate();
        }

        private void Expand_Load(object sender, EventArgs e)
        {
            //Nothing here
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            TickUpdate();
            if (Cost < Cash)
            {
                complete = true;
            }
            else
            {
                MessageBox.Show("This expansion is too expensive.");
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            TickUpdate();
            complete = true;
            cancel = true;
        }

        private void Xin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                X = double.Parse(Xin.Text);
            }
            catch
            {
                Xin.Text = X.ToString();
            }

            TickUpdate();
        }

        private void Yin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Y = double.Parse(Yin.Text);
            }
            catch
            {
                Yin.Text = Y.ToString();
            }

            TickUpdate();
        }

        public void TickUpdate()
        {
            Cost = (X * Y * 20) - 2000;
            CostOut.Text = "Cost: " + Cost.ToString();
        }
    }
}