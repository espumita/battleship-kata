using System.Collections.Generic;
using System.Linq;

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

        private bool AreAllPlayersBoardsReady() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .All(playerBoard => playerBoard.IsReady());
        }

        public int Boats() {
            var aPlayer = playerBoards.Keys.First();
            return playerBoards[aPlayer].NumberOfBoats();
        }

        public void AddPlayer(Player player) {
            playerBoards.Add(player.Name, new PlayerBoard());
        }

        public void AddBoat(Player player, Boat boat) {
            playerBoards[player.Name].Add(boat);
            new List<Boat> { boat };
        }
    }

}