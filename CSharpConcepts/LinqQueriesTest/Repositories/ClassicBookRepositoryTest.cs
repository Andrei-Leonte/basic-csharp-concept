using LinqQueriesConsole.Repositories;
using System.Diagnostics;

namespace LinqQueriesTest.Repositories
{
    public class ClassicBookRepositoryTest
    {
        private readonly ClassicBookRepository classicBookRepository;

        public ClassicBookRepositoryTest()
        {
            classicBookRepository = new ClassicBookRepository();
        }

        [Fact]
        public async Task GivenIncludeAndSelectWhenBothPerformSimilarQueryThenSelectIsFaster()
        {
            //Arrange
            var stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            var eagerBooks = await classicBookRepository
                .GetEagerAllAdultBookWithCartesianExplosionAsync();
            stopwatch.Stop();
            var eagerTime = stopwatch.ElapsedMilliseconds;

            stopwatch.Restart();
            var selectBooks = await classicBookRepository.GetEagerAllAdultBookUsingSelectAsync();
            stopwatch.Stop();
            var selectTime = stopwatch.ElapsedMilliseconds;

            // Try a second time with cartesian explosion
            stopwatch.Start();
            var secondEagerBooks = await classicBookRepository
                .GetEagerAllAdultBookWithCartesianExplosionAsync();
            stopwatch.Stop();
            var secondEagerTime = stopwatch.ElapsedMilliseconds;

            // Assert
            Assert.True(eagerTime > selectTime,
                $"Select method is faster: {selectTime}ms vs {secondEagerTime}ms");
        }
    }
}