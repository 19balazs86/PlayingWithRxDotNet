namespace PlayingWithRxDotNet.Example1
{
  public class MonitorChangeState
  {
    public string ChangeType { get; set; }
    public string FileName { get; set; }

    public override string ToString() => $"{ChangeType}: {FileName}";
  }
}
