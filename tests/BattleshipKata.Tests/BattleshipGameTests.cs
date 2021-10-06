using Xunit;

namespace BattleshipKata.Tests {
    public class BattleshipGameTests {


        [Fact] 
        public void start_the_game_with_empty_boats() {
            var game = new BattleshipGame();

            game.Start();

            Assert.Equal(0, game.Boats());
        }

        [Fact]
        public void start_the_game_with_a_player_boats() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            game.AddPlayer(aPlayer);
            var aCarrierBoat = new CarrierBoat();
            game.AddBoat(aPlayer, aCarrierBoat);

            game.Start();

            Assert.Equal(1, game.Boats());
        }
    }

}