using System;
using ChutesAndLadders.Deck;
using Cysharp.Threading.Tasks;
using Zenject;

namespace ChutesAndLadders.Game
{
    public partial class GameManager
    {
        [Inject] private IDeckSource _deckSource;

        private Turn _currentTurn;

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
        }

        private async UniTask ExecuteRollDiceMovement(RollDiceMovement rollDiceMovement)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1));
        }

        private async UniTask ExecuteMovePlayerMovement(MovePlayerMovement movePlayerMovement)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(1 * movePlayerMovement.Moves));
        }
    }

    public partial class GameManager : IGameSource
    {
        void IGameSource.StartGame()
        {
            //TODO Initialize players on playercontroller
            _currentTurn = new Turn();
            var diceResult = _deckSource.RollDie(6);
            _currentTurn.AddMovement(new RollDiceMovement(diceResult));
            _currentTurn.AddMovement(new MovePlayerMovement(diceResult));

            ExecuteTurn().Forget();
        }
    }
}