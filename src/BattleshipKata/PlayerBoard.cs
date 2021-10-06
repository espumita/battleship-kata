using System.Collections.Generic;

namespace BattleshipKata {
    public class PlayerBoard {
        private readonly List<Carrier> carriers;
        private readonly List<Destroyer> destroyers;
        private readonly List<GunShip> gunships;

        public PlayerBoard() {
            carriers = new List<Carrier>();
            destroyers = new List<Destroyer>();
            gunships = new List<GunShip>();
        }

        public void Add(Boat boat) {
            if (boat is Carrier) {
                if (carriers.Count >= 2) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                carriers.Add((Carrier) boat);
            }
            if (boat is Destroyer) {
                if (destroyers.Count >= 3) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                destroyers.Add((Destroyer) boat);
            }
            if (boat is GunShip) {
                if (gunships.Count >= 5) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
                gunships.Add((GunShip) boat);
            }
        }

        public int NumberOfBoats() {
            return carriers.Count + destroyers.Count + gunships.Count;
        }
    }
}