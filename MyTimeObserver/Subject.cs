using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTimeObserver
{
    public abstract class Subject
    {
        private List<IObserver> observers = new List<IObserver>();
        public void Attach(IObserver observer) => observers.Add(observer);
        public void Detach(IObserver observer) => observers.Remove(observer);
        public void Notify() => observers.ForEach(o => o.Update());
    }
}
