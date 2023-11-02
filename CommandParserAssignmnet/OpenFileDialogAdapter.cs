namespace CommandParserAssignmnet
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="CommandParserAssignmnet.IFileDialog" />
    public class OpenFileDialogAdapter : IFileDialog
    {
        /// <summary>
        /// The open file dialog
        /// </summary>
        private OpenFileDialog openFileDialog = new OpenFileDialog();

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns></returns>
        public DialogResult ShowDialog()
        {
            return openFileDialog.ShowDialog();
        }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>
        /// The name of the file.
        /// </value>
        public string FileName
        {
            get => openFileDialog.FileName;
            set => openFileDialog.FileName = value;
        }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public string Filter
        {
            get => openFileDialog.Filter;
            set => openFileDialog.Filter = value;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get => openFileDialog.Title;
            set => openFileDialog.Title = value;
        }
    }
}
