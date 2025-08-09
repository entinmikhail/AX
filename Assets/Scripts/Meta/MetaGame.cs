using Game.Infrastructure;
using UnityEngine;

namespace Game.Meta
{
    /// <summary>
    /// Example component for meta game layer. Can be hooked to UI buttons.
    /// </summary>
    public class MetaGame : MonoBehaviour
    {
        public void StartGameplay()
        {
            GameBootstrapper.StateMachine.Enter<GameplayState>();
        }
    }
}
