using Game.Infrastructure;
using UnityEngine;

namespace Game.Gameplay
{
    /// <summary>
    /// Example component for gameplay state. Provides method to return to meta.
    /// </summary>
    public class GameController : MonoBehaviour
    {
        public void ReturnToMeta()
        {
            GameBootstrapper.StateMachine.Enter<MetaState>();
        }
    }
}
