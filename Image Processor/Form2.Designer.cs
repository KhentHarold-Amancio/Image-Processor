namespace Image_Processor
{
    partial class Form2
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(46, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(349, 224);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BorderStyle = BorderStyle.FixedSingle;
            pictureBox2.Location = new Point(443, 39);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(349, 224);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BorderStyle = BorderStyle.FixedSingle;
            pictureBox3.Location = new Point(46, 301);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(349, 224);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 21);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 3;
            label1.Text = "Picture A / Webcam";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(443, 21);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Result";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 283);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 5;
            label3.Text = "Picture B";
            // 
            // button1
            // 
            button1.Location = new Point(444, 302);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 6;
            button1.Text = "Load Picture A";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(444, 331);
            button2.Name = "button2";
            button2.Size = new Size(120, 23);
            button2.TabIndex = 7;
            button2.Text = "Load Picture B";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(444, 360);
            button3.Name = "button3";
            button3.Size = new Size(120, 52);
            button3.TabIndex = 8;
            button3.Text = "Subtract";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(737, 302);
            button4.Name = "button4";
            button4.Size = new Size(55, 23);
            button4.TabIndex = 9;
            button4.Text = "Off";
            button4.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(676, 306);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 10;
            label4.Text = "Webcam:";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(844, 537);
            Controls.Add(label4);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Name = "Form2";
            Text = "DIP Section";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label4;
    }
}