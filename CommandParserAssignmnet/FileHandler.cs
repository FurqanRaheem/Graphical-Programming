using System;
using System.IO;
using System.Windows.Forms;

namespace CommandParserAssignmnet;
public class FileHandler
{
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
                    Console.WriteLine($"Error saving file: {ex.Message}");
                    return false; // Failure
                }
            }
        }

        return false; // Dialog was canceled
    }

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
                    Console.WriteLine($"Error loading file: {ex.Message}");
                    return null; // Return null to indicate failure
                }
            }
        }

        return null; // Dialog was canceled
    }
}
