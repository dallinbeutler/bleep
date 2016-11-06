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
    public partial class EditWindow : Window
    {
        public ObservableCollection<Edit>  editList = new ObservableCollection<Edit>();
        //List<Edit> editList = new List<Edit>();
        public TimeSpan currentPlayerTime = new TimeSpan();
        public TimeSpan startTime = new TimeSpan();

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

        private void butSound_Click(object sender, RoutedEventArgs e)
        {
            editList.Add(new WpfApplication2.Edit(startTime, currentPlayerTime,true,false,false));
            Console.WriteLine("added");
            
            //listView.
            //listView.DataContext = editList;
            //listView.
        }
        public void update()
        {
            totalTimeLabel.Content = (currentPlayerTime - startTime).Seconds;
            
            foreach (Edit curEdit in editList)
            {
                if(currentPlayerTime > curEdit.sTime && currentPlayerTime < curEdit.eTime)
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

        private void butSkip_Click(object sender, RoutedEventArgs e)
        {
            editList.Add(new WpfApplication2.Edit(startTime, currentPlayerTime, false, true, false));
            Console.WriteLine("skip added");
        }

        private void butVideo_Click(object sender, RoutedEventArgs e)
        {
            editList.Add(new WpfApplication2.Edit(startTime, currentPlayerTime, false, false, true));
            Console.WriteLine("block video added");
        }
    }
}
