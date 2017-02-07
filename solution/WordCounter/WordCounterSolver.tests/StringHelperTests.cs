using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Helper;
using System.Collections.Generic;

namespace WordCounterSolver.tests
{
    [TestClass]
    public class StringHelperTests
    {
        #region SplitWordsFromText
        [TestMethod]
        public void NoWord()
        {
            CollectionAssert.AreEqual(new string[0] { }, StringHelper.SplitWordsFromText(""));
        }
        [TestMethod]
        public void SimpleWord()
        {
            CollectionAssert.AreEqual(new string[1] { "a" }, StringHelper.SplitWordsFromText("a"));
        }
        [TestMethod]
        public void SimpleSpace()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a b"));
        }

        [TestMethod]
        public void DoubleSpace()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a  b"));
        }

        [TestMethod]
        public void MultipleSpace()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a                                               b"));
        }

        [TestMethod]
        public void Comma()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a,b"));
        }

        [TestMethod]
        public void CommaSpace()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a, b"));
        }

        [TestMethod]
        public void CommaSpaceDot()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a, b. "));
        }

        [TestMethod]
        public void SpaceBeforeSpaceAfter()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("   a   b   "));
        }

        [TestMethod]
        public void NewLineAndTabs()
        {
            CollectionAssert.AreEqual(new string[2] { "a", "b" }, StringHelper.SplitWordsFromText("a.\n\tb"));
        }

        [TestMethod]
        public void RepeatedWords()
        {
            CollectionAssert.AreEqual(new string[5] { "a", "b", "a", "b", "b" }, StringHelper.SplitWordsFromText("a b a b b"));
        }
        #endregion

        #region GetWordCount
        [TestMethod]
        public void GetWordCountNoWords()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            var response = StringHelper.GetWordCount(new string[0] { });
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetWordCountSeperateWords()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 1);
            expected.Add("b", 1);
            var response = StringHelper.GetWordCount(new string[2] { "a", "b" });
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetWordCountRepeatedWords()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 2);
            var response = StringHelper.GetWordCount(new string[2] { "a", "a" });
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetWordCountRepeatedWordsMaintainOrder1()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("a", 2);
            expected.Add("b", 2);
            var response = StringHelper.GetWordCount(new string[4] { "a", "b", "b", "a" });
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetWordCountRepeatedWordsMaintainOrder2()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("b", 2);
            expected.Add("a", 2);
            var response = StringHelper.GetWordCount(new string[4] { "b", "b", "a", "a" });
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetWordCountRepeatedWordsMultiple()
        {
            Dictionary<string, int> expected = new Dictionary<string, int>();
            expected.Add("b", 4);
            expected.Add("a", 2);
            var response = StringHelper.GetWordCount(new string[6] { "b", "b", "a", "a", "b", "b" });
            CollectionAssert.AreEqual(expected, response);
        }
        #endregion

        #region GetLinesOfTextToDisplay
        [TestMethod]
        public void GetLinesOfTextToDisplayNoLines()
        {
            List<string> expected = new List<string>();
            var response = StringHelper.GetLinesOfTextToDisplay(new Dictionary<string, int>());
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetLinesOfTextToDisplayOneLine()
        {
            List<string> expected = new List<string>();
            expected.Add("1: a");
            var dictionaryAux = new Dictionary<string, int>();
            dictionaryAux.Add("a", 1);
            var response = StringHelper.GetLinesOfTextToDisplay(dictionaryAux);
            CollectionAssert.AreEqual(expected, response);
        }
        [TestMethod]
        public void GetLinesOfTextToDisplayManyLines()
        {
            List<string> expected = new List<string>();
            expected.Add("1: a");
            expected.Add("5: b");
            var dictionaryAux = new Dictionary<string, int>();
            dictionaryAux.Add("a", 1);
            dictionaryAux.Add("b", 5);
            var response = StringHelper.GetLinesOfTextToDisplay(dictionaryAux);
            CollectionAssert.AreEqual(expected, response);
        }
        #endregion

        #region Systemic
        [TestMethod]
        public void SystemicSimple()
        {
            List<string> expected = new List<string>();
            expected.Add("1: a");
            expected.Add("1: b");
            Solver solver = new Solver();
            CollectionAssert.AreEqual(expected, solver.SolveChallenge("a b"));
        }
        [TestMethod]
        public void SystemicRepeated()
        {
            List<string> expected = new List<string>();
            expected.Add("2: a");
            expected.Add("3: b");
            expected.Add("1: abc");
            Solver solver = new Solver();
            CollectionAssert.AreEqual(expected, solver.SolveChallenge("a b ,abc.\n a b b"));
        }
        [TestMethod]
        public void SystemBaseTest()
        {
            List<string> expected = new List<string>();
            expected.Add("1: Go");
            expected.Add("2: do");
            expected.Add("2: that");
            expected.Add("1: thing");
            expected.Add("1: you");
            expected.Add("1: so");
            expected.Add("1: well");

            Solver solver = new Solver();
            CollectionAssert.AreEqual(expected, solver.SolveChallenge("Go do that thing that you do so well"));
        }
        #endregion

        #region GENERIC
        [TestMethod]
        public void Casing()
        {
            List<string> expected = new List<string>();
            expected.Add("1: a");
            expected.Add("1: A");
            Solver solver = new Solver();
            CollectionAssert.AreEqual(expected, solver.SolveChallenge("a A"));
        }
        #endregion
    }
}
