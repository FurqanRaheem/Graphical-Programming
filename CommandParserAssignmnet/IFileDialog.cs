namespace CommandParserAssignmnet
{
    /// <summary>
    /// Represents an interface for a file dialog, which is used to allow mocking of file dialog interactions in unit tests.
    /// </summary>
    public interface IFileDialog
    {
        /// <summary>
        /// Shows the file dialog and returns the result of the user's interaction.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> indicating the user's choice or action.</returns>
        DialogResult ShowDialog();

        /// <summary>
        /// Gets or sets the name of the selected file.
        /// </summary>
        /// <value>
        /// The name of the selected file.
        /// </value>
        string FileName { get; set; }

        /// <summary>
        /// Gets or sets the filter that defines the file types displayed in the dialog.
        /// </summary>
        /// <value>
        /// The filter string used to filter file types, e.g., "Text Files|*.txt|All Files|*.*".
        /// </value>
        string Filter { get; set; }

        /// <summary>
        /// Gets or sets the title or caption displayed in the file dialog.
        /// </summary>
        /// <value>
        /// The title or caption of the file dialog window.
        /// </value>
        string Title { get; set; }
    }
}
