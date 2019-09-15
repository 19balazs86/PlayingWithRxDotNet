using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace PlayingWithRxDotNet.Example1
{
  public static class Example_1
  {
    // You can set the MaxDegreeOfParallelism with an option parameter.
    private static readonly ActionBlock<MonitorChangeState> _actionBlock
      = new ActionBlock<MonitorChangeState>(processChangeStateAsync);

    public static async Task DoItAsync(CancellationToken cancellationToken)
    {
      // ForEachAsync method is not meant to handle async methods.

      //using (MonitorDirectory monitor = new MonitorDirectory("monitor"))
      //{
      //  await monitor.ChangeObservable.ForEachAsync(
      //    async (MonitorChangeState state) => await processChangeStateAsync(state), cancellationToken);
      //}

      using (MonitorDirectory monitor = new MonitorDirectory("monitor"))
      {
        try
        {
          await monitor.ChangeObservable.ForEachAsync(x => _actionBlock.Post(x), cancellationToken);
        }
        catch (OperationCanceledException) { }
      }

      _actionBlock.Complete();

      await _actionBlock.Completion;
    }

    private static Task processChangeStateAsync(MonitorChangeState state)
    {
      Console.WriteLine(state);

      return Task.CompletedTask;
    }
  }
}
