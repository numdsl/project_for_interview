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
        public MainWindow()
        {
            InitializeComponent();
        }

        Thread th { get; set; }

        public void button_click(object sender, RoutedEventArgs e)
        {
            th = new Thread(Increment);
            th.Name = "thread1";
            th.Start();
        }

        public void button1_click(object sender, RoutedEventArgs e)
        {
            if (th == null)
                return;

            if (th.ThreadState == ThreadState.Suspended)
                th.Resume();
            else
                th.Suspend();

        }

        static void Increment()
        {
            var x = 0;
            for (var i = 0; i < 10; i++)
            {
                x++;
                Thread.Sleep(500);
            }

            

            MessageBox.Show(x.ToString());
        }

    }
}
