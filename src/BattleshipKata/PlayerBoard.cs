using System.Collections.Generic;

namespace BattleshipKata {
    public class PlayerBoard {
        private readonly List<CarrierBoat> carrierBoats;

        public PlayerBoard() {
            carrierBoats = new List<CarrierBoat>();
        }

        public void Add(Boat boat) {
            if (boat is CarrierBoat) {
                if (carrierBoats.Count >= 4) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                carrierBoats.Add((CarrierBoat) boat);
            }
        }

    public int NumberOfBoats() {
            return carrierBoats.Count;
        }
    }
}