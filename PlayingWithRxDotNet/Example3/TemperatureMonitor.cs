using System;
using System.Collections.Generic;
using System.Linq;

namespace PlayingWithRxDotNet.Example3
{
  public class TemperatureMonitor : IObservable<Temperature>
  {
    private readonly List<IObserver<Temperature>> _observers;

    public int Temp { get; private set; }

    public TemperatureMonitor()
    {
      _observers = new List<IObserver<Temperature>>();
    }

    public IDisposable Subscribe(IObserver<Temperature> observer)
    {
      if (!_observers.Contains(observer))
        _observers.Add(observer);

      return new Unsubscriber(_observers, observer);
    }

    public void ChangeTemp(int temp)
    {
      Temp = temp;

      // Call observers OnNext
      _observers.ForEach(observer => observer.OnNext(new Temperature { Temp = temp, Date = DateTime.Now }));
    }

    public void Completed()
    {
      // Call observers OnCompleted
      _observers.ToList().ForEach(observer => observer.OnCompleted());
    }

    private class Unsubscriber : IDisposable
    {
      private readonly List<IObserver<Temperature>> _observers;
      private readonly IObserver<Temperature> _observer;

      public Unsubscriber(List<IObserver<Temperature>> observers, IObserver<Temperature> observer)
      {
        _observers = observers;
        _observer  = observer;
      }

      public void Dispose() => _observers?.Remove(_observer);
    }
  }
}
