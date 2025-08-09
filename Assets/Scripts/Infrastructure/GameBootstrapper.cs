using UnityEngine;
using Zenject;

namespace Game.Infrastructure
{
    /// <summary>
    /// Entry point for the application. Creates the game state machine and starts bootstrap process.
    /// Should be placed in the bootstrap scene.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        [Inject]
        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        private void Awake()
        {
            DontDestroyOnLoad(this);
            _stateMachine.Enter<BootstrapState>();
        }
    }
}
