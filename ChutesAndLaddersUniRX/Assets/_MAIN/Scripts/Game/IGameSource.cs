using System;

namespace ChutesAndLadders.Game
{
    public interface IGameSource
    {
        void StartGame();
        void CreateNewTurn();
        
        int CurrentTurn { get; }
        
        IObservable<int> OnTurnStarted { get; }
        IObservable<int> OnTurnEnded { get; }
        IObservable<int> OnDiceRolled { get; }
    }
}