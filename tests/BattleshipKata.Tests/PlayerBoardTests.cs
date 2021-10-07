using System;
using BattleshipKata.Exceptions;
using Xunit;

namespace BattleshipKata.Tests {
    public class PlayerBoardTests {
        private readonly PlayerBoard playerBoard;

        public PlayerBoardTests() {
            playerBoard = new PlayerBoard();
        }

        [Fact]
        public void has_1_carrier_boats() {

            playerBoard.Add(new Carrier());

            Assert.Equal(1, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_1_carrier_boats() {
            playerBoard.Add(new Carrier());
            
            Action action = () => playerBoard.Add(new Carrier());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void has_2_destroyers_boats() {

            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());

            Assert.Equal(2, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_2_destroyers_boats() {
            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());
            
            Action action = () => playerBoard.Add(new Destroyer());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void has_4_gun_ship_boats() {

            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());

            Assert.Equal(4, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_4_destroyers_boats() {
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            
            Action action = () => playerBoard.Add(new GunShip());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void say_is_not_ready_when_player_is_not_ready() {

            var isReady = playerBoard.IsReady();

            Assert.False(isReady);
        }

        [Fact]
        public void say_is_ready_when_player_is_ready() {
            playerBoard.Add(new Carrier());
            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());

            var isReady = playerBoard.IsReady();

            Assert.True(isReady);
        }
    }

}