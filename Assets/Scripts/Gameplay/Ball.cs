using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Ball : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        private Rigidbody2D _rigidbody;
        private bool _empowered;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Vector2 direction = Random.insideUnitCircle.normalized;
            _rigidbody.velocity = direction * _speed;
        }

        public void SetEmpowered(bool value)
        {
            _empowered = value;
        }

        public void TakeHit()
        {
            Debug.Log(name + " was hit");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Vector2 reflected = Vector2.Reflect(_rigidbody.velocity, collision.contacts[0].normal);
            _rigidbody.velocity = reflected;

            Ball other = collision.collider.GetComponent<Ball>();
            if (other != null && _empowered)
            {
                other.TakeHit();
                SawSpawner.Instance.ClearPower();
            }
        }
    }
}
