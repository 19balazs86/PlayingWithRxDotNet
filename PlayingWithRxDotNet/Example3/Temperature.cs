using System;

namespace PlayingWithRxDotNet.Example3
{
  public class Temperature
  {
    private static readonly Random _random = new Random();

    public int Temp { get; set; }
    public DateTime Date { get; set; }

    public static Temperature GetRandom() =>
      new Temperature { Temp = _random.Next(-10, 30), Date = DateTime.Now };

    public override string ToString() => $"Temp: {Temp}, Date: {Date}";
  }
}
