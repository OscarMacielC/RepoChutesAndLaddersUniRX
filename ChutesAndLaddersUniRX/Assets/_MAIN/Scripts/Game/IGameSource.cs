using System;

namespace ChutesAndLadders.Game
{
    public interface IGameSource
    {
        void StartGame();
        void CreateNewTurn();
        
        IObservable<int> OnTurnEnded { get; }
        IObservable<int> OnDiceRolled { get; }
    }
}