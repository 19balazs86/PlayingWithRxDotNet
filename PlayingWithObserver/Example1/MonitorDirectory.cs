using System;
using System.IO;
using System.Reactive.Linq;

namespace PlayingWithObserver.Example1
{
  public class MonitorDirectory : IDisposable
  {
    public string Path { get; private set; }
    public IObservable<MonitorChangeState> ChangeObservable { get; private set; }

    private readonly FileSystemWatcher _watcher;

    public MonitorDirectory(string path)
    {
      Path = path;

      // --> Init: FileSystemWatcher
      _watcher = new FileSystemWatcher
      {
        Path                = Path,
        Filter              = "*.*",
        EnableRaisingEvents = true
      };

      // --> Init: Observable
      ChangeObservable = Observable.FromEvent<FileSystemEventHandler, FileSystemEventArgs>(
          // Event handler conversion
          conversionAction =>
          {
            FileSystemEventHandler eHandler = (sender, e) => { conversionAction(e); };

            return eHandler;
          },
          // Add handler
          handler =>
          {
            _watcher.Created += handler;
            _watcher.Deleted += handler;
          },
          // Remove handler
          handler =>
          {
            _watcher.Created -= handler;
            _watcher.Deleted -= handler;
          })
        .Select(e => new MonitorChangeState { ChangeType = e.ChangeType.ToString(), FileName = e.FullPath });
    }

    public void Dispose()
    {
      _watcher.Dispose();
    }
  }
}
