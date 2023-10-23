namespace CommandParserAssignmnet
{
    public partial class Form1 : Form
    {
        FileHandler fileHandler;
        GraphicsHandler graphicsHandler;
        Parser parser;

        public Form1()
        {
            InitializeComponent();
            projectSetup();

            fileHandler = new FileHandler();
            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler, this);
        }

        private void txtBox_Single_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string command = txtBox_Single.Text.Trim();
                ExecuteCommand(command);
            }
        }

        private void btnRun_Single_Click(object sender, EventArgs e)
        {
            string command = txtBox_Single.Text.Trim();

            ExecuteCommand(command);
        }

        private void ExecuteCommand(string command)
        {
            // Hacky way of doing it, but I don't want to write any more code for this assignment
            if (command.Equals("run", StringComparison.OrdinalIgnoreCase))
            {
                // Trigger btnRun_Program_Click
                btnRun_Program.PerformClick();
            }
            else
            {
                parser.ParseLine(command);
                Refresh();
            }
        }

        private void btnRun_Program_Click(object sender, EventArgs e)
        {
            string programText = txtBox_Program.Text;

            parser.ParseProgram(programText);
        }

        private void btnClear_Single_Click(object sender, EventArgs e)
        {
            txtBox_Single.Text = string.Empty;
        }

        private void btnClear_Program_Click(object sender, EventArgs e)
        {
            txtBox_Program.Text = string.Empty;
        }

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
                MessageBox.Show("Error saving file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("Error loading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                g.FillRectangle(new SolidBrush(Color.Red), x, y, Globals.cursorSize, Globals.cursorSize);
            }
        }

        private void PrintErrorMessage(string message)
        {
            listBox1.Items.Add(message);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsHandler.getGraphics().Clear(Globals.pictureBoxColor);
            Refresh();
        }

        private void cursorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.showCursor = !Globals.showCursor;
            Refresh();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Open settings form
        }

        private void projectSetup()
        {
            // Set global error handler
            GlobalExceptionHandler.SetPrintErrorMessage(PrintErrorMessage);

            // Initialise global variables
            Globals.pictureBoxWidth = pictureBox1.Width;
            Globals.pictureBoxHeight = pictureBox1.Height;
            Globals.pictureBoxColor = pictureBox1.BackColor;

            // Idk what this comes under
            cursorToolStripMenuItem.Checked = Globals.showCursor;
        }
    }
}