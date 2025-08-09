using Zenject;

namespace Game.Infrastructure
{
    /// <summary>
    /// Registers game-level dependencies in the Zenject container.
    /// </summary>
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().AsSingle();
            Container.Bind<GameStateMachine>().AsSingle();
            Container.Bind<BootstrapState>().AsSingle();
            Container.Bind<MetaState>().AsSingle();
            Container.Bind<GameplayState>().AsSingle();
        }
    }
}

