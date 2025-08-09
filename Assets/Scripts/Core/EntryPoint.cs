using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// Static entry point that wires our game logic into Unity.
    /// Unity is only used here to create a single runner behaviour
    /// that forwards engine callbacks to pure C# code.
    /// </summary>
    public static class EntryPoint
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void StartGame()
        {
            var go = new GameObject("GameRunner");
            var runner = go.AddComponent<GameRunner>();
            runner.Init(new Game());
        }
    }
}
