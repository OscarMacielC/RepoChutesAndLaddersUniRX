using ChutesAndLadders.Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ChutesAndLadders.UI
{
    public class ExecuteTurnButton: MonoBehaviour
    {
        [Inject] private IGameSource _gameSource;
        
        [SerializeField] private Button _nextTurnButton;

        private void Start()
        {
            _nextTurnButton.onClick.AddListener(_gameSource.CreateNewTurn);
        }
    }
}