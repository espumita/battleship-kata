using System.Collections.Generic;
using System.Linq;
using BattleshipKata.Exceptions;

namespace BattleshipKata {
    public class BattleshipGame {
        private Dictionary<string, PlayerBoard> playerBoards;
        private string playerWithTurn;

        public BattleshipGame() {
            playerBoards = new Dictionary<string, PlayerBoard>();
        }

        public void Start() {
            if (playerBoards.Keys.Count < 2) throw new GameCannotStartWithAtLeastTwoPlayersException();
            if (!AreAllPlayersBoardsReady()) throw new GameCannotStartUntilAllPLayersSetTheirBoatsException();
            playerWithTurn = playerBoards.Keys.First();
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
         public string PlayerWithTurn() {
            return playerWithTurn;
        }

        public ShootResponse PlayerShoots(Player shooter, Player target) {
            var shootResponse = ShootResponse.Miss;
            playerWithTurn = NextPlayer();
            return shootResponse;
        }

        private string NextPlayer() {
            var firstPlayerWithoutTurn = playerBoards.Keys.First(playerName => !playerName.Equals(playerWithTurn));
            return firstPlayerWithoutTurn;
        }

        private bool AreAllPlayersBoardsReady() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .All(playerBoard => playerBoard.IsReady());
        }

    }

}