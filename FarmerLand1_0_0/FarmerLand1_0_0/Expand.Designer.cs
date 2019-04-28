namespace FarmerLand1_0_0
{
    partial class Expand
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
            this.Xin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Yin = new System.Windows.Forms.TextBox();
            this.Accept = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.CostOut = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Xin
            // 
            this.Xin.BackColor = System.Drawing.Color.Gainsboro;
            this.Xin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Xin.Location = new System.Drawing.Point(12, 60);
            this.Xin.Name = "Xin";
            this.Xin.Size = new System.Drawing.Size(776, 64);
            this.Xin.TabIndex = 0;
            this.Xin.TextChanged += new System.EventHandler(this.Xin_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label1.Location = new System.Drawing.Point(248, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Size on Side X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.label2.Location = new System.Drawing.Point(248, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(305, 48);
            this.label2.TabIndex = 3;
            this.label2.Text = "Size on Side Y:";
            // 
            // Yin
            // 
            this.Yin.BackColor = System.Drawing.Color.Gainsboro;
            this.Yin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.Yin.Location = new System.Drawing.Point(12, 198);
            this.Yin.Name = "Yin";
            this.Yin.Size = new System.Drawing.Size(776, 64);
            this.Yin.TabIndex = 2;
            this.Yin.TextChanged += new System.EventHandler(this.Yin_TextChanged);
            // 
            // Accept
            // 
            this.Accept.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Accept.Location = new System.Drawing.Point(13, 360);
            this.Accept.Name = "Accept";
            this.Accept.Size = new System.Drawing.Size(311, 78);
            this.Accept.TabIndex = 4;
            this.Accept.Text = "Accept";
            this.Accept.UseVisualStyleBackColor = true;
            this.Accept.Click += new System.EventHandler(this.Accept_Click);
            // 
            // Cancel
            // 
            this.Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Cancel.Location = new System.Drawing.Point(477, 360);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(311, 78);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // CostOut
            // 
            this.CostOut.AutoSize = true;
            this.CostOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.CostOut.Location = new System.Drawing.Point(318, 290);
            this.CostOut.Name = "CostOut";
            this.CostOut.Size = new System.Drawing.Size(152, 48);
            this.CostOut.TabIndex = 6;
            this.CostOut.Text = "Cost: 0";
            // 
            // Expand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CostOut);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Accept);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Yin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Xin);
            this.Name = "Expand";
            this.Text = "Expand";
            this.Load += new System.EventHandler(this.Expand_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Xin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Yin;
        private System.Windows.Forms.Button Accept;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label CostOut;
    }
}