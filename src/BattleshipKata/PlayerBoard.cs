using System.Collections.Generic;

namespace BattleshipKata {
    public class PlayerBoard {
        private List<Boat> boats;

        public PlayerBoard() {
            boats = new List<Boat>();
        }

        public void Add(Boat boat) {
            boats.Add(boat);
        }

        public int NumberOfBoats() {
            return boats.Count;
        }
    }
}