using System;
using System.Threading.Tasks;

namespace PlayingWithRxDotNet.Example2
{
  public interface IHealthCheck
  {
    Task HealthCheckAsync();
  }

  public class DemoHealthCheck : IHealthCheck
  {
    public async Task HealthCheckAsync()
    {
      Console.WriteLine("Call: HealthCheckAsync.");

      await Task.Delay(500);
    }

    public static DemoHealthCheck Create() => new DemoHealthCheck();
  }
}
