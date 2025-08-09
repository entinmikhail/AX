using System.Collections;
using UnityEngine;

namespace Game.Gameplay
{
    public class SawSpawner : MonoBehaviour
    {
        public static SawSpawner Instance { get; private set; }

        [SerializeField] private GameObject _sawPrefab;
        [SerializeField] private Vector2 _spawnAreaMin;
        [SerializeField] private Vector2 _spawnAreaMax;

        private GameObject _currentSaw;
        private Ball _empoweredBall;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            SpawnSaw();
        }

        private void SpawnSaw()
        {
            Vector2 position = new Vector2(Random.Range(_spawnAreaMin.x, _spawnAreaMax.x),
                Random.Range(_spawnAreaMin.y, _spawnAreaMax.y));
            _currentSaw = Instantiate(_sawPrefab, position, Quaternion.identity);
        }

        public void Pickup(Ball ball)
        {
            if (_empoweredBall != null)
            {
                _empoweredBall.SetEmpowered(false);
            }

            _empoweredBall = ball;
            _empoweredBall.SetEmpowered(true);

            if (_currentSaw != null)
            {
                Destroy(_currentSaw);
                _currentSaw = null;
            }

            StartCoroutine(Respawn());
        }

        private IEnumerator Respawn()
        {
            yield return new WaitForSeconds(5f);
            SpawnSaw();
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
