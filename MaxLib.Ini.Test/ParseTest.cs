using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaxLib.Ini.Test
{
    [TestClass]
    public class ParseTest
    {
        [TestMethod]
        public void TestParseEmpty()
        {
            var iniFile = new Parser.IniParser().ParseFromString("");
            Assert.IsNotNull(iniFile);
            Assert.AreEqual(1, iniFile.Count);
            Assert.AreEqual(0, iniFile[0].Attributes.Count);
            Assert.AreEqual(0, iniFile[0].Elements.Count);
        }

        [TestMethod]
        public void TestParseSimpleRules()
        {
            var iniFile = new Parser.IniParser().ParseFromString(@"
foo=bar
baz = 42
# comment
            ");
            Assert.IsNotNull(iniFile);
            Assert.AreEqual(1, iniFile.Count);
            Assert.AreEqual(0, iniFile[0].Attributes.Count);
            Assert.AreEqual(5, iniFile[0].Elements.Count);
            Assert.IsTrue(iniFile[0][0] is IniSpace);
            Assert.IsTrue(iniFile[0][1] is IniOption);
            Assert.AreEqual("foo", ((IniOption)iniFile[0][1]).Name);
            Assert.AreEqual("bar", ((IniOption)iniFile[0][1]).ValueText);
            Assert.IsTrue(iniFile[0][2] is IniOption);
            Assert.AreEqual("baz", ((IniOption)iniFile[0][2]).Name);
            Assert.AreEqual("42", ((IniOption)iniFile[0][2]).ValueText);
            Assert.IsTrue(iniFile[0][3] is IniComment);
            Assert.AreEqual(" comment", ((IniComment)iniFile[0][3]).Comment);
            Assert.IsTrue(iniFile[0][4] is IniSpace);
        }

        [TestMethod]
        public void TestParseSingleGroup()
        {

            var iniFile = new Parser.IniParser().ParseFromString(@"
[foo]
            ");
            Assert.IsNotNull(iniFile);
            Assert.AreEqual(2, iniFile.Count);
            Assert.AreEqual(0, iniFile[0].Attributes.Count);
            Assert.AreEqual(1, iniFile[0].Elements.Count);
            Assert.IsTrue(iniFile[0][0] is IniSpace);
            Assert.AreEqual(0, iniFile[1].Attributes.Count);
            Assert.AreEqual(1, iniFile[1].Elements.Count);
            Assert.IsTrue(iniFile[1][0] is IniSpace);
        }

        [TestMethod]
        public void TestParseGroupWithAttributes()
        {

            var iniFile = new Parser.IniParser().ParseFromString(@"
[foo(bar=42;baz=1)]
            ");
            Assert.IsNotNull(iniFile);
            Assert.AreEqual(2, iniFile.Count);
            Assert.AreEqual(0, iniFile[0].Attributes.Count);
            Assert.AreEqual(1, iniFile[0].Elements.Count);
            Assert.IsTrue(iniFile[0][0] is IniSpace);
            Assert.AreEqual(2, iniFile[1].Attributes.Count);
            Assert.AreEqual("bar", iniFile[1].Attributes[0].Name);
            Assert.AreEqual("42", iniFile[1].Attributes[0].ValueText);
            Assert.AreEqual("baz", iniFile[1].Attributes[1].Name);
            Assert.AreEqual("1", iniFile[1].Attributes[1].ValueText);
            Assert.AreEqual(1, iniFile[1].Elements.Count);
            Assert.IsTrue(iniFile[1][0] is IniSpace);
        }
    }
}