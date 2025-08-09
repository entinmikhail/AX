using Zenject;

namespace Game.Infrastructure
{
    /// <summary>
    /// Represents the meta-game portion (menus, hub, etc.).
    /// Loads the corresponding scene on enter.
    /// </summary>
    public class MetaState : IState
    {
        [Inject] private SceneLoader _sceneLoader;

        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Meta);
        }

        public void Exit() { }
    }
}
