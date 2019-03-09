# Playing with Observer Design Pattern, Rx.NET

This small application is a silly example for the [Observer Design Pattern in .NET](https://docs.microsoft.com/en-us/dotnet/standard/events/observer-design-pattern "Observer Design Pattern in .NET") using the [Reactive Extension - Rx.NET](https://github.com/dotnet/reactive "Reactive Extension - Rx.NET").

- Maybe, the [ReactiveX](http://reactivex.io "ReactiveX") concept is not the most popular framework in the .NET, unlike the Front-end side with RxJS.
- You can find some simple use cases in this project, just to give you some hint.

#### Resources

- YouTube presentation: Using Redux pattern with ASP.NET Core + SignalR: [Link](https://www.youtube.com/watch?v=jE65d8b3w_M "Link") | [GitHub - RxDemo](https://github.com/brendan-ssw/rxdemo "GitHub - RxDemo").
- Book: [Rx.NET in Action](https://www.manning.com/books/rx-dot-net-in-action "Rx.NET in Action book").

#### TPL Dataflow
- I used the BufferBlock ([System.Threading.Tasks.Dataflow](https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.dataflow?view=netcore-2.2 "System.Threading.Tasks.Dataflow")) in the [example #6](https://github.com/19balazs86/PlayingWithObserver/blob/master/PlayingWithObserver/Example_6.cs "example #6").
- I want to point out this topic is far bigger than in my example.

##### Resources for TPL Dataflow
- [Microsoft doc](https://docs.microsoft.com/en-us/dotnet/standard/parallel-programming/dataflow-task-parallel-library "Microsoft doc"): Parallel Programming in .NET - TPL Dataflow (Task Parallel Library).
- Some blog posts from Hamid Mosalla with [TPL Dataflow tag](http://hamidmosalla.com/tag/tpl-dataflow "TPL Dataflow tag").
- Some blog posts from Jack Vanlightly: [Processing Pipelines Series](https://jack-vanlightly.com/blog/2018/4/17/processing-pipelines-series-introduction "Processing Pipelines Series").