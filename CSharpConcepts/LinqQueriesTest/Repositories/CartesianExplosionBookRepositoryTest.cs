using LinqQueriesConsole.Repositories;
using System.Diagnostics;

namespace LinqQueriesTest.Repositories
{
    public class CartesianExplosionBookRepositoryTest
    {
        [Fact]
        public async Task GivenIncludeAndSelectWhenBothPerformSimilarQueryThenSelectIsFaster()
        {
            //Arrange
            var stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            _ = await CartesianExplosionBookRepository.GetEagerAllAdultBookWithCartesianExplosionAsync();
            stopwatch.Stop();
            var eagerTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            _ = await CartesianExplosionBookRepository.GetEagerAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var selectTime = stopwatch.ElapsedMilliseconds;

            // Try a second time with cartesian explosion
            stopwatch.Start();
            _ = await CartesianExplosionBookRepository.GetEagerAllAdultBookWithCartesianExplosionAsync();
            stopwatch.Stop();
            var secondEagerTime = stopwatch.ElapsedMilliseconds;

            // Assert
            Assert.True(eagerTime > selectTime,
                $"Select method is faster: {selectTime}ms vs {secondEagerTime}ms");
        }
    }
}