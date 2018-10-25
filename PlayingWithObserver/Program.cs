using System;
using System.Threading;
using Example1.PlayingWithObserver;
using PlayingWithObserver.Example3;

namespace PlayingWithObserver
{
  // Observer Design Pattern
  // https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern

  // Github: Reactive Extensions for .NET
  // https://github.com/dotnet/reactive
  class Program
  {
    static void Main(string[] args)
    {
      CancellationTokenSource cts = new CancellationTokenSource();

      Example_1.DoItAsync(cts.Token);
      Example_2.DoItAsync(cts.Token);
      Example_3.DoItAsync(cts.Token);
      Example_4.DoItAsync(cts.Token);

      Console.WriteLine("Press any key to stop.");
      Console.ReadKey();

      cts.Cancel();

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }
  }
}
