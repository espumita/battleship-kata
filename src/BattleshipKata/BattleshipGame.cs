using System.Collections.Generic;
using System.Linq;
using BattleshipKata.Exceptions;

namespace BattleshipKata {
    public class BattleshipGame {
        private Dictionary<string, PlayerBoard> playerBoards;

        public BattleshipGame() {
            playerBoards = new Dictionary<string, PlayerBoard>();
        }

        public void Start() {
            if (playerBoards.Keys.Count < 2) throw new GameCannotStartWithAtLeastTwoPlayersException();
            if (!AreAllPlayersBoardsReady()) throw new GameCannotStartUntilAllPLayersSetTheirBoatsException();
        }

        public int Boats() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .Sum(playerBoard => playerBoard.NumberOfBoats());
        }

        public void AddPlayer(Player player) {
            playerBoards.Add(player.Name, new PlayerBoard());
        }

        public void AddBoat(Player player, Boat boat) {
            playerBoards[player.Name].Add(boat);
        }

        private bool AreAllPlayersBoardsReady() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .All(playerBoard => playerBoard.IsReady());
        }

    }

}