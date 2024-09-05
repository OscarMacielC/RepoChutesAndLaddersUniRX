using System;

namespace ChutesAndLadders.Game
{
    public interface IGameSource
    {
        void StartGame();
        void CreateNewTurn();
        
        IObservable<int> OnTurnStarted { get; }
        IObservable<int> OnDiceRolled { get; }
    }
}