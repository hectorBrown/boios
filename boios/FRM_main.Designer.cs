namespace boios
{
    partial class FRM_main
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
            this.SPC_main = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_cohesion = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_seperation = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_alignment = new System.Windows.Forms.TrackBar();
            this.PB_main = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.SPC_main)).BeginInit();
            this.SPC_main.Panel1.SuspendLayout();
            this.SPC_main.Panel2.SuspendLayout();
            this.SPC_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TB_cohesion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_seperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_alignment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_main)).BeginInit();
            this.SuspendLayout();
            // 
            // SPC_main
            // 
            this.SPC_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SPC_main.Location = new System.Drawing.Point(0, 0);
            this.SPC_main.Name = "SPC_main";
            // 
            // SPC_main.Panel1
            // 
            this.SPC_main.Panel1.Controls.Add(this.label3);
            this.SPC_main.Panel1.Controls.Add(this.TB_cohesion);
            this.SPC_main.Panel1.Controls.Add(this.label2);
            this.SPC_main.Panel1.Controls.Add(this.TB_seperation);
            this.SPC_main.Panel1.Controls.Add(this.label1);
            this.SPC_main.Panel1.Controls.Add(this.TB_alignment);
            // 
            // SPC_main.Panel2
            // 
            this.SPC_main.Panel2.Controls.Add(this.PB_main);
            this.SPC_main.Size = new System.Drawing.Size(800, 450);
            this.SPC_main.SplitterDistance = 266;
            this.SPC_main.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cohesion";
            // 
            // TB_cohesion
            // 
            this.TB_cohesion.Location = new System.Drawing.Point(13, 127);
            this.TB_cohesion.Maximum = 100;
            this.TB_cohesion.Name = "TB_cohesion";
            this.TB_cohesion.Size = new System.Drawing.Size(251, 45);
            this.TB_cohesion.TabIndex = 6;
            this.TB_cohesion.Scroll += new System.EventHandler(this.TB_cohesion_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Seperation";
            // 
            // TB_seperation
            // 
            this.TB_seperation.Location = new System.Drawing.Point(12, 76);
            this.TB_seperation.Maximum = 100;
            this.TB_seperation.Name = "TB_seperation";
            this.TB_seperation.Size = new System.Drawing.Size(251, 45);
            this.TB_seperation.TabIndex = 4;
            this.TB_seperation.Scroll += new System.EventHandler(this.TB_seperation_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Alignment";
            // 
            // TB_alignment
            // 
            this.TB_alignment.Location = new System.Drawing.Point(12, 25);
            this.TB_alignment.Maximum = 100;
            this.TB_alignment.Name = "TB_alignment";
            this.TB_alignment.Size = new System.Drawing.Size(251, 45);
            this.TB_alignment.TabIndex = 1;
            this.TB_alignment.Scroll += new System.EventHandler(this.TB_alignment_Scroll);
            // 
            // PB_main
            // 
            this.PB_main.BackColor = System.Drawing.Color.Black;
            this.PB_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PB_main.Location = new System.Drawing.Point(0, 0);
            this.PB_main.Name = "PB_main";
            this.PB_main.Size = new System.Drawing.Size(530, 450);
            this.PB_main.TabIndex = 0;
            this.PB_main.TabStop = false;
            // 
            // FRM_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SPC_main);
            this.Name = "FRM_main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FRM_main_Load);
            this.SPC_main.Panel1.ResumeLayout(false);
            this.SPC_main.Panel1.PerformLayout();
            this.SPC_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SPC_main)).EndInit();
            this.SPC_main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TB_cohesion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_seperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_alignment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer SPC_main;
        private System.Windows.Forms.PictureBox PB_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar TB_alignment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar TB_cohesion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TB_seperation;
    }
}

