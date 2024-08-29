using ChutesAndLadders.Deck;
using ChutesAndLadders.Game;
using Zenject;

namespace ChutesAndLadders
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInterfacesTo<DeckManager>().AsSingle();
        }
    }    
}
