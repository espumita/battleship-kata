using System;
using BattleshipKata.Exceptions;
using BattleshipKata.Messaging;
using BattleshipKata.Messaging.Error;
using NSubstitute;
using Xunit;

namespace BattleshipKata.Tests {
    public class BattleshipGameTests {
        private readonly BattleshipGame game;
        private readonly Player aPlayer;
        private readonly Player anotherPlayer;
        private MessagesSubscriber subscriber;

        public BattleshipGameTests() {
            var messageBus = new InMemoryMessageBus();
            subscriber = Substitute.For<MessagesSubscriber>();
            messageBus.SubscribeToMessagesOfType<GameCannotStartWithAtLeastTwoPlayersErrorMessage>(subscriber);
            game = new BattleshipGame(messageBus);
            aPlayer = new Player("Yosh");
            anotherPlayer = new Player("Bob");
        }

        [Fact]
        public void game_cannot_start_with_at_least_two_players() {
            game.AddPlayer(aPlayer);

            game.Start();

            subscriber.Received().Notify(Arg.Any<GameCannotStartWithAtLeastTwoPlayersErrorMessage>());
        }

        [Fact]
        public void game_cannot_start_until_all_players_set_their_boats() {
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);

            Action action = () => game.Start();

            Assert.Throws<GameCannotStartUntilAllPLayersSetTheirBoatsException>(action);
        }

        [Fact]
        public void start_the_game_with_all_players_boats() {
            PrepareGameToStart();

            game.Start();

            Assert.Equal(14, game.Boats());
        }

        [Fact]
        public void first_player_start_the_game_with_the_turn() {
            PrepareGameToStart();

            game.Start();

            var playerWithTurn = game.PlayerWithTurn();
            Assert.Equal("Yosh", playerWithTurn);
        }

        [Fact]
        public void pass_the_turn_when_a_player_shoots() {
            PrepareGameToStart();
            game.Start();

            var shootResponse = game.PlayerShoots(aPlayer, anotherPlayer);

            Assert.Equal(ShootResponse.Miss, shootResponse);
            var playerWithTurn = game.PlayerWithTurn();
            Assert.Equal("Bob", playerWithTurn);
        }

        private void PrepareGameToStart() {
            game.AddPlayer(aPlayer);
            game.AddPlayer(anotherPlayer);
            AddAllBoats(game, aPlayer);
            AddAllBoats(game, anotherPlayer);
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