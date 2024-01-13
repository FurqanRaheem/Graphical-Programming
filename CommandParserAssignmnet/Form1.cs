namespace CommandParserAssignmnet
{
    public partial class Form1 : Form
    {
        private FileHandler fileHandler;
        private GraphicsHandler graphicsHandler;
        private Parser parser;
        public bool Test { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            projectSetup();

            Test = false;
            fileHandler = new FileHandler();
            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler, this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class. Used for unit testing.
        /// </summary>
        /// <param name="test">if set to <c>true</c> [test].</param>
        public Form1(bool test)
        {
            InitializeComponent();
            projectSetup();

            Test = test;
            fileHandler = new FileHandler();
            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler, this);
        }

        /// <summary>
        /// Gets or sets the text box program text.
        /// </summary>
        /// <value>
        /// The text box program text.
        /// </value>
        public string TxtBoxProgramText
        {
            get { return txtBox_Program.Text; }
            set { txtBox_Program.Text = value; }
        }

        /// <summary>
        /// Gets the Button that runs the program.
        /// </summary>
        /// <value>
        /// The BTN run program.
        /// </value>
        public Button BtnRunProgram
        {
            get { return btnRun_Program; }
        }

        /// <summary>
        /// Gets the graphics handler.
        /// </summary>
        /// <value>
        /// The graphics handler.
        /// </value>
        public GraphicsHandler GraphicsHandler
        {
            get { return graphicsHandler; }
        }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        /// <value>
        /// The parser.
        /// </value>
        public Parser Parser
        {
            get { return parser; }
        }

        /// <summary>
        /// Configure project.
        /// </summary>
        private void projectSetup()
        {
            // Set global error handler
            GlobalExceptionHandler.SetPrintErrorMessage(PrintErrorMessage);

            // Initialise global variables
            Globals.pictureBoxWidth = pictureBox1.Width;
            Globals.pictureBoxHeight = pictureBox1.Height;
            Globals.pictureBoxColor = pictureBox1.BackColor;

            // Windows Forms Settings
            cursorToolStripMenuItem.Checked = Globals.showCursor;
        }

        /// <summary>
        /// Handles the KeyPress event of the txtBox_Single control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyPressEventArgs"/> instance containing the event data.</param>
        private void txtBox_Single_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string command = txtBox_Single.Text.Trim();
                ExecuteCommand(command);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRun_Single control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRun_Single_Click(object sender, EventArgs e)
        {
            string command = txtBox_Single.Text.Trim();

            ExecuteCommand(command);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="command">The command.</param>
        public void ExecuteCommand(string command)
        {
            parser.ParseLine(command);
            Refresh();
        }

        /// <summary>
        /// Handles the Click event of the btnRun_Program control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnRun_Program_Click(object sender, EventArgs e)
        {
            string programText = txtBox_Program.Text;

            parser.ParseProgram(programText);
        }

        public void Unit_Test_btnRun_Program_Click()
        {
            string programText = TxtBoxProgramText;
            parser.ParseProgram(programText);
        }

        /// <summary>
        /// Handles the Click event of the btnClear_Single control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClear_Single_Click(object sender, EventArgs e)
        {
            txtBox_Single.Text = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the btnClear_Program control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnClear_Program_Click(object sender, EventArgs e)
        {
            txtBox_Program.Text = string.Empty;
        }

        /// <summary>
        /// Handles the Click event of the saveToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string textToSave = txtBox_Program.Text;
            bool savedSuccessfully = fileHandler.SaveToFile(textToSave);

            if (savedSuccessfully)
            {
                MessageBox.Show("File saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception("Error saving file.");
            }
        }

        /// <summary>
        /// Handles the Click event of the loadToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string? loadedText = fileHandler.LoadFromFile();

            if (loadedText != string.Empty || loadedText == null)
            {
                txtBox_Program.Text = loadedText;
                MessageBox.Show("File loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                throw new Exception("Error loading file.");
            }
        }

        /// <summary>
        /// Handles the Paint event of the pictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw bitmap
            g.DrawImage(graphicsHandler.getBitmap(), 0, 0);

            // Draw cursor
            if (Globals.showCursor)
            {
                float x = graphicsHandler.X - Globals.cursorSize / 2;
                float y = graphicsHandler.Y - Globals.cursorSize / 2;
                g.FillRectangle(new SolidBrush(Globals.cursorColour), x, y, Globals.cursorSize, Globals.cursorSize);
            }
        }

        /// <summary>
        /// Prints the error message.
        /// </summary>
        /// <param name="message">The message.</param>
        private void PrintErrorMessage(string message)
        {
            listBox1.Items.Add(message);
        }

        /// <summary>
        /// Handles the Click event of the clearToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsHandler.getGraphics().Clear(Globals.pictureBoxColor);
            Refresh();
        }

        /// <summary>
        /// Handles the Click event of the cursorToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void cursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.showCursor = !Globals.showCursor;
            Refresh();
        }

        /// <summary>
        /// Handles the Click event of the settingsToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open settings form
        }

        /// <summary>
        /// Handles the TextChanged event of the txtBox_Program control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void txtBox_Program_TextChanged(object sender, EventArgs e)
        {
            TxtBoxProgramText = txtBox_Program.Text;
        }

        /// <summary>
        /// Handles the Click event of the btnSyntax_Program control. Doesn't run the program, just checks the syntax.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSyntax_Program_Click(object sender, EventArgs e)
        {
            try
            {
                string programText = txtBox_Program.Text;
                parser.ParseProgram(programText, true);
                MessageBox.Show(Text = "Syntax check successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
