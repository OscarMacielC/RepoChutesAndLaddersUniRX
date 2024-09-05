using System;
using ChutesAndLadders.Deck;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using Zenject;

namespace ChutesAndLadders.Game
{
    public partial class GameManager
    {
        [Inject] private IDeckSource _deckSource;
        private readonly Subject<int> _onTurnEndedSubject = new();
        private readonly Subject<int> _onDiceRolledSubject = new();
        private Turn _currentTurn;
        private int _turnId;

        private async UniTaskVoid ExecuteTurn()
        {
            foreach (var movement in _currentTurn.MovementsList)
            {
                switch (movement)
                {
                    case RollDiceMovement rollDiceMovement:
                        await ExecuteRollDiceMovement(rollDiceMovement);
                        break;
                    case MovePlayerMovement movePlayerMovement:
                        await ExecuteMovePlayerMovement(movePlayerMovement);
                        break;
                }
            }

            await UniTask.Delay(TimeSpan.FromSeconds(1));
            _turnId++;
            _onTurnEndedSubject.OnNext(_turnId);
            
        }

        private async UniTask ExecuteRollDiceMovement(RollDiceMovement rollDiceMovement)
        {
            Debug.Log($"Executing roll: {rollDiceMovement.RollResult}");
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }

        private async UniTask ExecuteMovePlayerMovement(MovePlayerMovement movePlayerMovement)
        {
            Debug.Log($"Player should move here: {movePlayerMovement.Moves}");
            await UniTask.Delay(TimeSpan.FromSeconds(1 * movePlayerMovement.Moves));
        }
    }

    public partial class GameManager : IInitializable
    {
        public void Initialize()
        {
            StartGame();
        }

        public void StartGame()
        {
            CreateNewTurn();
        }

        public void CreateNewTurn()
        {
            _currentTurn = new Turn();
            var diceResult = _deckSource.RollDie(6);
            _onDiceRolledSubject.OnNext(_turnId);
            _currentTurn.AddMovement(new RollDiceMovement(diceResult));
            _currentTurn.AddMovement(new MovePlayerMovement(diceResult));
            
            ExecuteTurn().Forget();
        }
    }

    public partial class GameManager : IGameSource
    {
        public IObservable<int> OnTurnEnded => _onTurnEndedSubject.AsObservable();
        public IObservable<int> OnDiceRolled => _onDiceRolledSubject.AsObservable();
    }
}