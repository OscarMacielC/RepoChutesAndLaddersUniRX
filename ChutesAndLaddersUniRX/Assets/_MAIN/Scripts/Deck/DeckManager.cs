using UnityEngine;

namespace ChutesAndLadders.Deck
{
    public partial class DeckManager
    {
        
    }

    public partial class DeckManager : IDeckSource
    {
        private const int INITIAL_DIE = 1;
        private const int DIE_INCLUSIVE_FIX = 1;
        
        int IDeckSource.RollDie(int faceQty)
        {
            var exclusiveFace = faceQty + DIE_INCLUSIVE_FIX;
            var roll = Mathf.FloorToInt(Random.Range(INITIAL_DIE, exclusiveFace));
            return roll;
        }
    }
}
