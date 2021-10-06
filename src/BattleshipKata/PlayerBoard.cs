using System.Collections.Generic;

namespace BattleshipKata {
    public class PlayerBoard {
        private readonly List<CarrierBoat> carrierBoats;
        private readonly List<DestroyerBoat> destroyerBoats;

        public PlayerBoard() {
            carrierBoats = new List<CarrierBoat>();
            destroyerBoats = new List<DestroyerBoat>();
        }

        public void Add(Boat boat) {
            if (boat is CarrierBoat) {
                if (carrierBoats.Count >= 4) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                carrierBoats.Add((CarrierBoat) boat);
            }
            if (boat is DestroyerBoat) {
                if (destroyerBoats.Count >= 3) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                destroyerBoats.Add((DestroyerBoat)boat);
            }
        }

    public int NumberOfBoats() {
            return carrierBoats.Count + destroyerBoats.Count;
        }
    }
}