using System.Collections.Generic;
using System.Linq;
using BattleshipKata.Messaging;
using BattleshipKata.Messaging.Errors;
using BattleshipKata.Messaging.Events;

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
            if (!ThereIsEnoughPlayers()) { Publish(new GameCannotStartWithAtLeastTwoPlayersError()); return; }
            if (!AreAllPlayersBoardsReady()) { Publish(new GameCannotStartUntilAllPLayersSetTheirBoatsError()); return; }
            playerWithTurn = playerBoards.Keys.First();
            Publish(new GameStarted());
        }

        public void AddPlayer(Player player) {
            playerBoards.Add(player.Name, new PlayerBoard());
        }

        public void AddBoat(Player player, Boat boat) {
            playerBoards[player.Name].Add(boat);
        }

        public int Boats() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .Sum(playerBoard => playerBoard.NumberOfBoats());
        }

        public string PlayerWithTurn() {
            return playerWithTurn;
        }

        public ShootResponse PlayerShoots(Player shooter, Player target) {
            Publish(new PlayerShoots());
            Publish(new ShootMiss());
            var shootResponse = ShootResponse.Miss;
            playerWithTurn = NextPlayer();
            return shootResponse;
        }

        private bool ThereIsEnoughPlayers() {
            return playerBoards.Keys.Count >= 2;
        }

        private void Publish(Message message) {
            messageBus.Publish(message);
        }

        private bool AreAllPlayersBoardsReady() {
            return playerBoards.Keys.Select(playerName => playerBoards[playerName])
                .All(playerBoard => playerBoard.IsReady());
        }

        private string NextPlayer() {
            var firstPlayerWithoutTurn = playerBoards.Keys.First(playerName => !playerName.Equals(playerWithTurn));
            return firstPlayerWithoutTurn;
        }



    }

}