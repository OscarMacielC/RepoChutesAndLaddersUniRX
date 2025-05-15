using ChutesAndLadders.Managers;
using TMPro;
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
        [SerializeField] private TextMeshProUGUI turnText;
        
        private void Start()
        {
            _gameSource.OnTurnEnded.Subscribe(turnId =>
            {
                Debug.Log($"GC Turn Ended: {turnId}");
            }).AddTo(this);
            
            _gameSource.OnDiceRolled.Subscribe(diceResult =>
            {
                Debug.Log($"GC Dice Rolled: {diceResult}");
            }).AddTo(this);
        }
    }
}