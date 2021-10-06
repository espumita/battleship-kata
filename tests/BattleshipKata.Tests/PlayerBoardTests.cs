using System;
using Xunit;

namespace BattleshipKata.Tests {
    public class PlayerBoardTests {

        [Fact]
        public void has_2_carrier_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new Carrier());
            playerBoard.Add(new Carrier());

            Assert.Equal(2, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_2_carrier_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new Carrier());
            playerBoard.Add(new Carrier());
            Action action = () => playerBoard.Add(new Carrier());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void has_3_destroyers_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());

            Assert.Equal(3, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_3_destroyers_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());
            playerBoard.Add(new Destroyer());
            Action action = () => playerBoard.Add(new Destroyer());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void has_5_gun_ship_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());

            Assert.Equal(5, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_5_destroyers_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            playerBoard.Add(new GunShip());
            Action action = () => playerBoard.Add(new GunShip());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }
    }

}