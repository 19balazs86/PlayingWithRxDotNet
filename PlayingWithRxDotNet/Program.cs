using System;
using System.Threading;
using PlayingWithRxDotNet.Example1;
using PlayingWithRxDotNet.Example3;

namespace PlayingWithRxDotNet
{
  public class Program
  {
    public static void Main(string[] args)
    {
      using (var cts = new CancellationTokenSource())
      {
        _ = Example_1.DoItAsync(cts.Token);
        _ = Example_2.DoItAsync(cts.Token);
        _ = Example_3.DoItAsync(cts.Token);
        _ = Example_4.DoItAsync(cts.Token);
        _ = Example_5.DoItAsync(cts.Token);
        _ = Example_6.DoItAsync(cts.Token);

        Console.WriteLine("Press any key to stop.");
        Console.ReadKey(true);

        cts.Cancel();
      }

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey(true);
    }
  }
}
