using UnityEngine;

namespace Game.Infrastructure
{
    /// <summary>
    /// Entry point for the application. Creates the game state machine and starts bootstrap process.
    /// Should be placed in the bootstrap scene.
    /// </summary>
    public class GameBootstrapper : MonoBehaviour
    {
        public static GameStateMachine StateMachine { get; private set; }

        private void Awake()
        {
            if (StateMachine == null)
            {
                StateMachine = new GameStateMachine(new SceneLoader());
                DontDestroyOnLoad(this);
                StateMachine.Enter<BootstrapState>();
            }
        }
    }
}
