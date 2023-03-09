using Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameLogic
{
    public sealed class EnvironmentGenerator : EnvironmentPool
    {
        private const float YSpawnPosition = 0.5f;
        
        [SerializeField] private EnvironmentObject[] _environmentObjects;
        [SerializeField] private Transform _player;
        [SerializeField] private int _viewRadius;
        [SerializeField] private int _count;
        
        private void Awake()
        {
            for (var i = 0; i < _count; i++)
            {
                int environmentObjectIndex;

                if (i < _environmentObjects.Length)
                    environmentObjectIndex = i;
                else
                    environmentObjectIndex = i % _environmentObjects.Length;                    
                
                Init(_environmentObjects[environmentObjectIndex], transform, _player, _viewRadius);
            }
        }

        private void Update()
        {
            FillArea();
        }

        private void FillArea()
        {
            var playerPosition = _player.position;
            
            var randomXPosition = Random.Range(-_viewRadius - playerPosition.x, _viewRadius + playerPosition.z);
            var randomZPosition = Random.Range(-_viewRadius - playerPosition.z, _viewRadius + playerPosition.z);

            var position = new Vector3(randomXPosition, YSpawnPosition, randomZPosition);

            if (HasPosition(position))
                return;

            if (TryGetRandomEnvironmentObject(out var environmentObject) == false)
                return;
            
            SetNewPosition(environmentObject, position);
            environmentObject.gameObject.SetActive(true);
        }
    }
}
