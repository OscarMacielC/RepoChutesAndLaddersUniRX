using ChutesAndLadders.Managers;
using UnityEngine;
using Zenject;
using UniRx;

namespace ChutesAndLadders.Game
{
    public partial class GameController : MonoBehaviour
    {
        [Inject] private IGameSource _gameSource;
        [SerializeField] private GameObject player;
        [SerializeField] private BoardController boardController;
        private GameManager _gameManager;

        private void Start()
        {
            _gameSource.OnTurnStarted.Subscribe(turnId =>
            {
                Debug.Log($"New Turn Started: {turnId}");
            }).AddTo(this);
            
            _gameSource.OnDiceRolled.Subscribe(diceResult =>
            {
                Debug.Log($"Dice Rolled: {diceResult}");
            }).AddTo(this);
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Space)) return;
            Debug.Log("Player should move to next node");
            NextTurn();
        }

        public void NextTurn()
        {
            _gameSource.CreateNewTurn();
        }
        
    }
}