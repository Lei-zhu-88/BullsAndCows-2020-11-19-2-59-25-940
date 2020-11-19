using BullsAndCows;
using Moq;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new SecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            Assert.NotNull(game);
            Assert.True(game.CanContinue);
        }

        [Fact]
        public void Should_return_0A0B_given_secret_1234_guess_5678()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "0A0B";
            //when
            var actual = game.Guess("5 6 7 8");

            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Should_return_4A0B_given_secret_1234_guess_1234()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "4A0B";
            //when
            var actual = game.Guess("1 2 3 4");

            //then
            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData("4 3 2 1")]
        [InlineData("3 4 2 1")]

        public void Should_return_0A4B_given_secret_1234_guess_4321_and_3421(string guess)
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "0A4B";
            //when
            var actual = game.Guess(guess);

            //then
            Assert.Equal(expect, actual);
        }

        [Theory]
        [InlineData("1 2 3 4", "1234")]
        [InlineData("5 6 7 8", "5678")]

        public void Should_return_4A0B_When_All_digit_and_position_correct(string guess, string secret)
        {
            //given
            var mockSecretGenerator = new Mock<TestSecretGenerator>();
            mockSecretGenerator.Setup(mock => mock.GenerateSecret()).Returns(secret);
            var game = new BullsAndCowsGame(mockSecretGenerator.Object);
            var expect = "4A0B";
            //when
            var actual = game.Guess(guess);

            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Should_return_0A2B_given_secret_1234_guess_3456()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "0A2B";
            //when
            var actual = game.Guess("3 4 5 6");

            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Should_return_1A2B_given_secret_1234_guess_1425()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "1A2B";
            //when
            var actual = game.Guess("1 4 2 5");

            //then
            Assert.Equal(expect, actual);
        }

        [Fact]
        public void Should_return_1A3B_given_secret_1234_guess_1423()
        {
            //given
            var secretGenerator = new TestSecretGenerator();
            var game = new BullsAndCowsGame(secretGenerator);
            var expect = "1A3B";
            //when
            var actual = game.Guess("1 4 2 3");

            //then
            Assert.Equal(expect, actual);
        }
    }

    public class TestSecretGenerator : SecretGenerator
    {
        public override string GenerateSecret()
        {
            return "1234";
        }
    }
}
