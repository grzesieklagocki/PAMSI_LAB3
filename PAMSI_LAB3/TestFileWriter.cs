using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMSI_LAB3
{
    public class TestFileWriter
    {
        private System.IO.TextWriter streamWriter;
        public TestFileWriter(System.IO.TextWriter sw)
        {
            streamWriter = sw;
        }

        public void CloseTestFileWritter()
        {
            streamWriter.Close();
        }

        public void WriteTitles(String[] titles)
        {
            WriteArrayOfStringsToFile(titles);
        }

        public void WriteArrayToFile(double[] testTimes)
        {
            List<String> arrayOfStrings = new List<String>();
            foreach (var time in testTimes)
            {
                arrayOfStrings.Add(time.ToString());
            }
            WriteArrayOfStringsToFile(arrayOfStrings.ToArray());
        }

        private void WriteArrayOfStringsToFile(String[] arrayOfStrings)
        {
            if (arrayOfStrings.Length < 1)
                return;

            for (int i = 0; i < arrayOfStrings.Length - 1; i++)
            {
                streamWriter.Write(arrayOfStrings[i] + "\t");
            }
            streamWriter.WriteLine(arrayOfStrings[arrayOfStrings.Length - 1]);
        }
    }
}
