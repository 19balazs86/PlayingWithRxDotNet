using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithObserver.Example1
{
  public class Example_1
  {
    public static async Task DoItAsync(CancellationToken cancellationToken)
    {
      using (MonitorDirectory monitor = new MonitorDirectory("monitor"))
      {
        Task task = monitor.ChangeObservable.ForEachAsync(
          async (MonitorChangeState state) =>
          {
            await processChangeStateAsync(state);
          }, cancellationToken);

        await task;
      }
    }

    private static async Task processChangeStateAsync(MonitorChangeState state)
    {
      await Task.Run(() => Console.WriteLine(state));
    }
  }
}
