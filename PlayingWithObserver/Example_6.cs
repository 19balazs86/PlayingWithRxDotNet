using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using PlayingWithObserver.Example3;

namespace PlayingWithObserver
{
  public class Example_6
  {
    private static Random _random = new Random();

    public static async Task DoItAsync(CancellationToken cancelToken)
    {
      // https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow
      BufferBlock<Temperature> queue = new BufferBlock<Temperature>();

      IObservable<Temperature> observable = queue.AsObservable();
      IObserver<Temperature> observer     = queue.AsObserver();

      using (observable.Subscribe(new TemperatureReporter("BufferBlock-Reporter")))
      {
        for (int i = 0; i < 5; i++)
        {
          await Task.Delay(_random.Next(500, 2000), cancelToken);
          observer.OnNext(Temperature.GetRandom());
        }
      }
    }
  }
}
