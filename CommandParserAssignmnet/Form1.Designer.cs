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
            btnSyntax_Program = new Button();
            btnRun_Program = new Button();
            txtBox_Program = new TextBox();
            label_Program = new Label();
            listBox1 = new ListBox();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            commandsToolStripMenuItem = new ToolStripMenuItem();
            canvasToolStripMenuItem = new ToolStripMenuItem();
            clearToolStripMenuItem = new ToolStripMenuItem();
            cursorToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label_Single
            // 
            label_Single.AutoSize = true;
            label_Single.Location = new Point(12, 32);
            label_Single.Name = "label_Single";
            label_Single.Size = new Size(102, 15);
            label_Single.TabIndex = 0;
            label_Single.Text = "Single Command:";
            // 
            // txtBox_Single
            // 
            txtBox_Single.Location = new Point(12, 50);
            txtBox_Single.Name = "txtBox_Single";
            txtBox_Single.Size = new Size(376, 23);
            txtBox_Single.TabIndex = 1;
            txtBox_Single.KeyPress += txtBox_Single_KeyPress;
            // 
            // btnRun_Single
            // 
            btnRun_Single.Location = new Point(12, 79);
            btnRun_Single.Name = "btnRun_Single";
            btnRun_Single.Size = new Size(75, 30);
            btnRun_Single.TabIndex = 2;
            btnRun_Single.Text = "Run";
            btnRun_Single.UseVisualStyleBackColor = true;
            btnRun_Single.Click += btnRun_Single_Click;
            // 
            // button2
            // 
            button2.Location = new Point(93, 79);
            button2.Name = "button2";
            button2.Size = new Size(75, 30);
            button2.TabIndex = 3;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // btnClear_Single
            // 
            btnClear_Single.Location = new Point(313, 79);
            btnClear_Single.Name = "btnClear_Single";
            btnClear_Single.Size = new Size(75, 30);
            btnClear_Single.TabIndex = 4;
            btnClear_Single.Text = "Clear";
            btnClear_Single.UseVisualStyleBackColor = true;
            btnClear_Single.Click += btnClear_Single_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Black;
            pictureBox1.Location = new Point(408, 32);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(861, 672);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // btnClear_Program
            // 
            btnClear_Program.Location = new Point(313, 498);
            btnClear_Program.Name = "btnClear_Program";
            btnClear_Program.Size = new Size(75, 30);
            btnClear_Program.TabIndex = 10;
            btnClear_Program.Text = "Clear";
            btnClear_Program.UseVisualStyleBackColor = true;
            btnClear_Program.Click += btnClear_Program_Click;
            // 
            // btnSyntax_Program
            // 
            btnSyntax_Program.Location = new Point(93, 498);
            btnSyntax_Program.Name = "btnSyntax_Program";
            btnSyntax_Program.Size = new Size(75, 30);
            btnSyntax_Program.TabIndex = 9;
            btnSyntax_Program.Text = "Syntax";
            btnSyntax_Program.UseVisualStyleBackColor = true;
            // 
            // btnRun_Program
            // 
            btnRun_Program.Location = new Point(12, 498);
            btnRun_Program.Name = "btnRun_Program";
            btnRun_Program.Size = new Size(75, 30);
            btnRun_Program.TabIndex = 8;
            btnRun_Program.Text = "Run\r\n";
            btnRun_Program.UseVisualStyleBackColor = true;
            btnRun_Program.Click += btnRun_Program_Click;
            // 
            // txtBox_Program
            // 
            txtBox_Program.Location = new Point(12, 143);
            txtBox_Program.Multiline = true;
            txtBox_Program.Name = "txtBox_Program";
            txtBox_Program.Size = new Size(376, 349);
            txtBox_Program.TabIndex = 7;
            txtBox_Program.TextChanged += txtBox_Program_TextChanged;
            // 
            // label_Program
            // 
            label_Program.AutoSize = true;
            label_Program.Location = new Point(12, 125);
            label_Program.Name = "label_Program";
            label_Program.Size = new Size(56, 15);
            label_Program.TabIndex = 6;
            label_Program.Text = "Program:";
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 550);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(376, 154);
            listBox1.TabIndex = 11;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, commandsToolStripMenuItem, canvasToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1281, 24);
            menuStrip1.TabIndex = 12;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { saveToolStripMenuItem, loadToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(100, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(100, 22);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // commandsToolStripMenuItem
            // 
            commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            commandsToolStripMenuItem.Size = new Size(81, 20);
            commandsToolStripMenuItem.Text = "Commands";
            // 
            // canvasToolStripMenuItem
            // 
            canvasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clearToolStripMenuItem, cursorToolStripMenuItem });
            canvasToolStripMenuItem.Name = "canvasToolStripMenuItem";
            canvasToolStripMenuItem.Size = new Size(57, 20);
            canvasToolStripMenuItem.Text = "Canvas";
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new Size(109, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += clearToolStripMenuItem_Click;
            // 
            // cursorToolStripMenuItem
            // 
            cursorToolStripMenuItem.CheckOnClick = true;
            cursorToolStripMenuItem.Name = "cursorToolStripMenuItem";
            cursorToolStripMenuItem.Size = new Size(109, 22);
            cursorToolStripMenuItem.Text = "Cursor";
            cursorToolStripMenuItem.Click += cursorToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(61, 20);
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1281, 716);
            Controls.Add(listBox1);
            Controls.Add(btnClear_Program);
            Controls.Add(btnSyntax_Program);
            Controls.Add(btnRun_Program);
            Controls.Add(txtBox_Program);
            Controls.Add(label_Program);
            Controls.Add(pictureBox1);
            Controls.Add(btnClear_Single);
            Controls.Add(button2);
            Controls.Add(btnRun_Single);
            Controls.Add(txtBox_Single);
            Controls.Add(label_Single);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "C3584270 - Furqan Khan";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private Button btnSyntax_Program;
        private Button btnRun_Program;
        private TextBox txtBox_Program;
        private Label label_Program;
        private ListBox listBox1;
        private OpenFileDialog openFileDialog1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem commandsToolStripMenuItem;
        private ToolStripMenuItem canvasToolStripMenuItem;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem cursorToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}