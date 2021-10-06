using Xunit;

namespace BattleshipKata.Tests {
    public class BattleshipGameTests {


        [Fact]
        public void start_the_game_with_empty_boats() {
            var game = new BattleshipGame();

            game.Start();

            Assert.Equal(0, game.Boats());
        }
    }

}