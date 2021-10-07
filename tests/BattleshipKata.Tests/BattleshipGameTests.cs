using System;
using BattleshipKata.Exceptions;
using Xunit;

namespace BattleshipKata.Tests {
    public class BattleshipGameTests {

        [Fact]
        public void game_cannot_start_with_at_least_two_players() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            game.AddPlayer(aPlayer);

            Action action = () => game.Start();

            Assert.Throws<GameCannotStartWithAtLeastTwoPlayersException>(action);
        }

        [Fact] 
        public void game_cannot_start_until_all_players_set_their_boats() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);

            Action action = () => game.Start();

            Assert.Throws<GameCannotStartUntilAllPLayersSetTheirBoatsException>(action);
        }

        [Fact]
        public void start_the_game_with_all_players_boats() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);
            AddAllBoats(game, aPlayer);
            AddAllBoats(game, anotherPlayer);

            game.Start();

            Assert.Equal(14, game.Boats());
        }

        [Fact]
        public void first_player_start_the_game_with_the_turn() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);
            AddAllBoats(game, aPlayer);
            AddAllBoats(game, anotherPlayer);

            game.Start();

            var playerWithTurn = game.PlayerWithTurn();
            Assert.Equal("Yosh", playerWithTurn);
        }

        [Fact]
        public void pass_the_turn_when_a_player_shoots() {
            var game = new BattleshipGame();
            var aPlayer = new Player("Yosh");
            var anotherPlayer = new Player("Bob");
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);
            AddAllBoats(game, aPlayer);
            AddAllBoats(game, anotherPlayer);
            game.Start();

            var shootResponse = game.PlayerShoots(aPlayer, anotherPlayer);

            Assert.Equal(ShootResponse.Miss, shootResponse);
            var playerWithTurn = game.PlayerWithTurn();
            Assert.Equal("Bob", playerWithTurn);
        }


        private static void AddAllBoats(BattleshipGame game, Player player) {
            game.AddBoat(player, new Carrier());
            game.AddBoat(player, new Destroyer());
            game.AddBoat(player, new Destroyer());
            game.AddBoat(player, new GunShip());
            game.AddBoat(player, new GunShip());
            game.AddBoat(player, new GunShip());
            game.AddBoat(player, new GunShip());
        }

    }

}