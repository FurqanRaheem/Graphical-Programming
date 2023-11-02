using Moq;
using System.Windows.Forms;

namespace Tests
{
    [TestClass]
    public class FileHandlerTest
    {
        [TestMethod]
        public void SaveToFile_Success()
        {
            // Arrange
            var content = "Test content";
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
            File.Delete("testfile.gpl"); // Clean up the test file
        }

        [TestMethod]
        public void SaveToFile_DialogCanceled()
        {
            // Arrange
            var content = "Test content";
            var mockSaveFileDialog = new Mock<IFileDialog>();
            mockSaveFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.Cancel);

            var fileHandler = new FileHandler(mockSaveFileDialog.Object, null);

            // Act
            var result = fileHandler.SaveToFile(content);

            // Assert
            Assert.IsFalse(result, "SaveToFile should return false when the dialog is canceled.");
            mockSaveFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
        }

        [TestMethod]
        public void LoadFromFile_Success()
        {
            // Arrange
            var mockOpenFileDialog = new Mock<IFileDialog>();
            mockOpenFileDialog.Setup(fd => fd.ShowDialog()).Returns(DialogResult.OK);
            mockOpenFileDialog.SetupGet(fd => fd.FileName).Returns("testfile.gpl");
            var fileContent = "Test content";
            File.WriteAllText("testfile.gpl", fileContent);

            var fileHandler = new FileHandler(null, mockOpenFileDialog.Object);

            // Act
            var loadedText = fileHandler.LoadFromFile();

            // Assert
            Assert.AreEqual(fileContent, loadedText, "Loaded text should match the file content.");
            mockOpenFileDialog.Verify(fd => fd.ShowDialog(), Times.Once);
            File.Delete("testfile.gpl"); // Clean up the test file
        }

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
