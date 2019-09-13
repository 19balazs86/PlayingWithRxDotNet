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
      CancellationTokenSource cts = new CancellationTokenSource();

      Example_1.DoItAsync(cts.Token);
      Example_2.DoItAsync(cts.Token);
      Example_3.DoItAsync(cts.Token);
      Example_4.DoItAsync(cts.Token);
      Example_5.DoItAsync(cts.Token);
      Example_6.DoItAsync(cts.Token);

      Console.WriteLine("Press any key to stop.");
      Console.ReadKey(true);

      cts.Cancel();

      Console.WriteLine("Press any key to exit.");
      Console.ReadKey(true);
    }
  }
}
