using System;

namespace PlayingWithRxDotNet.Example3
{
  public class TemperatureReporter : IObserver<Temperature>
  {
    public string Name { get; private set; }

    private IDisposable _unsubscriber;
    private Temperature _temperature;

    public TemperatureReporter(IObservable<Temperature> provider, string name)
    {
      Name = name;

      _unsubscriber = provider.Subscribe(this);
    }

    public TemperatureReporter(string name)
    {
      Name = name;
    }

    public void OnNext(Temperature temperature)
    {
      _temperature = temperature;

      Console.WriteLine($"{Name} says the temperature is: {temperature}.");
    }

    public void OnCompleted()
    {
      Console.WriteLine($"{Name} is completed.");
      _unsubscriber.Dispose();
    }

    public void OnError(Exception error)
    {
      throw new NotImplementedException();
    }
  }
}
