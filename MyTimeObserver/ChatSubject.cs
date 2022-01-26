using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public class ChatSubject : Subject
    {
        public string Name { get; set; }
        internal void NewMessage(string name, string text)
        {
            Notify(name, text);
        }
        internal void ClientAttached(string name)
        {
            Notify(name, "has logged in");
        }
        internal void ClientDetached(string name)
        {
            Notify(name, "has logged off");
        }
    }
}
