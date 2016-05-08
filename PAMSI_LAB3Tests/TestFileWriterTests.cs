using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAMSI_LAB3;
using PAMSI_LAB3Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMSI_LAB3.Tests
{
    [TestClass()]
    public class TestFileWriterTests
    {
        private streamWriterMock writterMock;
        private TestFileWriter testFileWritter;
        [TestInitialize()]
        public void initialize()
        {
            writterMock = new streamWriterMock("ChujCiWDupe");
            testFileWritter = new TestFileWriter(writterMock);
        }
        [TestMethod()]
        public void isWriteFileMockWorking()
        {
            double[] arr = { 1, 2, 3 };
            testFileWritter.WriteArrayToFile(arr);
            Assert.AreEqual("1\t2\t3\n", writterMock.getWrittedLines());
        }
        [TestMethod()]
        public void canWriteJustOneElement()
        {
            double[] arr = { 1};
            testFileWritter.WriteArrayToFile(arr);
            Assert.AreEqual("1\n", writterMock.getWrittedLines());
        }

        [TestMethod()]
        public void canHandleEmptyInput()
        {
            double[] arr = {};
            testFileWritter.WriteArrayToFile(arr);
            Assert.AreEqual("", writterMock.getWrittedLines());
        }
    }
}