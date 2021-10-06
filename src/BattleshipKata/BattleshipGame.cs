using System.Collections.Generic;
using System.Linq;

namespace BattleshipKata {
    public class BattleshipGame {
        private Dictionary<string, PlayerBoard> playerBoards;

        public BattleshipGame() {
            playerBoards = new Dictionary<string, PlayerBoard>();
        }

        public void Start() {

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