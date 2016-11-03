using MaterialWPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
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

namespace MaterialWPFTest
{
    /// <summary>
    /// Interaction logic for CircularProgress.xaml
    /// </summary>
    public partial class CircularProgress : UserControl
    {
        System.Windows.Threading.DispatcherTimer rTimer = new System.Windows.Threading.DispatcherTimer();
        double r = 0;
        double p = 0;

        public CircularProgress()
        {
            InitializeComponent();
        }

        private void raisedButton_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string text = procentInput.Text;
            int t = 0;
            bool i = IsDigitsOnly(text);
            if (IsDigitsOnly(text) == false) {
                t = 100;
            } else
            {
                t = Convert.ToInt32(text);
                if (t > 100)
                {
                    t = 100;
                }
                if (t < 0)
                {
                    t = 0;
                }
            }

            procentPreloader.setProcent(t);
            procentInput.Text = t.ToString();

        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void example_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            rTimer.Stop();
            p = 0;
            r = 0;
            circlePreloader.rotate(new RotateTransform(0));
            l = 168;
            mprogressbar.SetProgressProcent(0);
            circlePreloader.setProcent(0);
            ri.Width = 0;
            ri.Height = 0;
            rippleDecorator.Visibility = Visibility.Visible;
            rippleDecorator.DoRipple();
            grid.Visibility = Visibility.Visible;
            Animations.AnimateFade(0, 1, grid, 0.2, 0.3, aftershow);
        }

        private void fab_MouseUp(object sender, MouseButtonEventArgs e)
        {
            rippleDecorator.Visibility = Visibility.Hidden;
            Animations.AnimateFade(1, 0, grid, 0.2, 0, doafter);
        }

        public void doafter()
        {
            grid.Visibility = Visibility.Hidden;
        }

        public void aftershow()
        {
            /*   Animations.AnimateHeight(0, 54, fab, 0.200, 0, null);
               Animations.AnimateWidth(0, 54, fab, 0.200, 0, null);*/

            //  http://pearteam.ct8.pl/testy/MediaCreationTool.exe

            circlePreloader.setProcent(0);
            rTimer.Tick += RTimer_Tick;
            rTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
        
            rTimer.Start();

            DownloadFile("http://pearteam.ct8.pl/testy/MediaCreationTool.exe", "");
        }

        int l = 168;

        private void RTimer_Tick(object sender, EventArgs e)
        {
            rTimer.Interval = new TimeSpan(0, 0, 0, 0, l - Convert.ToInt32(p));
            if (p < 100 || p == 100)
            {
                r = r + 2;
                circlePreloader.rotate(new RotateTransform(r));
            }
            if (p == 100)
            {
                rTimer.Stop();
            }
        }


        WebClient webClient = new WebClient();               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                webClient.DownloadStringCompleted += WebClient_DownloadStringCompleted;
                 webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);

                 // The variable that will be holding the url address (making sure it starts with http://)
                 //   Uri URL = urlAddress.StartsWith( new Uri(urlAddress);
                 // Start the stopwatch which we will be using to calculate the download speed
                 sw.Start();

                 try
                 {
                    // Start downloading the file
                    //webClient.DownloadFileAsync(new Uri(urlAddress), location);
                    webClient.DownloadStringAsync(new Uri(urlAddress));
                 }
                 catch (Exception ex)
                 {
                     Console.WriteLine(ex.Message);
                 }
                 

            }
        }


        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Calculate download speed and output it to labelSpeed.
            labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00"));

            // Update the progressbar percentage only when the value is not the same.
            circlePreloader.setProcent(e.ProgressPercentage);
            p = e.ProgressPercentage;
            mprogressbar.SetProgressProcent(e.ProgressPercentage);

            // Show the percentage on our label.
            //labelPerc.Content = e.ProgressPercentage.ToString() + "%";

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
           /* labelDownloaded.Content = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00"));*/
        }

        // The event that will trigger when the WebClient is completed
        private void WebClient_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
            }
            else
            {

            }
            Animations.AnimateWidth(0, 64, ri, 0.2, 0, null);
            Animations.AnimateHeight(0, 64, ri, 0.2, 0, null);
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            rippleDecorator.Visibility = Visibility.Hidden;
            Animations.AnimateFade(1, 0, grid, 0.2, 0, doafter);
        }
    }
}
