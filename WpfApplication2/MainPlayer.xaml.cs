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
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using WpfApplication2;
using TMDbLib.Client;
using TMDbLib.Objects.Movies;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace Meta.Vlc.Wpf.Sample
{
    public partial class MainWindow : Window
    {
        WpfApplication2.EditWindow editWindow;
        WpfApplication2.Window1 searchWindow;
        Boolean mouseMove = true;
        //public Boolean inAnEdit = false;//,mute,skip = false;
        public bool editStateChanged = false;
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

            editWindow = new WpfApplication2.EditWindow();
            searchWindow = new WpfApplication2.Window1();

            ////
            TMDbClient client = new TMDbClient("2b8c6c988082f2afded86703adeccbc8");
            SearchContainer<SearchMovie> results = client.SearchMovieAsync("007").Result;

            Console.WriteLine($"Got {results.Results.Count:N0} of {results.TotalResults:N0} results");
            foreach (SearchMovie result in results.Results)
                Console.WriteLine(result.Title);

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
            Application.Current.Shutdown();
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
            Player.Pause();
            Player.Time = new TimeSpan();
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
            if (WindowStyle != WindowStyle.None)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                this.Topmost = true;
                this.ResizeMode = ResizeMode.NoResize;
                //Player.AspectRatio = AspectRatio._16_9;

            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                //Player.AspectRatio = AspectRatio._16_9;

            }
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
                //System.Windows.Input.Mouse.OverrideCursor = System.Windows.Input.Cursors.None;
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
            //ccLabel.FontWeight =FontWeights.UltraBlack;
           // ClosedCaptioning.Content = " CC ";
            
        }
        private void handleEdit(Boolean activate)
        {
            if (activate)
            {
                if (editWindow.inEdit.mute)
                {
                    if (!Player.IsMute)
                        Player.ToggleMute();
                }
                else if (editWindow.inEdit.skip)
                {
                    Player.Time = editWindow.inEdit.end();
                }
                else if (editWindow.inEdit.blockVideo)
                {
                    Player.Opacity = 0;
                }
            }
            else
            {
                if (Player.IsMute)
                    Player.ToggleMute();
                if (Player.Opacity == 0)
                    Player.Opacity = 1;
            }
        }
        public void setTime(TimeSpan inTime)
        {
            Player.Time = inTime;
        }

        private void Player_TimeChanged(object sender, EventArgs e)
        {
            if (editWindow != null) { 
                editWindow.currentPlayerTime = Player.VlcMediaPlayer.Time;
                editWindow.update();
            }
            else 
                return;
            if (editWindow.inEdit != null)
            {
                handleEdit(true);
            }
            else
                handleEdit(false);

        }
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (editWindow.IsVisible)
                editWindow.Hide();
            else
                editWindow.Show();
        }

        //Save Edits!
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            sfd.Filter = "text file|*.txt";
            sfd.Title = "Save your filters";



            if (sfd.ShowDialog() == true)
            {

                Stream stream = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(editWindow.getList().GetType());
                x.Serialize(stream, editWindow.getList());
                stream.Close();
            }//if
        }//menuItemClick

        //load edits!
        private void clearEdit_Click(object sender, RoutedEventArgs e)
        {
            editWindow.editList.Clear();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "(*.txt)| *.txt";
            ofd.Title = "load your filters";
            if (ofd.ShowDialog() == true)
            {
                XmlSerializer mySerializer = new XmlSerializer(typeof(ObservableCollection<Edit>));
                FileStream myFileStream = new FileStream(ofd.FileName, FileMode.Open);
                foreach (Edit curEdit in (ObservableCollection<Edit>)mySerializer.Deserialize(myFileStream))
                    editWindow.editList.Add(curEdit);
                //editWindow.editList.add += (ObservableCollection<Edit>)mySerializer.Deserialize(myFileStream);

            }
            else
            {

            }
        }

        //DVD URL
        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            
        }

        private void speed_1_0_Click(object sender, RoutedEventArgs e)
        {
            if (sender == speed_0_75)
                Player.Rate = 0.75f;
            else if (sender == speed_1_0)
                Player.Rate = 1f;
            else if (sender == speed_1_25)
                Player.Rate = 1.25f;
            else if (sender == speed_1_5)
                Player.Rate = 1.5f;
            else if (sender == speed_2_0)
                Player.Rate = 2f;
        }

        private void searchForEditsClick(object sender, RoutedEventArgs e)
        {
            if (searchWindow.IsVisible)
                searchWindow.Hide();
            else
                searchWindow.Show();
        }
    }
}
