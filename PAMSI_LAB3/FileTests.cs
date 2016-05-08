using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMSI_LAB3
{
    public class FileTests
    {
        private int[] entrySizes;
        private Stopwatch singleTestTimer;
        private List<double> singleRunTestTimes;
        private delegate void testFunction();

        public FileTests(int[] sizes)
        {
            entrySizes = sizes;
            singleRunTestTimes = new List<double>();
            singleTestTimer = new Stopwatch();
        }

        private void runTimer()
        {
            singleTestTimer.Restart();
        }

        private double getSingleTestTime()
        {
            singleTestTimer.Stop();
            return singleTestTimer.Elapsed.TotalMilliseconds;
        }

        private void runArrayQueueTest(int elementsCount)
        {
            
        }

        private void singleTestTemplate(testFunction singleTest, int cycles)
        {
            double fullTestTime = 0;
            
            for (int i = 0; i < cycles; i++)
            {
                runTimer();
                singleTest();
                fullTestTime += getSingleTestTime();
            }
            singleRunTestTimes.Add(fullTestTime / cycles);
        }

        public void printTests() {
            TestFileWriter fileWritter = new TestFileWriter(new System.IO.StreamWriter("test.txt"));
            String[] titles = { "listQueueTest" };
            fileWritter.WriteTitles(titles);
            Tests test = new Tests(10000);

            singleTestTemplate(test.listQueueTest, 100);
            
            fileWritter.WriteArrayToFile(singleRunTestTimes.ToArray());

            
            fileWritter.CloseTestFileWritter();
        }
       
    }
}
