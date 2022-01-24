using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chatter
{
    public abstract class Subject
    {
        private List<IObserver> observers = new();
        public int NrObservers { get; }
        public void Attach(IObserver observer)
        {
            observers.Add(observer);
            observers.ForEach(o => o.ClientAttached(observer.Clientname));
        }
        public void Detach(IObserver observer)
        {
            observers.Remove(observer);
            observers.ForEach(o => o.ClientDetached(observer.Clientname));
        }
        protected void Notify(string name, string msg) => observers.ForEach(o => o.Update(name, msg));
    }
}
