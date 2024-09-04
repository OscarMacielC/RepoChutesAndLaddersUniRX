using Zenject;

namespace ChutesAndLadders.Game
{
    public class GameController : IInitializable, ITickable
    {
        [Inject] private IGameSource _gameSource;

        public void Initialize()
        {
            _gameSource.StartGame();
        }

        public void Tick()
        {
        }
    }
}