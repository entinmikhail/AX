using UnityEngine;

namespace Game.Core
{
    /// <summary>
    /// Logical representation of a ball. Does not derive from MonoBehaviour.
    /// </summary>
    public class Ball
    {
        private readonly Transform _transform;
        private Vector2 _velocity;
        private bool _empowered;
        private const float Radius = 0.5f;

        public Transform Transform => _transform;

        public Ball(Transform transform, Vector2 velocity)
        {
            _transform = transform;
            _velocity = velocity;
        }

        public void Update(float dt)
        {
            var pos = (Vector2)_transform.position;
            pos += _velocity * dt;

            // simple screen bounds
            if (pos.x < -10f || pos.x > 10f)
            {
                _velocity.x = -_velocity.x;
            }
            if (pos.y < -5f || pos.y > 5f)
            {
                _velocity.y = -_velocity.y;
            }

            _transform.position = new Vector3(pos.x, pos.y, 0f);
        }

        public void HandleCollision(Ball other, SawSpawner spawner)
        {
            var pos = (Vector2)_transform.position;
            var otherPos = (Vector2)other._transform.position;
            float distance = Vector2.Distance(pos, otherPos);
            if (distance < Radius * 2f)
            {
                var normal = (pos - otherPos).normalized;
                _velocity = Vector2.Reflect(_velocity, normal);
                other._velocity = Vector2.Reflect(other._velocity, -normal);

                if (_empowered)
                {
                    other.TakeHit();
                    spawner.ClearPower();
                }
                else if (other._empowered)
                {
                    TakeHit();
                    spawner.ClearPower();
                }
            }
        }

        public void SetEmpowered(bool value)
        {
            _empowered = value;
        }

        public void TakeHit()
        {
            Debug.Log(_transform.name + " was hit");
        }
    }
}
