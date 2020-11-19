using BullsAndCows;
using Xunit;

namespace BullsAndCowsTest
{
    public class BullsAndCowsGameTest
    {
        [Fact]
        public void Should_create_BullsAndCowsGame()
        {
            var secretGenerator = new TestSecretGenerator();
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
            var expect = "0A0B";
            //when
            var actual = game.Guess("1 2 3 4");

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
