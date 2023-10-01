namespace CommandParserAssignmnet
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
            label_Single = new Label();
            txtBox_Single = new TextBox();
            btnRun_Single = new Button();
            button2 = new Button();
            btnClear_Single = new Button();
            pictureBox1 = new PictureBox();
            btnClear_Program = new Button();
            button5 = new Button();
            btnRun_Program = new Button();
            txtBox_Program = new TextBox();
            label_Program = new Label();
            listBox1 = new ListBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label_Single
            // 
            label_Single.AutoSize = true;
            label_Single.Location = new Point(12, 13);
            label_Single.Name = "label_Single";
            label_Single.Size = new Size(102, 15);
            label_Single.TabIndex = 0;
            label_Single.Text = "Single Command:";
            // 
            // txtBox_Single
            // 
            txtBox_Single.Location = new Point(12, 31);
            txtBox_Single.Name = "txtBox_Single";
            txtBox_Single.Size = new Size(376, 23);
            txtBox_Single.TabIndex = 1;
            // 
            // btnRun_Single
            // 
            btnRun_Single.Location = new Point(12, 60);
            btnRun_Single.Name = "btnRun_Single";
            btnRun_Single.Size = new Size(75, 30);
            btnRun_Single.TabIndex = 2;
            btnRun_Single.Text = "Run";
            btnRun_Single.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(93, 60);
            button2.Name = "button2";
            button2.Size = new Size(75, 30);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnClear_Single
            // 
            btnClear_Single.Location = new Point(313, 60);
            btnClear_Single.Name = "btnClear_Single";
            btnClear_Single.Size = new Size(75, 30);
            btnClear_Single.TabIndex = 4;
            btnClear_Single.Text = "Clear";
            btnClear_Single.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(408, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(861, 672);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnClear_Program
            // 
            btnClear_Program.Location = new Point(313, 479);
            btnClear_Program.Name = "btnClear_Program";
            btnClear_Program.Size = new Size(75, 30);
            btnClear_Program.TabIndex = 10;
            btnClear_Program.Text = "Clear";
            btnClear_Program.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(93, 479);
            button5.Name = "button5";
            button5.Size = new Size(75, 30);
            button5.TabIndex = 9;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // btnRun_Program
            // 
            btnRun_Program.Location = new Point(12, 479);
            btnRun_Program.Name = "btnRun_Program";
            btnRun_Program.Size = new Size(75, 30);
            btnRun_Program.TabIndex = 8;
            btnRun_Program.Text = "Run\r\n";
            btnRun_Program.UseVisualStyleBackColor = true;
            // 
            // txtBox_Program
            // 
            txtBox_Program.Location = new Point(12, 124);
            txtBox_Program.Multiline = true;
            txtBox_Program.Name = "txtBox_Program";
            txtBox_Program.Size = new Size(376, 349);
            txtBox_Program.TabIndex = 7;
            // 
            // label_Program
            // 
            label_Program.AutoSize = true;
            label_Program.Location = new Point(12, 106);
            label_Program.Name = "label_Program";
            label_Program.Size = new Size(56, 15);
            label_Program.TabIndex = 6;
            label_Program.Text = "Program:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 531);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(376, 154);
            listBox1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 696);
            Controls.Add(listBox1);
            Controls.Add(btnClear_Program);
            Controls.Add(button5);
            Controls.Add(btnRun_Program);
            Controls.Add(txtBox_Program);
            Controls.Add(label_Program);
            Controls.Add(pictureBox1);
            Controls.Add(btnClear_Single);
            Controls.Add(button2);
            Controls.Add(btnRun_Single);
            Controls.Add(txtBox_Single);
            Controls.Add(label_Single);
            Name = "Form1";
            Text = "C3584270 - Furqan Khan";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Single;
        private TextBox txtBox_Single;
        private Button btnRun_Single;
        private Button button2;
        private Button btnClear_Single;
        private PictureBox pictureBox1;
        private Button btnClear_Program;
        private Button button5;
        private Button btnRun_Program;
        private TextBox txtBox_Program;
        private Label label_Program;
        private ListBox listBox1;
    }
}