using LinqQueriesConsole.Repositories;
using System.ComponentModel;
using System.Diagnostics;

namespace LinqQueriesTest.Repositories
{
    public class CollectionSizeBookRespositoryTest
    {
        [Fact, Description(
            "Interogate 2 times for both cases, array is faster because it has a fixed size.")]
        public async Task GivenListAndArrayWhenResultIsTheSameThenArrayIsFaster()
        {
            //Arrange
            var stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            _ = await CollectionSizeBookRespository.GetEagerListAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerListFirstQuery = stopwatch.ElapsedMilliseconds;

            stopwatch.Start();
            _ = await CollectionSizeBookRespository.GetEagerListAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerListSecondQuery = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            _ = await CollectionSizeBookRespository.GetEagerArrayAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerArrayFirstQuery = stopwatch.ElapsedMilliseconds;
            
            stopwatch.Restart();
            _ = await CollectionSizeBookRespository.GetEagerArrayAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerArraySecondQuery = stopwatch.ElapsedMilliseconds;

            // Assert
            Assert.True(eagerListSecondQuery > eagerArraySecondQuery && eagerListFirstQuery > eagerArrayFirstQuery,
                $"Select method is faster: {eagerListSecondQuery}ms vs {eagerArraySecondQuery}ms");
        }

        [Fact, Description("Interogate 2 times for both cases.")]
        public async Task GivenListAndIEnumerableWhenResultIsTheSameThenArrayIsFaster()
        {
            //Arrange
            var stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            _ = await CollectionSizeBookRespository.GetEagerListAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerListFirstQuery = stopwatch.ElapsedMilliseconds;

            stopwatch.Start();
            _ = await CollectionSizeBookRespository.GetEagerListAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerListSecondQuery = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            _ = await CollectionSizeBookRespository.GetEagerIEnumerableAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerIEnumerableFirstQuery = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            _ = await CollectionSizeBookRespository.GetEagerIEnumerableAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var eagerIEnumerableSecondQuery = stopwatch.ElapsedMilliseconds;

            // Assert
            Assert.True(eagerListSecondQuery > eagerIEnumerableSecondQuery && eagerListFirstQuery > eagerIEnumerableFirstQuery,
                $"Select method is faster: {eagerListSecondQuery}ms vs {eagerIEnumerableSecondQuery}ms");
        }
    }
}
