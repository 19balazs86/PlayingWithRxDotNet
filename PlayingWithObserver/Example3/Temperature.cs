using System;

namespace PlayingWithObserver.Example3
{
  public class Temperature
  {
    public int Temp { get; set; }
    public DateTime Date { get; set; }

    public override string ToString()
    {
      return $"Temp: {Temp}, Date: {Date}";
    }
  }
}
