using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter;

namespace WordCountTests
{
    [TestClass]
    public class CountVowelWordsTests
    {
        [TestMethod]
        public void QuantityOfWords_Is4()
        {
            string inputText = "dds sfdsd aaa\r\nsdfs ds iiii yyyY\r\nie";
            var result = Program.CountVowelWords(inputText);
            Assert.AreEqual(result, 4);
        }

        [TestMethod]
        public void QuantityOfWords_Is0()
        {
            string inputText = "dds sfdsd aaba\r\nsdfs ds ityiii yysyY\r\nieq";
            var result = Program.CountVowelWords(inputText);
            Assert.AreEqual(result, 0);
        }

        [TestMethod]
        public void LowerCaseWord_Is1()
        {
            string inputText = "dds aiy\r\nsfdsd";
            var result = Program.CountVowelWords(inputText);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void UpperCaseWord_Is1()
        {
            string inputText = "dds AIY\r\nsfdsd";
            var result = Program.CountVowelWords(inputText);
            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public void CamelCaseWord_Is1()
        {
            string inputText = "dds AiY\r\nsfdsd";
            var result = Program.CountVowelWords(inputText);
            Assert.AreEqual(result, 1);
        }
    }
}
