using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeObserver
{
    public class ClockSubject : Subject
    {
        private string? time;
        public string Time
        {
            get => time ?? "** unknown **";
            set{
                time = value;
                Notify();
            }
        }
    }
}
