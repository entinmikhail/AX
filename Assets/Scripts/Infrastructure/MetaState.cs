namespace Game.Infrastructure
{
    /// <summary>
    /// Represents the meta-game portion (menus, hub, etc.).
    /// Loads the corresponding scene on enter.
    /// </summary>
    public class MetaState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;

        public MetaState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            _sceneLoader.Load(SceneNames.Meta);
        }

        public void Exit() { }
    }
}
