using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public class ChatSubject : Subject
    {
        

        internal void NewMessage(string name, string text)
        {
            Notify(name, text);
        }
        internal void ClientAttached(string name)
        {
            ClientAttached(name);
        }
        internal void ClientDetached(string name)
        {
            ClientDetached(name);
        }
    }
}
