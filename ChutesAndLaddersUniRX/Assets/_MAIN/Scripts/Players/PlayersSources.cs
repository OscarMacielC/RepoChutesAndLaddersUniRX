using System;
using System.Collections.Generic;

namespace ChutesAndLadders.Managers
{
    public interface IPlayersSource
    {
        IObservable<int> OnSelectedCharacter { get; }
        IObservable<IReadOnlyList<(int index, PlayerType type)>> OnPlayerListInitialized { get; }
    }
}
