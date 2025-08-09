using Game.Infrastructure;
using UnityEngine;
using Zenject;

namespace Game.Gameplay
{
    /// <summary>
    /// Example component for gameplay state. Provides method to return to meta.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        [Inject] private GameStateMachine _stateMachine;

        public void ReturnToMeta()
        {
            _stateMachine.Enter<MetaState>();
        }
    }
}
