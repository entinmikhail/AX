using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// Minimal MonoBehaviour used only to drive the update loop.
    /// </summary>
    public class GameRunner : MonoBehaviour
    {
        private Game _game;

        public void Init(Game game)
        {
            _game = game;
        }

        private void Update()
        {
            _game?.Update(Time.deltaTime);
        }
    }
}
