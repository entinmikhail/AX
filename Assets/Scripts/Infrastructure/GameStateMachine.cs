using System;
using System.Collections.Generic;

namespace Game.Infrastructure
{
    /// <summary>
    /// Finite state machine managing global game states.
    /// </summary>
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(SceneLoader sceneLoader)
        {
            _states = new Dictionary<Type, IState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this),
                [typeof(MetaState)] = new MetaState(this, sceneLoader),
                [typeof(GameplayState)] = new GameplayState(this, sceneLoader)
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            _activeState?.Exit();
            var state = GetState<TState>();
            _activeState = state;
            state.Enter();
        }

        private TState GetState<TState>() where TState : class, IState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
