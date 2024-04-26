using ZywaveApi.Services;
using AutoFixture;
namespace UnitTests
{
    public class TextFilterTests
    {
        Fixture _f = new Fixture();
        [Fact]
        public void ExpectedOutputShouldBeCorrect()
        {
            //Arrange
            ITextFilterService textFilterService = new TextFilterService();
            var testInput = "test text rext";
            var testCensorWords = new List<string> { "test" };
            var expectedOutput = "***** text rext";
            //Act
            var actualOutput = textFilterService.FilterText(testCensorWords, testInput).Result.ResultText;

            //Assert
            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void ShouldThrowException()
        {
            //Arrange
            ITextFilterService textFilterService = new TextFilterService();

            //Act+Assert
            Assert.ThrowsAsync<ArgumentNullException>(() => textFilterService.FilterText(null, null));
        }
    }
}