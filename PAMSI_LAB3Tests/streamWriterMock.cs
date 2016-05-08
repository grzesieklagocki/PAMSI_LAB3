using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAMSI_LAB3Tests
{
    public class streamWriterMock : System.IO.TextWriter
    {
        private String writtedLines = "";
        public streamWriterMock(String fileName)
        {

        }

        public override void Write(String lines)
        {
            writtedLines += lines;
        }

        public override void WriteLine(String lines)
        {
            writtedLines += lines + "\n";
        }

        public String getWrittedLines()
        {
            return writtedLines;
        }
        public override Encoding Encoding
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
