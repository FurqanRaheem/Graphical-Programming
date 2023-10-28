using System;
using System.IO;
using System.Windows.Forms;

namespace CommandParserAssignmnet;
public class FileHandler
{


    /// <summary>
    /// Saves the specified content to a file. Shows a SaveFileDialog to allow the user to choose the file location and name.
    /// </summary>
    /// <param name="content">The text or content to be saved to the file.</param>
    /// <returns>True if the save operation is successful, false otherwise.</returns>
    public bool SaveToFile(string content)
    {
        using (SaveFileDialog saveFileDialog = new SaveFileDialog())
        {
            saveFileDialog.Filter = "GPL Files|*.gpl|Text Files|*.txt|All Files|*.*";
            saveFileDialog.Title = "Save GPL File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    File.WriteAllText(filePath, content);
                    return true; // Success
                }
                catch (Exception ex)
                { 
                    return false; // Failure
                }
            }
        }

        return false; // Dialog was canceled
    }

    /// <summary>
    /// Loads content from a file. Shows an OpenFileDialog to allow the user to choose a file to open.
    /// </summary>
    /// <returns>The loaded text as a string if the load operation is successful, or null if there's an error or if the user cancels the dialog.</returns>
    public string? LoadFromFile()
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "GPL Files|*.gpl|Text Files|*.txt|All Files|*.*";
            openFileDialog.Title = "Open GPL File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string loadedText = File.ReadAllText(filePath);
                    return loadedText;
                }
                catch (Exception ex)
                {
                    return null; // Return null to indicate failure
                }
            }
        }

        return null; // Dialog was canceled
    }
}
