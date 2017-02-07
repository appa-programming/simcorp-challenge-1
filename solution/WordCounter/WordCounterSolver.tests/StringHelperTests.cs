using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordCounter.Helper;

namespace WordCounterSolver.tests
{
    [TestClass]
    public class StringHelperTests
    {
        #region SplitWordsFromText
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
    }
}
