using ChutesAndLadders.Deck;
using ChutesAndLadders.Game;
using ModestTree;
using UnityEngine;
using Zenject;

namespace ChutesAndLadders
{
    public class MainInstaller : MonoInstaller
    {
        
        public override void InstallBindings()
        {
            Debug.Log("MainInstaller is running");
            Container.BindInterfacesTo<GameManager>().AsSingle();
            Container.BindInterfacesTo<DeckManager>().AsSingle();
            
            Container.BindInterfacesTo<GameController>().AsSingle();
        }
    }    
}
