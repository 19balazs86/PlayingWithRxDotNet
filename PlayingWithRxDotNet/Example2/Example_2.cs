using System;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PlayingWithRxDotNet.Example2
{
  public class Example_2
  {
    private readonly IHealthCheck _healthCheck;

    public Example_2(
      IHealthCheck healthCheck,
      CancellationToken cancellationToken = default,
      IScheduler scheduler = null)
    {
      _healthCheck = healthCheck;

      IScheduler timerScheduler = scheduler ?? Scheduler.Default;

      Observable
        .Interval(TimeSpan.FromSeconds(1), timerScheduler)
        .Select(_ => Observable.FromAsync(doItAsync))
        .Concat()
        .Subscribe(cancellationToken); // Subscribe return with IDisposable without cancellationToken.

      // Every 3 seconds
      //IObservable<long> observable = Observable.Timer(new DateTimeOffset(), TimeSpan.FromSeconds(3));
      //await observable.ForEachAsync(i => Console.WriteLine(i), cancellationToken);
    }

    public static Example_2 Create(
      IHealthCheck healthCheck,
      CancellationToken cancellationToken = default,
      IScheduler scheduler = null) => new Example_2(healthCheck, cancellationToken, scheduler);

    private Task doItAsync() => _healthCheck.HealthCheckAsync();
  }
}
