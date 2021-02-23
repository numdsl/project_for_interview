using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace test_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Thread th { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = string.Empty;

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (th == null)
                return;

            th.Abort();
        }

        public void button_click(object sender, RoutedEventArgs e)
        {
            if (th != null && (th.ThreadState == ThreadState.Running || th.ThreadState == ThreadState.WaitSleepJoin))
                return;

            th = new Thread(Increment);
            th.Name = "thread1";
            textBox.Dispatcher.Invoke(new Action(() => textBox.Text = string.Empty));
            th.Start();
        }

        public void button1_click(object sender, RoutedEventArgs e)
        {
            if (th == null)
                return;

            if (th.ThreadState == ThreadState.Suspended)
                th.Resume();
            else if (th.ThreadState == ThreadState.Running || th.ThreadState == ThreadState.WaitSleepJoin)
                th.Suspend();
        }

        public void button2_click(object sender, RoutedEventArgs e)
        {
            if (th == null)
                return;

            th.Abort();
        }

        public void Increment()
        {
            var x = 0;
            for (;;)
            {
                x++;
                if (x % 10 == 0)
                {
                    textBox.Dispatcher.Invoke(new Action(() => textBox.Text = x.ToString()));
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
