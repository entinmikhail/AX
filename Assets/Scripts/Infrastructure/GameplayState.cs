namespace Game.Infrastructure
{
    /// <summary>
    /// Represents the core gameplay loop. Loads gameplay scene on enter.
    /// </summary>
    public class GameplayState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public GameplayState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Gameplay);
        }

        public void Exit() { }
    }
}
