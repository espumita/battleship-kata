using System;
using Xunit;

namespace BattleshipKata.Tests {
    public class BattleshipGameTests {


        [Fact] 
        public void start_the_game_with_empty_boats() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);

            game.Start();

            Assert.Equal(0, game.Boats());
        }

        [Fact]
        public void start_the_game_with_a_player_boats() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);
            var aCarrierBoat = new CarrierBoat();
            game.AddBoat(aPlayer, aCarrierBoat);

            game.Start();

            Assert.Equal(1, game.Boats());
        }

        [Fact]
        public void game_cannot_start_with_at_least_two_players() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            game.AddPlayer(aPlayer);

            Action action = () => game.Start();

            Assert.Throws<GameCannotStartWithAtLeastTwoPlayersException>(action);
        }
    }

}