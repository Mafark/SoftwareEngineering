using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WaybillParser;
using System.Linq;

namespace WaybillParserTests
{
    [TestClass]
    public class WaybillParserTests
    {
        [TestMethod]
        public void ParserWaybill()
        {
            var WaybillParser = new WaybillParserImplemention();
            WaybillParser.SendDataFromTheWaybill("C:\\nakladnaya_za_sentyabr.bill", 1000000, "test1l1@yandex.ru");
        }

        [TestMethod]
        public void ParseLinesFromWaybillFile_ReturnTrue()
        {
            var WaybillParser = new WaybillParserImplemention();
            string[] expectedArray = new string[] { "test1", "test2" };
            var resultingArray = WaybillParser.ParseLinesFromWaybillFile("C:\\nakladnaya_test.bill");
            Assert.IsTrue(expectedArray.SequenceEqual(resultingArray));
        }

        [TestMethod]
        public void CountOfOrderPrice_SatisfiesEquality()
        {
            var WaybillParser = new WaybillParserImplemention();
            var expectedSum = 3;
            string[,] testArray = new string[,] { { "null", "null", "null", "null", "null" }, { "0", "A", "1", "1", "1" }, { "1", "B", "1", "1", "2" } };
            WaybillParser.LengthOfFile = 3;
            var resultSum = WaybillParser.OrderPrice(testArray);
            Assert.AreEqual(expectedSum, resultSum);
        }

        [TestMethod]
        public void CountOfEntireMass_SatisfiesEquality()
        {
            var WaybillParser = new WaybillParserImplemention();
            var expectedSum = 2;
            string[,] testArray = new string[,] { { "null", "null", "null", "null", "null" }, { "0", "A", "1", "1", "1" }, { "1", "B", "1", "1", "2" } };
            WaybillParser.LengthOfFile = 3;
            var resultSum = WaybillParser.EntireMass(testArray);
            Assert.AreEqual(expectedSum, resultSum);
        }

        [TestMethod]
        public void MassLessThanPermissible_ReturnTrue()
        {
            var WaybillParser = new WaybillParserImplemention();
            string[,] testArray = new string[,] { { "null", "null", "null", "null", "null" }, { "0", "A", "1", "1", "1" }, { "1", "B", "1", "1", "2" } };
            WaybillParser.LengthOfFile = 3;
            var MassLessThanPermissible = WaybillParser.MassLessThanPermissible(testArray, 100);
            Assert.IsTrue(MassLessThanPermissible == true);
        }

        [TestMethod]
        public void LetterGeneration_SatisfiesEquality()
        {
            var WaybillParser = new WaybillParserImplemention();
            var letter = WaybillParser.LetterGeneration(100, true);
            Assert.AreEqual(letter, "Общая сумма заказа: 100\nМасса заказа не превышает допустимую");
        }
    }
}