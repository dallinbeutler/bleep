using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication2
{
    public class Edit
    {
        enum CensorType { Unspecified, Nudity, Violence, Language, Other };
        public TimeSpan sTime { get; set;}
        public TimeSpan eTime { get; set; }
        public Boolean mute  { get; set;}
    public Boolean blockVideo { get; set; }
        public Boolean skip { get; set; }

        

        public Edit()
        {

        }

        public Edit(TimeSpan start, TimeSpan end, Boolean mute, Boolean blockVideo, Boolean skip)
        {
            this.sTime = start;
            this.eTime = end;
            this.mute = mute;
            this.blockVideo = blockVideo;
            this.skip = skip;
        }


        public override string ToString()
        {
            // endLabel.Text = "" + t2.Hours.ToString("D2") + ":" + t2.Minutes.ToString("D2") + ":" + t2.Seconds.ToString("D2");
            String s =  sTime.Hours + ":" + sTime.Minutes + ":" + sTime.Seconds + " to ";
            //string s = "" + t1.Hours.ToString("D2") + ":" + t1.Minutes.ToString("D2") + ":" + t1.Seconds.ToString("D2");
            s += eTime.Hours + ":" + eTime.Minutes + ":" + eTime.Seconds +" (" + (eTime - sTime).Seconds + " seconds)   -";
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
