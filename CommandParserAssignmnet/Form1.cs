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

            // Initialise global variables
            Globals.pictureBoxWidth = pictureBox1.Width;
            Globals.pictureBoxHeight = pictureBox1.Height;
            Globals.pictureBoxColor = pictureBox1.BackColor;

            fileHandler = new FileHandler();
            graphicsHandler = new GraphicsHandler();
            parser = new Parser(graphicsHandler);
        }

        private void txtBox_Single_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                string command = txtBox_Single.Text.Trim();

                parser.ParseLine(command);

                Refresh();
            }
        }

        private void btnRun_Single_Click(object sender, EventArgs e)
        {
            string command = txtBox_Single.Text.Trim();

            parser.ParseLine(command);

            Refresh();
        }

        private void btnRun_Program_Click(object sender, EventArgs e)
        {
            string programText = txtBox_Program.Text;

            parser.ParseProgram(programText);
            
            Refresh();
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

            g.DrawImage(graphicsHandler.getBitmap(), 0, 0);
        }
    }
}