namespace CommandParserAssignmnet
{
    /// <summary>
    /// A class that adapts the SaveFileDialog from Windows Forms to the IFileDialog interface,
    /// allowing it to be used in the context of the CommandParserAssignment application.
    /// </summary>
    /// <seealso cref="IFileDialog" />
    public class SaveFileDialogAdapter : IFileDialog
    {
        /// <summary>
        /// The instance of the SaveFileDialog used by this adapter.
        /// </summary>
        private SaveFileDialog saveFileDialog = new SaveFileDialog();

        /// <summary>
        /// Shows the file dialog and returns the result of the user's interaction.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> indicating the user's choice or action.</returns>
        public DialogResult ShowDialog()
        {
            return saveFileDialog.ShowDialog();
        }

        /// <summary>
        /// Gets or sets the name of the file to be saved in the dialog.
        /// </summary>
        /// <value>
        /// The name of the file to be saved.
        /// </value>
        public string FileName
        {
            get => saveFileDialog.FileName;
            set => saveFileDialog.FileName = value;
        }

        /// <summary>
        /// Gets or sets the filter that defines the file types displayed in the dialog.
        /// </summary>
        /// <value>
        /// The filter string used to filter file types, e.g., "Text Files|*.txt|All Files|*.*".
        /// </value>
        public string Filter
        {
            get => saveFileDialog.Filter;
            set => saveFileDialog.Filter = value;
        }

        /// <summary>
        /// Gets or sets the title or caption displayed in the file dialog.
        /// </summary>
        /// <value>
        /// The title or caption of the file dialog window.
        /// </value>
        public string Title
        {
            get => saveFileDialog.Title;
            set => saveFileDialog.Title = value;
        }
    }
}
