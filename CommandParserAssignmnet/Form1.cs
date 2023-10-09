namespace CommandParserAssignmnet
{
    public partial class Form1 : Form
    {
        Parser parser;
        FileHandler fileHandler;
        public Form1()
        {
            InitializeComponent();
            this.parser = new Parser();
            this.fileHandler = new FileHandler();
        }

        private void btnRun_Single_Click(object sender, EventArgs e)
        {
            string command = txtBox_Single.Text.Trim();

            parser.ParseLine(command);
        }

        private void btnRun_Program_Click(object sender, EventArgs e)
        {

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

            if(loadedText != string.Empty || loadedText == null)
            {
                txtBox_Program.Text = loadedText;
                MessageBox.Show("File loaded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error loading file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}