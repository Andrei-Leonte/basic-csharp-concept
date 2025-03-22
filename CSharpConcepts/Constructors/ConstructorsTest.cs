namespace Constructors
{
    public class ConstructorsTest
    {
        [Fact]
        public async Task GivenStaticConstructorWhen2ObjectAreInitializedThenBothHaveSameValues()
        {
            //Arrange
            Constructor first;
            Constructor second;
                
            //Act
            first = new Constructor();
            await Task.Delay(1000);
            second = new Constructor();

            //Assert
            Assert.Equal(first.GetName(), second.GetName());
        }
    }
}