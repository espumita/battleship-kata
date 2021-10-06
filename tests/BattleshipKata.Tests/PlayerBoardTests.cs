﻿using System;
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
    }

}