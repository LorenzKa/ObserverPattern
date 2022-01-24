using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public interface IObserver
    {
        public string Clientname { get; }
        public string TopicsOfInterest { get; }
        public void ClientAttached(string name);
        public void ClientDetached(string name);
        public void Update(string name, string msg);
    }
}
