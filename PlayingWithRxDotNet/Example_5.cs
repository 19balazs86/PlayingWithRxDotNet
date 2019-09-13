using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRxDotNet
{
  public class Example_5
  {
    private static int _retryCounter = 0;

    private static Random _random = new Random();

    public static async Task DoItAsync(CancellationToken cancelToken)
    {
      // Polly: Resilience and transient-fault-handling library
      // https://github.com/App-vNext/Polly

      string result = await Observable.FromAsync(() => doSomethingAsync(cancelToken))
        .Timeout(TimeSpan.FromMilliseconds(300)) // Timeout for 1 round.
        .Retry(3)
        //.Timeout(TimeSpan.FromMilliseconds(1500)) // Timeout with retry.
        .Do(x => Console.WriteLine($"Do: {x}")) // Do something if Ok.
        .Select(x => $"Use select: {x}") // Select if Ok.
        .Catch<string, FormatException>(ex =>
        {
          Console.WriteLine(ex);
          return Observable.Return("#FormatException");
        })
        .Catch<string, TimeoutException>(ex => Observable.Return("#TimeoutException"))
        .Catch<string, Exception>(ex => Observable.Return("#Exception"))
        .ToTask();

      // You can not reach this part, if you do not have Catch.

      Console.WriteLine($"Result: {result}");
    }

    private static async Task<string> doSomethingAsync(CancellationToken cancelToken)
    {
      Console.WriteLine($"RoundCounter: {++_retryCounter}");

      await Task.Delay(_random.Next(100, 500), cancelToken);

      if (_random.NextDouble() <= 0.7)
        throw new FormatException("Just an exception");

      return "Ok";
    }
  }
}
