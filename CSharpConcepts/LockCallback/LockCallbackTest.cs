namespace LockCallback
{
    public class LockCallbackTest
    {
        [Fact]
        public void GivenRunSafeWhenIsInvokeThenIncrementAll()
        {
            //Arrange
            var expectedCounterValue = 10000;
            static int runSafeAction() => LockCallback.RunSafe();

            //Act
            int result = runSafeAction();

            //Assert
            Assert.Equal(expectedCounterValue, result);
        }

        [Fact]
        public void GivenRunUnSafeWhenIsInvokeThenAllResultValueAreLessThenExpected()
        {
            //Arrange
            var expectedCounterValue = 10000;
            static int runSafeAction() => LockCallback.RunUnsafe();
            List<int> results = [];


            //Act
            
            for (int i = 0; i < 1000; i++)
            {
                results.Add(runSafeAction());
            }

            //Assert
            bool anyLessThanExpected = results.Any(result => result < expectedCounterValue);
            Assert.True(anyLessThanExpected, $"No result is less than the expected value {expectedCounterValue}");
        }
    }
}