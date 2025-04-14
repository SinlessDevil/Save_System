using System;
using Code.Infrastructure.Services.GameStater;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameInstaller : MonoInstaller, IInitializable, IDisposable
    {
        [SerializeField] private GameObject _mapHolder;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<GameInstaller>().FromInstance(this).AsSingle();
            Container.Bind<IGameStarter>().To<GameStarter>().AsSingle();
        }

        public void Initialize()
        {
            Container.Resolve<IGameStarter>().Initialize();
        }

        public void Dispose()
        {
            
        }
    }
}