using Moq;
using System.Windows.Forms;

namespace Tests
{
    /// <summary>
    /// Unit tests for the FileHandler class using Moq and MSTest.
    /// </summary>
    [TestClass]
    public class FileHandlerTest
    {
        /// <summary>
        /// Tests the SaveToFile method for success.
        /// </summary>
        [TestMethod]
        public void SaveToFile_Success()
        {
            // Arrange
            var content = "moveTo 100,100\r\ncircle 50";
            var mockSaveFileDialog = new Mock<IFileDialog>();
            mockSaveFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.OK);
            mockSaveFileDialog.SetupGet(fd => fd.FileName).Returns("testfile.gpl");

            var fileHandler = new FileHandler(mockSaveFileDialog.Object, null);

            // Act
            var result = fileHandler.SaveToFile(content);

            // Assert
            Assert.IsTrue(result, "SaveToFile should return true for success.");
            mockSaveFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
            mockSaveFileDialog.VerifyGet(fd => fd.FileName, Times.Once);

            // Assert that the file was created and contains the correct content
            Assert.IsTrue(File.Exists("testfile.gpl"), "The file should exist after saving.");
            File.Delete("testfile.gpl"); // Clean up the test file
        }

        /// <summary>
        /// Tests the SaveToFile method when the dialog is canceled.
        /// </summary>
        [TestMethod]
        public void SaveToFile_DialogCanceled()
        {
            // Arrange
            var content = "moveTo 100,100\r\ncircle 50";
            var mockSaveFileDialog = new Mock<IFileDialog>();
            mockSaveFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.Cancel);

            var fileHandler = new FileHandler(mockSaveFileDialog.Object, null);

            // Act
            var result = fileHandler.SaveToFile(content);

            // Assert
            Assert.IsFalse(result, "SaveToFile should return false when the dialog is canceled.");
            mockSaveFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
        }

        /// <summary>
        /// Tests the LoadFromFile method for success.
        /// </summary>
        [TestMethod]
        public void LoadFromFile_Success()
        {
            // Arrange
            var mockOpenFileDialog = new Mock<IFileDialog>();
            mockOpenFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.OK);
            mockOpenFileDialog.SetupGet(fd => fd.FileName).Returns("testfile.gpl");
            var fileContent = "moveTo 100,100\r\ncircle 50";
            File.WriteAllText("testfile.gpl", fileContent);

            var fileHandler = new FileHandler(null, mockOpenFileDialog.Object);

            // Act
            var loadedText = fileHandler.LoadFromFile();

            // Assert
            Assert.AreEqual(fileContent, loadedText, "Loaded text should match the file content.");
            mockOpenFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
            File.Delete("testfile.gpl"); // Clean up the test file
        }

        /// <summary>
        /// Tests the LoadFromFile method when the dialog is canceled.
        /// </summary>
        [TestMethod]
        public void LoadFromFile_DialogCanceled()
        {
            // Arrange
            var mockOpenFileDialog = new Mock<IFileDialog>();
            mockOpenFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.Cancel);

            var fileHandler = new FileHandler(null, mockOpenFileDialog.Object);

            // Act
            var loadedText = fileHandler.LoadFromFile();

            // Assert
            Assert.IsNull(loadedText, "Loaded text should be null when the dialog is canceled.");
            mockOpenFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
        }
    }
}
