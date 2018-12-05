using System;
using System.Threading;
using PlayingWithObserver.Example1;
using PlayingWithObserver.Example3;

namespace PlayingWithObserver
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CancellationTokenSource cts = new CancellationTokenSource();

      Example_1.DoItAsync(cts.Token);
      Example_2.DoItAsync(cts.Token);
      Example_3.DoItAsync(cts.Token);
      Example_4.DoItAsync(cts.Token);
      Example_5.DoItAsync(cts.Token);

      Console.WriteLine("Press any key to stop.");
      Console.ReadKey();

      cts.Cancel();

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey();
    }
  }
}
