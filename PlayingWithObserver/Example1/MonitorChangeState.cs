namespace Example1.PlayingWithObserver
{
  public class MonitorChangeState
  {
    public string ChangeType { get; set; }
    public string FileName { get; set; }

    public override string ToString()
    {
      return $"{ChangeType}: {FileName}";
    }
  }
}
