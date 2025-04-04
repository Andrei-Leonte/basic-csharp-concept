using Bogus;
using Members;
using System.ComponentModel;
using System.Diagnostics;

namespace MembersTest
{
    public class AbstractMembersAndSealedClassTest
    {
        private readonly List<PublishingHouse> publishingHouses;
        private readonly List<SealedPublishingHouse> sealedPublishingHouses;

        public AbstractMembersAndSealedClassTest()
        {
            var faker = new Faker();
            publishingHouses = [];
            sealedPublishingHouses = [];

            for (int i = 0; i < 1000; i++)
            {
                publishingHouses.Add(new PublishingHouse(
                    faker.Name.FirstName(),
                    faker.Name.LastName(),
                    faker.Lorem.Word(),
                    faker.Random.Bool(),
                    faker.Company.CompanyName()
                ));

                sealedPublishingHouses.Add(new SealedPublishingHouse(
                    faker.Name.FirstName(),
                    faker.Name.LastName(),
                    faker.Lorem.Word(),
                    faker.Random.Bool(),
                    faker.Company.CompanyName()
                ));
            }
        }

        [Fact, Description("Event if sealed is slightly more faster no real difference can be show. " +
            "'https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members#static-members'")]
        public void GivenSealedAndNotSealedClassesWhenSizeIsTheSameThenSealedIsFaster()
        {
            // Arrange
            var stopwatch = new Stopwatch();
            const int retries = 1000;
            long publishingHouseTotalTime = 0;
            long sealedPublishingHouseTotalTime = 0;

            for (int retry = 0; retry < retries; retry++)
            {
                // Act for SealedPublishingHouse
                stopwatch.Start();
                foreach (var house in sealedPublishingHouses)
                {
                    house.GetName();
                }
                stopwatch.Stop();
                sealedPublishingHouseTotalTime += stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();

                // Act for PublishingHouse
                stopwatch.Start();
                foreach (var house in publishingHouses)
                {
                    house.GetName();
                }
                stopwatch.Stop();
                publishingHouseTotalTime += stopwatch.ElapsedMilliseconds;

                stopwatch.Reset();
            }

            var publishingHouseAverageTime = publishingHouseTotalTime / retries;
            var sealedPublishingHouseAverageTime = sealedPublishingHouseTotalTime / retries;

            // Assert
            Console.WriteLine($"PublishingHouse GetName Average Time: {publishingHouseAverageTime} ms");
            Console.WriteLine($"SealedPublishingHouse GetName Average Time: {sealedPublishingHouseAverageTime} ms");

            // You can add assertions to check if one is faster than the other
            Assert.True(publishingHouseAverageTime >= sealedPublishingHouseAverageTime);
        }
    }
}