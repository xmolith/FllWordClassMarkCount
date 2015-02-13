using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace mark
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime startTime;
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            background.Source = new BitmapImage(new Uri(@"/background.jpg", UriKind.Relative));

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender;
            if (r.ContextMenu!=null) {
                r.ContextMenu.IsOpen = true;
            }
        }

        private void checkcheck(object sender, RoutedEventArgs e)
        {
            MenuItem m = (MenuItem)sender;
            switch (m.Name) { 
            //search
                case "search1":
                    search2.IsChecked = false;
                    break;
                case "search2":
                    search1.IsChecked = false;
                    break;


                case "shoot1":
                    shoot2.IsChecked = false;
                    break;
                case "shoot2":
                    shoot1.IsChecked = false;
                    break;


                case "out1":
                    out2.IsChecked = false;
                    break;
                case "out2":
                    out1.IsChecked = false;
                    break;

                case "block1":
                    block2.IsChecked = false;
                    break;
                case "block2":
                    block2.IsChecked = false;
                    break;




            }
        }

        private void summer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            summer_show.Content = summer.Value.ToString();
        }

        private void percenter_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            percent_show.Content = percenter.Value.ToString() + "%";
        }

        private void calcBtn_Click(object sender, RoutedEventArgs e)
        {
            int i=0;
            if (dooropen.IsChecked) { i += 15; }
            if (cloud.IsChecked) { i += 30; }
            if (commStudy.IsChecked) { i += 25; }
            if (block1.IsChecked) { i += 25; }
            if (block2.IsChecked) { i += 55; }
            if (rightSenser.IsChecked) { i += 40; }
            if (out1.IsChecked) { i += 25; }
            if (out2.IsChecked) { i += 40; }
            if (search1.IsChecked) { i += 15; }
            if (search2.IsChecked) { i += 60; }
            if (remote.IsChecked) { i += 40; }
            if (shoot1.IsChecked) { i += 30; }
            if (shoot2.IsChecked) { i += 60; }
            if (route.IsChecked) { i += 15; }
            if (pencent1.IsChecked) { i += 20; }
            int num = (int)summer.Value;
            if (num > 0) { i+=20;}
            i += 10 * (num - 1);
            i += int.Parse(number1.Text);
            i += int.Parse(number2.Text);
            baseMark.Content = i.ToString();
            //-------------
            var ii = i * (1 + percenter.Value / 100);
            mark.Content = ii.ToString();

        }

        private void restartBtn_Click(object sender, RoutedEventArgs e)
        {
            var win=new MainWindow();
            win.Show();
            this.Close();
        }

        private void timestartBtn_Click(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer(); //初始化timer
            timer.Interval = new TimeSpan(0, 0, 1); //设置时间间隔TimeSpan(时, 分, 秒)
            startTime = DateTime.Now;
            timer.Tick += new EventHandler(Timer_Tick); //委托
            timer.Start(); //开始计时

        }
        void Timer_Tick(object send, EventArgs e)
        {
            var time= DateTime.Now - startTime;

            this.Title ="用时"+ ((int)time.TotalSeconds).ToString()+"秒";
        }

        private void stopBtn_Click(object sender, RoutedEventArgs e)
        {
            if (timer != null) { timer.Stop(); }
            
        }

        private void Label_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/ysw0145/FllWordClassMarkCount");
        }




    }
}
