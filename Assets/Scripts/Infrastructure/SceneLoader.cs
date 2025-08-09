using System;
using UnityEngine.SceneManagement;

namespace Game.Infrastructure
{
    /// <summary>
    /// Helper class for loading Unity scenes.
    /// </summary>
    public class SceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);
            if (onLoaded != null)
            {
                operation.completed += _ => onLoaded();
            }
        }
    }
}
