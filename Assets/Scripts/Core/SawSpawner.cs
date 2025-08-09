using System.Collections.Generic;
using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// Spawns a saw power-up and grants temporary empowerment to balls.
    /// Implemented without MonoBehaviours.
    /// </summary>
    public class SawSpawner
    {
        private GameObject _saw;
        private float _timer;
        private Ball _empoweredBall;
        private readonly Vector2 _spawnMin = new Vector2(-8f, -4f);
        private readonly Vector2 _spawnMax = new Vector2(8f, 4f);

        public void Update(float dt, List<Ball> balls)
        {
            if (_saw == null)
            {
                _timer -= dt;
                if (_timer <= 0f)
                    Spawn();
            }
            else
            {
                Vector2 pos = _saw.transform.position;
                foreach (var ball in balls)
                {
                    Vector2 bpos = ball.Transform.position;
                    if (Vector2.Distance(pos, bpos) < 0.5f)
                    {
                        Pickup(ball);
                        break;
                    }
                }
            }
        }

        private void Spawn()
        {
            _saw = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            _saw.name = "Saw";
            Vector2 position = new Vector2(
                Random.Range(_spawnMin.x, _spawnMax.x),
                Random.Range(_spawnMin.y, _spawnMax.y));
            _saw.transform.position = new Vector3(position.x, position.y, 0f);
        }

        private void Pickup(Ball ball)
        {
            if (_empoweredBall != null)
                _empoweredBall.SetEmpowered(false);

            _empoweredBall = ball;
            _empoweredBall.SetEmpowered(true);

            if (_saw != null)
            {
                Object.Destroy(_saw);
                _saw = null;
            }

            _timer = 5f; // respawn delay
        }

        public void ClearPower()
        {
            if (_empoweredBall != null)
            {
                _empoweredBall.SetEmpowered(false);
                _empoweredBall = null;
            }
        }
    }
}
