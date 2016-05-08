using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using MyCollections;

namespace PAMSI_LAB3
{
    static class Hanoi
    {
        private static MyStackArray<int> src, tmp, dst;
        private static TextBlock txb;

        public static void Solve(int disc_cnt, TextBlock txb)
        {
            src = new MyStackArray<int>(disc_cnt);
            tmp = new MyStackArray<int>(disc_cnt);
            dst = new MyStackArray<int>(disc_cnt);

            for (int i = disc_cnt; i > 0; i--)
                src.Push(i);

            Hanoi.txb = txb;

            Display();

            Solve(src, tmp, dst, disc_cnt);
        }

        private static void Solve(MyStackArray<int> source_peg, MyStackArray<int> temporary_peg, MyStackArray<int> destination_peg, int disc_nr)
        {
            if (disc_nr == 1)
                Move(source_peg, destination_peg);
            else
            {
                Solve(source_peg, destination_peg, temporary_peg, disc_nr - 1);
                Move(source_peg, destination_peg);
                Solve(temporary_peg, source_peg, destination_peg, disc_nr - 1);
            }

        }

        private static void Move(MyStackArray<int> source_peg, MyStackArray<int> destination_peg)
        {

            //if (!source_peg.IsEmpty() && (destination_peg.IsEmpty() || source_peg.Peek() < destination_peg.Peek()))
                destination_peg.Push(source_peg.Pop());
           // else
                //MessageBox.Show("niedozwolona operacja");

            Display();
        }
     
        private static void Display()
        {
            string text = string.Empty;

            for (int i = 0; src.Count > i || tmp.Count > i || dst.Count > i; i++)
            {
                try { text += src[i].ToString().PadLeft(15); }
                catch { text += "-".PadLeft(15); }

                try { text += tmp[i].ToString().PadLeft(15); }
                catch { text += "-".PadLeft(15); }

                try { text += dst[i].ToString().PadLeft(15); }
                catch { text += "-".PadLeft(15); }

                text += Environment.NewLine;
            }

            txb.Text += text + Environment.NewLine;
        }
    }

}
