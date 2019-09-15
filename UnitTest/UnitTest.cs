using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Reactive.Testing;
using Moq;
using PlayingWithRxDotNet.Example2;
using Xunit;

namespace UnitTest
{
  public class UnitTest
  {
    [Fact]
    public void Test_Example_2()
    {
      var testScheduler = new TestScheduler();

      var healthCheckMock = new Mock<IHealthCheck>(MockBehavior.Strict);

      healthCheckMock
        .Setup(x => x.HealthCheckAsync())
        .Returns(Task.FromResult("Healthy"))
        .Verifiable();

      var sut = new Example_2(healthCheckMock.Object, CancellationToken.None, testScheduler);

      testScheduler.AdvanceBy(TimeSpan.FromSeconds(1).Ticks);

      healthCheckMock.Verify(x => x.HealthCheckAsync(), Times.Once);
    }
  }
}
