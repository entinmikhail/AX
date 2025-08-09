using Zenject;

namespace Game.Infrastructure
{
    /// <summary>
    /// Represents the core gameplay loop. Loads gameplay scene on enter.
    /// </summary>
    public class GameplayState : IState
    {
        [Inject] private SceneLoader _sceneLoader;

        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Gameplay);
        }

        public void Exit() { }
    }
}
