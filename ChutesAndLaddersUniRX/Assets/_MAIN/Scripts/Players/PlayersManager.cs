using System;
using System.Collections.Generic;
using UniRx;

namespace ChutesAndLadders.Managers
{
    public enum PlayerType
    {
        Human,
        Bot
    }

    public partial class PlayersManager
    {
        private readonly DataSubject<int> _onPlayerSelectedSubject = new(FIRST_PLAYER_IDX);
        private readonly Subject<IReadOnlyList<(int index, PlayerType type)>> _onInitialPlayerListSubject = new();
        private CharacterInitializer _characterInitializer;
        private List<(int index, PlayerType type)> _playersTypeList = new();

        private const int FIRST_PLAYER_IDX = 0;

        private void SelectNextCharacter()
        {
            var activeCharacterIdx = _onPlayerSelectedSubject.Value;
            if (activeCharacterIdx >= _playersTypeList.Count)
            {
                activeCharacterIdx = FIRST_PLAYER_IDX;
            }

            _onPlayerSelectedSubject.OnNext(activeCharacterIdx);
        }

        private void SetPlayersTypeList(int numberOfPlayers, int numberOfBots, SortType sortType)
        {
            _playersTypeList.Clear();

            for (var i = 0; i < numberOfPlayers - numberOfBots; i++)
            {
                _playersTypeList.Add((i, PlayerType.Human));
            }
            
            _playersTypeList = PlayerTurnSorter.Sort(_playersTypeList, sortType);
            
            for (var i = numberOfPlayers - numberOfBots; i < numberOfPlayers; i++)
            {
                _playersTypeList.Add((i, PlayerType.Bot));
            }
            _onInitialPlayerListSubject.OnNext(_playersTypeList);
        }
    }

    public partial class PlayersManager : IPlayersSource
    {
        public IObservable<int> OnSelectedCharacter => _onPlayerSelectedSubject.AsObservable();

        public IObservable<IReadOnlyList<(int index, PlayerType type)>> OnPlayerListInitialized => _onInitialPlayerListSubject.AsObservable();
    }
}