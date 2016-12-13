using Meta.Vlc.Wpf.Sample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;



namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 




    public partial class EditWindow : Window
    {
        public ObservableCollection<Edit>  editList = new ObservableCollection<Edit>();
        //List<Edit> editList = new List<Edit>();
        public TimeSpan currentPlayerTime = new TimeSpan();
        public TimeSpan startTime = new TimeSpan();
        //public TimeSpan TimeChanged = new TimeSpan (0,0,-1);
        public TimeSpan TimeChanged = new TimeSpan();
        public bool validTimes = false;

        public Edit inEdit = null;
        

        public ObservableCollection<Edit> getList()
        {
            return editList;
        }
        public EditWindow()
        {
            //editList.Add(new Edit());
            InitializeComponent();
            listView.ItemsSource = editList;
            //editList.Add(new Edit(0.1, 10000, true, false, true));
        }
        void BindData()
        {
         
            int selected = listView.SelectedIndex;
            
            /*      ListBox.DataContextProperty();
                  listBox.DataSource = null;
                  listBox.DataSource = edits;
                  //listbox1.DisplayMember = "Name";
                  listBox.SelectedIndex = selected;*/
        }

        private void butMarkStart_Click(object sender, RoutedEventArgs e)
        {
            startTime = currentPlayerTime;

        }


        public void update()
        {
            TimeSpan temp = (currentPlayerTime - startTime);
            totalTimeLabel.Content = temp.Seconds;
            if (temp.Ticks <= 0)
            {
                validTimes = false;
                greenGrid.Background = Brushes.IndianRed;
            }

            else
            {
                validTimes = true;
                greenGrid.Background = Brushes.GreenYellow;
            }


            time_hour.Text = "" + currentPlayerTime.Hours;
            time_min.Text = "" + currentPlayerTime.Minutes;
            time_sec.Text = "" + currentPlayerTime.Seconds;
            time_ms.Text = "" + currentPlayerTime.Milliseconds;


            foreach (Edit curEdit in editList)
            {
                if(curEdit.enabled)
                    if(currentPlayerTime > curEdit.start() && currentPlayerTime < curEdit.end())
                    {
                        inEdit = curEdit;
                        return;
                    }
                    
            }
            inEdit = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void listView_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
        private void butSound_Click(object sender, RoutedEventArgs e)
        {
            if (validTimes)
            {
                editList.Add(new WpfApplication2.Edit((CensorType)comboBox.SelectedItem, startTime, currentPlayerTime, true, false, false));
                Console.WriteLine("added");
            }
            else
                Console.WriteLine("invalid times");

        }
        private void butSkip_Click(object sender, RoutedEventArgs e)
        {
            if (validTimes)
            {
                editList.Add(new WpfApplication2.Edit(startTime, currentPlayerTime, false,false, true));
                Console.WriteLine("skip added");
            }
            else
                Console.WriteLine("invalid times");
        }

        private void butVideo_Click(object sender, RoutedEventArgs e)
        {
            if (validTimes)
            {
                editList.Add(new WpfApplication2.Edit(startTime, currentPlayerTime, false, true, false));
                Console.WriteLine("block video added");
            }
            else
                Console.WriteLine("invalid times");
        }

        private void toggleEdit_Click(object sender, RoutedEventArgs e)
        {
            //((Edit)listView.SelectedItem).enabled = !((Edit)listView.SelectedItem).enabled;
            if(listView.SelectedIndex >= 0 )
            editList[listView.SelectedIndex].enabled = !editList[listView.SelectedIndex].enabled;
        }

        private void time_min_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TimeChanged = new TimeSpan(0, int.Parse(time_hour.Text), int.Parse(time_min.Text), int.Parse(time_sec.Text), int.Parse(time_ms.Text));
                //    MainWindow.setTime();

                var myWin = (MainWindow)Application.Current.MainWindow;
                myWin.Player.Time = TimeChanged;
            }
        }

        private void nudgeback_Click(object sender, RoutedEventArgs e)
        {
            var myWin = (MainWindow)Application.Current.MainWindow;
            // myWin.updateTime(currentPlayerTime.Add(TimeSpan.FromMilliseconds(-200)));
            myWin.Player.Time = myWin.Player.Time.Add(TimeSpan.FromMilliseconds(-200));
            currentPlayerTime = myWin.Player.Time;
            update();
        }

        private void nudgeforward_Click(object sender, RoutedEventArgs e)
        {
            var myWin = (MainWindow)Application.Current.MainWindow;
            myWin.Player.Time = myWin.Player.Time.Add(TimeSpan.FromMilliseconds(200));
            currentPlayerTime = myWin.Player.Time;
            update();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedIndex >= 0)
            editList.RemoveAt(listView.SelectedIndex);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void contextDelete_Click(object sender, RoutedEventArgs e)
        {
            editList.RemoveAt(listView.SelectedIndex);
        }

        private void contextDisable_Click(object sender, RoutedEventArgs e)
        {
            editList[listView.SelectedIndex].enabled = !editList[listView.SelectedIndex].enabled;
            
            //((ListViewItem)listView.SelectedItem).Foreground = Brushes.Beige;
        }
    }
}
