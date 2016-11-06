using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    class myViewModel
    {
        private ObservableCollection<Edit> m_Rows;

        public ObservableCollection<Edit> Rows
        {
            get { return m_Rows; }
            set { m_Rows = value; }
        }

        public myViewModel()
        {
            Rows = new ObservableCollection<Edit>();
            Rows.Add(new Edit());

        }
    }
}
