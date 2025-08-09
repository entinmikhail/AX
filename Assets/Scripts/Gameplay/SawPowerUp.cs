using UnityEngine;

namespace Game.Gameplay
{
    public class SawPowerUp : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Ball ball = other.GetComponent<Ball>();
            if (ball != null)
            {
                SawSpawner.Instance.Pickup(ball);
            }
        }
    }
}
