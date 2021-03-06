using System.Collections.Generic;
using BattleshipKata.Exceptions;

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
            if (boat is Carrier carrier) TryToAdd(carrier);
            if (boat is Destroyer destroyer) TryToAdd(destroyer);
            if (boat is GunShip gunShip) TryToAdd(gunShip);
        }

        private void TryToAdd(Carrier carrier) {
            if (carriers.Count >= 1) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
            carriers.Add(carrier);
        }

        private void TryToAdd(Destroyer destroyer) {
            if (destroyers.Count >= 2) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
            destroyers.Add(destroyer);
        }

        private void TryToAdd(GunShip gunShip) {
            if (gunships.Count >= 4) throw new PlayerCannotHasMoreBoatsOfThatTypeException();
            gunships.Add(gunShip);
        }

        public int NumberOfBoats() {
            return carriers.Count + destroyers.Count + gunships.Count;
        }

        public bool IsReady() {
            return carriers.Count == 1
                   && destroyers.Count == 2 
                   && gunships.Count == 4;
        }
    }
}