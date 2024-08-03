using UnityEngine;

namespace ChutesAndLadders.Managers
{
    public partial class DeckManager
    {
        private const int INITIAL_DIE = 1;
        private const int DIE_INCLUSIVE_FIX = 1;
        
        private static int RollDie(int faceQty)
        {
            var exclusiveFace = faceQty + DIE_INCLUSIVE_FIX;
            var roll = Mathf.FloorToInt(Random.Range(INITIAL_DIE, exclusiveFace));
            return roll;
        }
    }
}
