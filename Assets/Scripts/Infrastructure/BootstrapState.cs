namespace Game.Infrastructure
{
    /// <summary>
    /// Initializes services required before other states can run.
    /// After initialization immediately switches to the meta state.
    /// </summary>
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;

        public BootstrapState(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            // Here you can initialize any services (e.g., analytics, save system).
            _stateMachine.Enter<MetaState>();
        }

        public void Exit() { }
    }
}
