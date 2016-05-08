using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using MyCollections;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace PAMSI_LAB3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyStackArray<int> mystack = new MyStackArray<int>(5);
        private MyQueueArray<int> myqueue = new MyQueueArray<int>(5);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStackAction_Click(object sender, RoutedEventArgs e)
        {
            int val;

            if (rdbPush.IsChecked == true)
            {
                if (int.TryParse(txbValue.Text, out val))
                {
                    mystack.Push(val);

                    txbCommands.Inlines.Add(new Run("> Dodano") { FontWeight = FontWeights.Bold });
                    txbCommands.Inlines.Add(" element o wartości ");
                    txbCommands.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                else
                    MessageBox.Show("Wpisz prawidłową liczbę");
            }
            else if (rdbPop.IsChecked == true)
            {
                try
                {
                    val = mystack.Pop();

                    txbCommands.Inlines.Add(new Run("> Pobrano") { FontWeight = FontWeights.Bold });
                    txbCommands.Inlines.Add(" element o wartości ");
                    txbCommands.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                catch (Exception)
                {
                    MessageBox.Show("Kolejka pusta");
                }
            }
            else if (rdbPeek.IsChecked == true)
            {
                try
                {
                    val = mystack.Peek();

                    txbCommands.Inlines.Add(new Run("> Pierwszy element") { FontWeight = FontWeights.Bold });
                    txbCommands.Inlines.Add(" ma wartość ");
                    txbCommands.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                catch (Exception)
                {
                    MessageBox.Show("Kolejka pusta");
                }


            }

            Display(mystack, "stos", txbResults);
            txbCount.Text = mystack.Count.ToString();
        }

        private void Display(MyCollectionArray<int> collection, string title, TextBlock txb)
        {
            txb.Text = title.ToUpper() + " - elementy:" + Environment.NewLine;

            for (int i = 0; i < collection.Count; i++)
                txb.Inlines.Add(title + "[" + i + "]:  " + collection[i] + Environment.NewLine);
        }

        private void btnQueueAction_Click(object sender, RoutedEventArgs e)
        {
            int val;

            if (rdbEnqeue.IsChecked == true)
            {
                if (int.TryParse(txbValueQ.Text, out val))
                {
                    myqueue.Enqueue(val);

                    txbCommandsQ.Inlines.Add(new Run("> Dodano") { FontWeight = FontWeights.Bold });
                    txbCommandsQ.Inlines.Add(" element o wartości ");
                    txbCommandsQ.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                else
                    MessageBox.Show("Wpisz prawidłową liczbę");
            }
            else if (rdbDequeue.IsChecked == true)
            {
                try
                {
                    val = myqueue.Dequeue();

                    txbCommandsQ.Inlines.Add(new Run("> Pobrano") { FontWeight = FontWeights.Bold });
                    txbCommandsQ.Inlines.Add(" element o wartości ");
                    txbCommandsQ.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                catch (Exception)
                {
                    MessageBox.Show("Kolejka pusta");
                }
            }
            else if (rdbPeekQ.IsChecked == true)
            {
                try
                {
                    val = myqueue.Peek();

                    txbCommandsQ.Inlines.Add(new Run("> Pierwszy element") { FontWeight = FontWeights.Bold });
                    txbCommandsQ.Inlines.Add(" ma wartość ");
                    txbCommandsQ.Inlines.Add(new Run(val.ToString() + Environment.NewLine) { FontWeight = FontWeights.Bold });
                }
                catch (Exception)
                {
                    MessageBox.Show("Kolejka pusta");
                }


            }

            Display(myqueue, "kolejka", txbResultsQ);
            txbCountQ.Text = myqueue.Count.ToString();
        }

        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            uint cycles, c1, c2, c3;

            if (uint.TryParse(txbCycles.Text, out cycles) && uint.TryParse(txbC1.Text, out c1)
                && uint.TryParse(txbC2.Text, out c2) && uint.TryParse(txbC3.Text, out c3))
                Tests.Test(cycles, c1, txbCommandsT);
            else
                MessageBox.Show("Wpisz prawidlowe dane");
        }

        private void btnHanoi_Click(object sender, RoutedEventArgs e)
        {
            int cnt;
            if (int.TryParse(txbHanoiCnt.Text, out cnt))
                Hanoi.Solve(cnt, txbCommandsH);
        }
    }
}
