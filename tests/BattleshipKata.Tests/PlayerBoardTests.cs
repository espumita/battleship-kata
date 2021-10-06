using System;
using Xunit;

namespace BattleshipKata.Tests {
    public class PlayerBoardTests {


        [Fact]
        public void has_4_carrier_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());

            Assert.Equal(4, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_4_carrier_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());
            playerBoard.Add(new CarrierBoat());
            Action action = () => playerBoard.Add(new CarrierBoat());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }

        [Fact]
        public void has_3_destroyers_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new DestroyerBoat());
            playerBoard.Add(new DestroyerBoat());
            playerBoard.Add(new DestroyerBoat());

            Assert.Equal(3, playerBoard.NumberOfBoats());
        }

        [Fact]
        public void has_no_more_than_3_destroyers_boats() {
            var playerBoard = new PlayerBoard();

            playerBoard.Add(new DestroyerBoat());
            playerBoard.Add(new DestroyerBoat());
            playerBoard.Add(new DestroyerBoat());
            Action action = () => playerBoard.Add(new DestroyerBoat());

            Assert.Throws<PlayerCannotHasMoreBoatsOfThatTypeException>(action);
        }
    }

}