using UnityEngine;

public sealed class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _playerPosition;
    private Vector3 _position;
    private Vector3 _offence;
    
    private void Start()
    {
        _playerPosition = _player.position;
        _position = transform.position;
        
        _offence = new Vector3(_position.x - _playerPosition.x, 0, _position.z - _playerPosition.z);
    }

    private void LateUpdate()
    {
        _playerPosition = _player.position;
        _position = transform.position;

        _position = new Vector3(_playerPosition.x + _offence.x, _position.y,
            _playerPosition.z + _offence.z);

        transform.position = _position;
    }
}
