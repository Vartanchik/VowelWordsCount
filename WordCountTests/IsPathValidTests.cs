using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCountTests
{
    [TestClass]
    public class IsPathValidTests
    {
        [TestMethod]
        public void AbsoluteCorrectPathWithTwoFolders_IsValid()
        {
            string inputPath = "D:\\folder1\\forder2\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AbsoluteCorrectPathWithoutFolders_IsValid()
        {
            string inputPath = "D:\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RalativeCorrectPathWithoutFolders_IsValid()
        {
            string inputPath = "\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RalativeCorrectPathWithTwoFolders_IsValid()
        {
            string inputPath = "folder1\\forder2\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RalativeCorrectPathWithTwoGoUpAndTwoFolders_IsValid()
        {
            string inputPath = "..\\..\\folder1\\forder2\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RalativeCorrectPathWithTwoGoUp_IsValid()
        {
            string inputPath = "..\\..\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RalativeCorrectPathWithoutGoUpAndWithoutFolders_IsValid()
        {
            string inputPath = "file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AbsoluteIncorrectPathWith007C_IsInvalid()
        {
            string inputPath = "D:|\\Hobby\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void AbsoluteIncorrectPathWith0022_IsInvalid()
        {
            string inputPath = "D:\"\\Hobby\\file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RalativesIncorrectPathWith0022_IsInvalid()
        {
            string inputPath = "\"file.txt";
            var result = Program.IsPathValid(inputPath);
            Assert.IsFalse(result);
        }
    }
}
