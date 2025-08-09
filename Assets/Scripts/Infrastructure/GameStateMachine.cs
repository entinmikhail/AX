using Zenject;

namespace Game.Infrastructure
{
    /// <summary>
    /// Finite state machine managing global game states.
    /// </summary>
    public class GameStateMachine
    {
        private readonly DiContainer _container;
        private IState _activeState;

        public GameStateMachine(DiContainer container)
        {
            _container = container;
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            var state = _container.Resolve<TState>();
            _activeState = state;
            state.Enter();
        }
    }
}

