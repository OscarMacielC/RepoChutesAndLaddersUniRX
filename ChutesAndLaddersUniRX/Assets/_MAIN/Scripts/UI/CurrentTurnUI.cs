using ChutesAndLadders.Game;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace ChutesAndLadders.UI
{
    public class CurrentTurnUI: MonoBehaviour
    {
        [Inject] private IGameSource _gameSource;
        
        [SerializeField] private TextMeshProUGUI _turnText;

        private void Start()
        {
            UpdateTurnText(_gameSource.CurrentTurn);
            _gameSource.OnTurnStarted.Subscribe(UpdateTurnText).AddTo(this);
        }

        private void UpdateTurnText(int turn)
        {
            _turnText.text = $"Turn: {turn}";
        }
    }
}