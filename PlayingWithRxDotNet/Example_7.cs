using System.Reactive.Linq;
using System.Runtime.CompilerServices;

namespace PlayingWithRxDotNet
{
    public class Example_7
    {
        // IAsyncEnumerable feature that no one is using
        // 11 min: https://youtu.be/qTetsXmZLk0
        public static async Task DoItAsync(CancellationToken cancelToken)
        {
            // Example #1 | Normal usage
            //await foreach (int number in giveMeRandomNumbers(cancelToken))
            //{
            //    if (predicateEvenNumber(number))
            //        printTheNumber(number);
            //}

            // Example #2 | With Observable and Subscribe
            giveMeRandomNumbers(cancelToken)
                .ToObservable()
                .Where(predicateEvenNumber)
                .Subscribe(printTheNumber, cancelToken);

            //Example #4 | With Observable and ForEachAsync
            //await giveMeRandomNumbers(cancelToken)
            //    .ToObservable()
            //    .Where(predicateEvenNumber)
            //    .ForEachAsync(printTheNumber, cancelToken);

            // Example #5 | With ToListAsync. This way only prints the number when giveMeRandomNumbers method finished
            //List<int> evenNumbers = await giveMeRandomNumbers(cancelToken, true)
            //    .Where(predicateEvenNumber)
            //    .ToListAsync(cancelToken);

            //evenNumbers.ForEach(printTheNumber);
        }

        private static async IAsyncEnumerable<int> giveMeRandomNumbers(
            [EnumeratorCancellation] CancellationToken ct,
            bool allowYieldBreak = false)
        {
            while (!ct.IsCancellationRequested)
            {
                if (allowYieldBreak && Random.Shared.Next(0, 100) <= 10) yield break;

                //Console.WriteLine("giveMeRandomNumbers");

                await Task.Delay(500, ct);

                yield return Random.Shared.Next();
            }
        }

        private static bool predicateEvenNumber(int number) => number % 2 == 0;

        private static void printTheNumber(int evenNumber)
            => Console.WriteLine("Even number: {0}", evenNumber);
    }
}
