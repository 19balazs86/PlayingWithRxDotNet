using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRxDotNet
{
  public static class Example_2
  {
    public static async Task DoItAsync(CancellationToken cancellationToken)
    {
      // Every 3 seconds
      IObservable<long> observable = Observable.Timer(new DateTimeOffset(), TimeSpan.FromSeconds(3));

      await observable.ForEachAsync(i => Console.WriteLine(i), cancellationToken);
    }
  }
}
