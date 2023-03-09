using UnityEngine;

namespace Infrastructure
{
    public sealed class EnvironmentObject : MonoBehaviour
    {
        private Transform _player;
        private float _distance;
        
        private void Update()
        {
            if (Vector3.Distance(transform.position, _player.position) >= _distance)
                gameObject.SetActive(false);
        }

        public void Init(Transform player, float distance)
        {
            _player = player;
            _distance = distance;
        }
    }
}