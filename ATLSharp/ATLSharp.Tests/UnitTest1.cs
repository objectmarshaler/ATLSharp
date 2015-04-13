using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Antlr4.Runtime.Tree;
using System.IO;

namespace ATLSharp.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ParseCorrectTransformation()
        {
            IATLTransformationParser parser = new ATLTransformationParser();
            IParseTree result = parser.Parse("../../Families2Persons.atl");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ParseATLFromString()
        {
            var content = File.ReadAllText("../../Families2Persons.atl");

            IATLTransformationParser parser = new ATLTransformationParser();
            IParseTree result = parser.ParseString(content);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException), "Could not load the ATL file.")]
        public void ParseIncorrectTransformation()
        {
            IATLTransformationParser parser = new ATLTransformationParser();
            IParseTree result = parser.Parse("DummyFamilies2Persons.atl");
        }
    }
}
