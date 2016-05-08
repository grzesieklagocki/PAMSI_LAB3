using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollections;
using System.Windows.Controls;
using System.Diagnostics;
using MyCollections;

namespace PAMSI_LAB3
{
    class Tests
    {
        private int elementsCount;
        private int[] elements;
        private Random random;

        public Tests(int elementsCount)
        {
            this.elementsCount = elementsCount;
            random = new Random();
            elements = new int[elementsCount];
            for (int i=0; i<elementsCount; i++)
            {
                elements[i] = random.Next();
            }
        }
        public void listQueueTest()
        {
            MyQueue<int> mq = new MyQueue<int>();
            for (int i = 0; i < elementsCount; i++)
                mq.Enqueue(elements[i]);
        }
    }
}
