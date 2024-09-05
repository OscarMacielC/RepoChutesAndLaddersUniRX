using ChutesAndLadders.Deck;
using ChutesAndLadders.Game;
using Zenject;

namespace ChutesAndLadders
{
    public class MainInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
            Container.BindInterfacesTo<DeckManager>().AsSingle();
        }
    }    
}
