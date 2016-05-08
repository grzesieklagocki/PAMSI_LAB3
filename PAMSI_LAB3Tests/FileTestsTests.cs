using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAMSI_LAB3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollections;

namespace PAMSI_LAB3.Tests
{
    [TestClass()]
    public class FileTestsTests
    {
        [TestMethod()]
        public void addToMyList()
        {
            MyList<int> theList = new MyList<int>();
            theList.Add(1);
            Assert.AreEqual(theList[0], 1);
        }

        [TestMethod()]
        public void addToDeque()
        {
            MyDeque<int> theQueue = new MyDeque<int>();
            theQueue.AddFirst(123);
            Assert.AreEqual(theQueue[0], 123);
        }
    }
}