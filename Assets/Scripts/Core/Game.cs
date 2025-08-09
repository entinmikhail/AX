using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// Pure C# game world. Holds game objects and updates them.
    /// Unity objects are used only for visual representation.
    /// </summary>
    public class Game
    {
        private readonly List<Ball> _balls = new List<Ball>();
        private readonly SawSpawner _sawSpawner;

        public Game()
        {
            // create a few balls with random directions
            for (int i = 0; i < 3; i++)
            {
                var go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                go.name = $"Ball_{i}";
                go.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(-3f, 3f), 0f);
                var velocity = Random.insideUnitCircle.normalized * 5f;
                _balls.Add(new Ball(go.transform, velocity));
            }

            _sawSpawner = new SawSpawner();
        }

        public void Update(float dt)
        {
            foreach (var ball in _balls)
            {
                ball.Update(dt);
            }

            // simple pairwise collision detection
            for (int i = 0; i < _balls.Count; i++)
            {
                for (int j = i + 1; j < _balls.Count; j++)
                {
                    _balls[i].HandleCollision(_balls[j], _sawSpawner);
                }
            }

            _sawSpawner.Update(dt, _balls);
        }
    }
}
