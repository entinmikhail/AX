using Game.Infrastructure;
using UnityEngine;
using Zenject;

namespace Game.Meta
{
    /// <summary>
    /// Example component for meta game layer. Can be hooked to UI buttons.
    /// </summary>
    public class MetaGame : MonoBehaviour
    {
        [Inject] private GameStateMachine _stateMachine;

        public void StartGameplay()
        {
            _stateMachine.Enter<GameplayState>();
        }
    }
}
