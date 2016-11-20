using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public enum CensorType { Unspecified, Sex, Nudity, Violence_nonGraphic, Violence_Graphic, Minor_Language, Major_Language, Boring, Drugs, Other };


    public class MyEnumToStringConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (CensorType)Enum.Parse(typeof(CensorType), value.ToString(), true);
        }
    }

    public class Edit
    {
        //

        public CensorType  type{ get; set; }
        public long sTime ;
        public long eTime;
        public Boolean mute  { get; set;}
        public Boolean blockVideo { get; set; }
        public Boolean skip { get; set; }
        public Boolean enabled { get; set; }
        public TimeSpan start() { return new TimeSpan(sTime); }
        public TimeSpan end() { return new TimeSpan(eTime); }

        public Edit()
        {

        }

        public Edit(TimeSpan start, TimeSpan end, Boolean mute, Boolean blockVideo, Boolean skip)
        {
            this.sTime = start.Ticks;
            this.eTime = end.Ticks;
            this.mute = mute;
            this.blockVideo = blockVideo;
            this.skip = skip;
            this.enabled = true;
            this.type = CensorType.Unspecified;
            
        }
        public Edit(CensorType inType, TimeSpan start, TimeSpan end, Boolean mute, Boolean blockVideo, Boolean skip)
        {
            this.sTime = start.Ticks;
            this.eTime = end.Ticks;
            this.mute = mute;
            this.blockVideo = blockVideo;
            this.skip = skip;
            this.enabled = true;
            this.type = inType;
        }


        public override string ToString()
        {
            TimeSpan st = new TimeSpan(sTime);
            TimeSpan et = new TimeSpan(eTime);
            // endLabel.Text = "" + t2.Hours.ToString("D2") + ":" + t2.Minutes.ToString("D2") + ":" + t2.Seconds.ToString("D2");
            String s =  st.Hours + ":" + st.Minutes + ":" + st.Seconds + " to ";
            //string s = "" + t1.Hours.ToString("D2") + ":" + t1.Minutes.ToString("D2") + ":" + t1.Seconds.ToString("D2");
            s += et.Hours + ":" + et.Minutes + ":" + et.Seconds +" (" + (et - st).Seconds + " seconds)   -";
            //s += " - " + t2.Hours.ToString("D2") + ":" + t2.Minutes.ToString("D2") + ":" + t2.Seconds.ToString("D2");

            if (this.mute)
                s += "sound";
            if (this.blockVideo)
                s += "video";
            if (this.skip)
                s += "skip";

            s += "|";
            
            //return ">" + TimeSpan.FromMilliseconds(getStart()).Hours +":" +TimeSpan.FromMilliseconds(getStart()).Minutes + ":" + TimeSpan.FromMilliseconds(getStart()).Seconds + "-" + TimeSpan.FromMilliseconds(getEnd()) + " mute";
            return s;
        }


    }
}
