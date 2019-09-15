using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRxDotNet.Example3
{
  public static class Example_3
  {
    private static readonly Random _random = new Random();

    public static async Task DoItAsync(CancellationToken cancellationToken)
    {
      TemperatureMonitor provider = new TemperatureMonitor();

      new TemperatureReporter(provider, "Reporter #1");
      new TemperatureReporter(provider, "Reporter #2");

      for (int i = 0; i < 5; i++)
      {
        try
        {
          await Task.Delay(_random.Next(500, 2000), cancellationToken);
          provider.ChangeTemp(_random.Next(-10, 30));
        }
        catch (OperationCanceledException)
        {
          break;
        }
      }

      provider.Completed();

      // No reported temperature
      provider.ChangeTemp(0);
    }
  }
}
