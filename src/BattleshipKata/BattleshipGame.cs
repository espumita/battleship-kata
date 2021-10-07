using System.Collections.Generic;
using System.Linq;
using BattleshipKata.Exceptions;
using BattleshipKata.Messaging;
using BattleshipKata.Messaging.Errors;

namespace BattleshipKata {
    public class BattleshipGame {
        private readonly Dictionary<string, PlayerBoard> playerBoards;
        private string playerWithTurn;
        private readonly MessageBus messageBus;


        public BattleshipGame(MessageBus messageBus) {
            playerBoards = new Dictionary<string, PlayerBoard>();
            this.messageBus = messageBus;
        }

        public void Start() {
            if (playerBoards.Keys.Count < 2) {
                messageBus.Publish(new GameCannotStartWithAtLeastTwoPlayersErrorMessage());
                return;
            };
            if (!AreAllPlayersBoardsReady()) {
                messageBus.Publish(new GameCannotStartUntilAllPLayersSetTheirBoatsErrorMessage());
                return;
            };
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