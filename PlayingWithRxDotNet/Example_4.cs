using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading;
using System.Threading.Tasks;
using PlayingWithRxDotNet.Example3;

namespace PlayingWithRxDotNet
{
  public class Example_4
  {
    private static readonly Random _random = new Random();

    public static async Task DoItAsync(CancellationToken cancellationToken)
    {
      Subject<Temperature> subject = new Subject<Temperature>();

      //subject.Subscribe(temp => Console.WriteLine($"Token-Reporter says the temperature is: {temp}."), cancellationToken);

      using (subject.Subscribe(new TemperatureReporter("Subject-Reporter #1")))
      using (subject.Subscribe(temp => Console.WriteLine($"Anonymous-Reporter says the temperature is: {temp}.")))
      using (subject.Where(t => t.Temp < 0).Select(t => t.Temp).Subscribe(temp => Console.WriteLine($"Filtered-Reporter says the temperature is: {temp}.")))
      {
        for (int i = 0; i < 5; i++)
        {
          await Task.Delay(_random.Next(500, 2000), cancellationToken);
          subject.OnNext(Temperature.GetRandom());
        }
      }

      // No reported temperature
      subject.OnNext(Temperature.GetRandom());
    }
  }
}
