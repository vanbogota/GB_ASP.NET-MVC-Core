using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;

namespace Lesson_1
{
    public partial class MainWindow : Window
    {
        private static int _num1;
        private static int _num2 = 1;
        private static int _fibNum;
        private static int _seconds = 1;
        public MainWindow()
        {
            InitializeComponent();

            _seconds = (int)ScrollName.Value;
            ScrollText.Text = _seconds.ToString();
        }

        private string FibonachiNumberString(int timeout)
        {
            lock (this)
            {
                _fibNum = _num1 + _num2;
                _num1 = _num2;
                _num2 = _fibNum;
            }            

            Thread.Sleep(timeout * 1000);

            return _fibNum.ToString();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new(new ThreadStart(() =>
            {
                string result = FibonachiNumberString(_seconds);
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Action(() =>
                {
                    ResultText.Text = result;
                }));
            }));
            thread.Start();
        }

        private void ScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            _seconds = (int)ScrollName.Track.Value;
            ScrollText.Text = _seconds.ToString();
        }

    }
}
