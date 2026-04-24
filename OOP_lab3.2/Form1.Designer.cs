namespace OOP_lab3._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBoxA = new TextBox();
            textBoxB = new TextBox();
            textBoxC = new TextBox();
            numA = new NumericUpDown();
            numB = new NumericUpDown();
            numC = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblCounter = new Label();
            trackBar1 = new TrackBar();
            trackBar2 = new TrackBar();
            trackBar3 = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)numA).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numC).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).BeginInit();
            SuspendLayout();
            // 
            // textBoxA
            // 
            textBoxA.Location = new Point(45, 32);
            textBoxA.Name = "textBoxA";
            textBoxA.Size = new Size(125, 27);
            textBoxA.TabIndex = 0;
            // 
            // textBoxB
            // 
            textBoxB.Location = new Point(303, 32);
            textBoxB.Name = "textBoxB";
            textBoxB.Size = new Size(125, 27);
            textBoxB.TabIndex = 1;
            // 
            // textBoxC
            // 
            textBoxC.Location = new Point(568, 32);
            textBoxC.Name = "textBoxC";
            textBoxC.Size = new Size(125, 27);
            textBoxC.TabIndex = 2;
            // 
            // numA
            // 
            numA.Location = new Point(45, 143);
            numA.Name = "numA";
            numA.Size = new Size(150, 27);
            numA.TabIndex = 3;
            // 
            // numB
            // 
            numB.Location = new Point(303, 143);
            numB.Name = "numB";
            numB.Size = new Size(150, 27);
            numB.TabIndex = 4;
            // 
            // numC
            // 
            numC.Location = new Point(568, 143);
            numC.Name = "numC";
            numC.Size = new Size(150, 27);
            numC.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(97, 9);
            label1.Name = "label1";
            label1.Size = new Size(19, 20);
            label1.TabIndex = 6;
            label1.Text = "A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 9);
            label2.Name = "label2";
            label2.Size = new Size(18, 20);
            label2.TabIndex = 7;
            label2.Text = "B";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(622, 9);
            label3.Name = "label3";
            label3.Size = new Size(18, 20);
            label3.TabIndex = 8;
            label3.Text = "C";
            // 
            // lblCounter
            // 
            lblCounter.AutoSize = true;
            lblCounter.Location = new Point(738, 421);
            lblCounter.Name = "lblCounter";
            lblCounter.Size = new Size(50, 20);
            lblCounter.TabIndex = 9;
            lblCounter.Text = "label4";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(40, 222);
            trackBar1.Maximum = 100;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(155, 56);
            trackBar1.TabIndex = 10;
            // 
            // trackBar2
            // 
            trackBar2.Location = new Point(298, 222);
            trackBar2.Maximum = 100;
            trackBar2.Name = "trackBar2";
            trackBar2.Size = new Size(155, 56);
            trackBar2.TabIndex = 11;
            // 
            // trackBar3
            // 
            trackBar3.Location = new Point(568, 222);
            trackBar3.Maximum = 100;
            trackBar3.Name = "trackBar3";
            trackBar3.Size = new Size(150, 56);
            trackBar3.TabIndex = 12;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(trackBar3);
            Controls.Add(trackBar2);
            Controls.Add(trackBar1);
            Controls.Add(lblCounter);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numC);
            Controls.Add(numB);
            Controls.Add(numA);
            Controls.Add(textBoxC);
            Controls.Add(textBoxB);
            Controls.Add(textBoxA);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numA).EndInit();
            ((System.ComponentModel.ISupportInitialize)numB).EndInit();
            ((System.ComponentModel.ISupportInitialize)numC).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar2).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxA;
        private TextBox textBoxB;
        private TextBox textBoxC;
        private NumericUpDown numA;
        private NumericUpDown numB;
        private NumericUpDown numC;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblCounter;
        private TrackBar trackBar1;
        private TrackBar trackBar2;
        private TrackBar trackBar3;
    }
}
