using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;
using UniRx;

namespace ChutesAndLadders.Managers
{
    public partial class PlayersController : MonoBehaviour
    {
        [Inject] private IPlayersSource _playersSource;
        [SerializeField] private List<Character> charactersList = new List<Character>();
        [SerializeField] private Character activeCharacter;
        [SerializeField] private int activeCharacterIdx;

        private void Start()
        {
            _playersSource.OnPlayerListInitialized.Subscribe().AddTo(this);
            _playersSource.OnSelectedCharacter.Subscribe(SelectCharacter).AddTo(this);
            foreach (var character in charactersList)
            {
                //character.transform.position = _characterInitializer.GetNPosition(character.TurnOrder);
            }
            activeCharacter = charactersList[activeCharacterIdx];
        }
        
        private void SelectCharacter(int activeCharacterIdx)
        {
            if (activeCharacterIdx >= charactersList.Count)
            {
                //activeCharacterIdx = STARTING_CHARACTER;
            }

            activeCharacter = charactersList[activeCharacterIdx];
        }
    }
}