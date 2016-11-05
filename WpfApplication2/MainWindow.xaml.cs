// Project: Meta.Vlc (https://github.com/higankanshi/Meta.Vlc)
// Filename: MainWindow.xaml.cs
// Version: 20160404

using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;


namespace Meta.Vlc.Wpf.Sample
{
    public partial class MainWindow : Window
    {
        Boolean mouseMove = true;
        //VlcPlayer Player = null; //uncomment if adding the player dynamically or use other control to render video

        #region --- Initialization ---

        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Media.Color c = new System.Windows.Media.Color();
            c.ScR = 0;
            c.ScG = 0;
            c.ScB = 0;
            c.ScA = 255;
            this.Background = new System.Windows.Media.SolidColorBrush(c);

            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


            //uncomment if adding the player dynamically

            //Player = new VlcPlayer();
            //Player.SetValue(Canvas.ZIndexProperty, -1);
            //LayoutParent.Children.Add(Player);


            //uncomment if you use Image or ThreadSeparatedImage to render video
            /*
            Player.Initialize(@"..\..\libvlc", new string[] { "-I", "dummy", "--ignore-config", "--no-video-title" });
            Player.VideoSourceChanged += PlayerOnVideoSourceChanged;
            */
        }

        //uncomment if you use Image or ThreadSeparatedImage to render video
        /*
        private void PlayerOnVideoSourceChanged(object sender, VideoSourceChangedEventArgs videoSourceChangedEventArgs)
        {
            DisplayImage.Dispatcher.BeginInvoke(new Action(() =>
            {
                DisplayImage.Source = videoSourceChangedEventArgs.NewVideoSource;
            }));
        }
        */

        #endregion --- Initialization ---

        #region --- Cleanup ---

        protected override void OnClosing(CancelEventArgs e)
        {
            Player.Dispose();
            ApiManager.ReleaseAll();
            base.OnClosing(e);
        }

        #endregion --- Cleanup ---

        #region --- Events ---

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            var openfiles = new OpenFileDialog();
            if (openfiles.ShowDialog() == true)
            {
                Player.RebuildPlayer();
                Player.Stop();
                Player.LoadMedia(openfiles.FileName);
                Player.Play();
                
                this.Title = "BLEEP! - " + openfiles.FileName;

            }
            return;

            String pathString = "";//path.Text;

            Uri uri = null;
            if (!Uri.TryCreate(pathString, UriKind.Absolute, out uri)) return;

            Player.Stop();
            Player.LoadMedia(uri);
            //if you pass a string instead of a Uri, LoadMedia will see if it is an absolute Uri, else will treat it as a file path
            Player.Play();
        }

        private void LoadDVD_Click(object sender, RoutedEventArgs e)
        {
            
            Player.Stop();
            Player.LoadMedia(new Uri("dvd:///" + "E:/"));
            Player.UpdateLayout();
           
            Player.Play();

                this.Title = "BLEEP! - " + "E:/";





            /*
            foreach (var drive in DriveInfo.GetDrives())
                if (drive.DriveType == DriveType.CDRom)
                {
                    Player.Stop();
                    Player.RebuildPlayer();
                    //Player.LoadMediaWithOptions(drive.Name, new string[] { });
                    // Player.LoadMedia(("dvd:///" + drive.Name));
                    //Player.LoadMedia(new Uri("dvd:///" + drive.Name));
                    Player.LoadMedia(@drive.Name);
                    //Player.LoadMedia(new Uri("dvd:///" + drive.Name));
                    //Player.LoadMedia(new Uri("https://www.youtube.com/watch?v=uJ_1HMAGb4k&index=48&list=PLYz4hrj6qtiM3Anudf1g7VeFRTAuEYamN"));
                    //Player.VlcMediaPlayer.Media = Player.Vlc.CreateMediaFromPath("dvd:///E:\\");
                    //Player.LoadMedia(new Uri(drive.Name));
                    //System.Diagnostics.Debug.WriteLine("dvd:///" + drive.Name);
                    Player.Play();


                    //Player.Opacity = 100;
                    return;
                }
                */
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //Thread.Sleep(10000);
            //Player.Play();
            Player.PauseOrResume();
            if (Player.State == Interop.Media.MediaState.Stopped)
                Player.Play();
        }



        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            Player.Stop();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)//fullscreen
        {
            if (WindowStyle != WindowStyle.None)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                //Player.AspectRatio = AspectRatio._16_9;
                
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                //Player.AspectRatio = AspectRatio._16_9;
                
            }
                
            // Close(); //closing the main window will also terminate the application
        }

        private void AspectRatioSet(object sender, RoutedEventArgs e)
        {
            if (sender == RatioDefault)
                Player.AspectRatio = AspectRatio.Default;
            else if (sender == Ratio16by9)
                Player.AspectRatio = AspectRatio._16_9;
            else if (sender == Ratio4by3)
                Player.AspectRatio = AspectRatio._4_3;
            /* if (Player == null) return;
             switch ((sender as String))
             {
                 case "Default":
                     Player.AspectRatio = AspectRatio.Default;
                     break;

                 case "4:3":
                     Player.AspectRatio = AspectRatio._16_9;
                     break;

                 case "16:9":
                     Player.AspectRatio = AspectRatio._4_3;
                     break;
             }
             */
        }

        private void ProgressBar_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var value = (float)(e.GetPosition(ProgressBar).X / ProgressBar.ActualWidth);
            ProgressBar.Value = value;
        }

        #endregion --- Events ---

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //double rate = 2;

            if (Player.Opacity != 0)
                Player.Opacity = 0;


            else
                Player.Opacity = 1;


            //Player.Foreground = new System.Windows.Media.SolidColorBrush(c);
            //Player.Background = new System.Windows.Media.SolidColorBrush(c);

            //this.
        }

        private void Player_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void Window_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (allControls.Opacity != 0)
                allControls.Opacity = 0;
            else
                allControls.Opacity = 1;
        }

        private void Window_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            mouseMove = true;
            System.Windows.Input.Mouse.OverrideCursor = null;
            allControls.Opacity = 1;
        }




private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            if (!mouseMove) { 
                System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.None;
                allControls.Opacity = 0;
            }
            mouseMove = false;
        }

        private void ClosedCaptioning_Click(object sender, RoutedEventArgs e)
        {

            if (Player.VlcMediaPlayer.Subtitle == Player.VlcMediaPlayer.SubtitleCount)
                Player.VlcMediaPlayer.Subtitle = -1;
            else
                Player.VlcMediaPlayer.Subtitle = Player.VlcMediaPlayer.SubtitleCount;
            ccLabel.FontWeight =FontWeights.UltraBlack;
           // ClosedCaptioning.Content = " CC ";
            
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            Window1 wbutts = new Window1;
        }
    }
}
