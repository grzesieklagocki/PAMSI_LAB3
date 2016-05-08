using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCollections;
using System.Windows.Controls;
using System.Diagnostics;

namespace PAMSI_LAB3
{
    static class Tests
    {
        static private int[] elements_cnt = { 1000, 10000, 100000, 500000 };
        static Random rnd = new Random();
        static Stopwatch sw = new Stopwatch();
        static double time1 = 0, time2 = 0;

        public static void Test(uint cycles, uint c1, TextBlock txb)
        {
            txb.Text += "Stos - dodawanie/zdejmowanie" + Environment.NewLine;

            sw.Start();
            for (int i = 0; i < elements_cnt.Length; i++)
            {
                int[] values = new int[elements_cnt[i]];
                for (int j = 0; j < elements_cnt[i]; j++)
                    values[j] = rnd.Next(int.MaxValue);

                // stos tablicowo - strategia podwajania
                MyStackArray<int> s = new MyStackArray<int>(elements_cnt[i] / 5);

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        s.Push(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        s.Pop(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    s.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;


                // stos tablicowo - strategia rozszerzania o stala wartosc
                MyStackArray<int> s2 = new MyStackArray<int>(checked((int)c1), checked((int)c1));

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        s2.Push(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        s2.Pop(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    s2.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;


                // stos na liscie
                MyDeque<int> d = new MyDeque<int>();

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        d.AddLast(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        d.PopLast(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    d.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;

                // stos .Net
                Stack<int> st = new Stack<int>();

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        st.Push(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        st.Pop(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    st.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;

                txb.Text += Environment.NewLine;



                txb.Text += Environment.NewLine + "Kolejka - dodawanie/zdejmowanie" + Environment.NewLine;



                // kolejka tablicowo - strategia podwajania
                MyQueueArray<int> q = new MyQueueArray<int>(elements_cnt[i] / 5);

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q.Enqueue(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q.Dequeue(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    q.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;


                // stos tablicowo - strategia rozszerzania o stala wartosc
                MyQueueArray<int> q2 = new MyQueueArray<int>(checked((int)c1), checked((int)c1));

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q2.Enqueue(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q2.Dequeue(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    q2.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;


                // stos na liscie
                MyQueue<int> q3 = new MyQueue<int>();

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q3.Enqueue(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        q3.Dequeue(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    q3.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;

                // stos .Net
                Queue<int> qu = new Queue<int>();

                for (int k = 0; k < cycles; k++)
                {
                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        qu.Enqueue(values[j]); // dodawanie

                    sw.Stop();
                    time1 += sw.Elapsed.TotalMilliseconds;

                    sw.Restart();

                    for (int j = 0; j < elements_cnt[i]; j++)
                        qu.Dequeue(); // zdejmowanie

                    sw.Stop();
                    time2 += sw.Elapsed.TotalMilliseconds;

                    qu.Clear();
                }

                txb.Text += (time1 / cycles).ToString().PadLeft(15);
                txb.Text += " / " + (time2 / cycles).ToString().PadRight(15);
                time1 = time2 = 0;

                txb.Text += Environment.NewLine;
            }
        }
    }
}
