using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _player;

    private Vector3 _offence;
    private Vector3 _playerPosition;
    private Vector3 _cameraPosition;
    
    private void Start()
    {
        _playerPosition = _player.position;
        _cameraPosition = transform.position;
        
        _offence = new Vector3(_cameraPosition.x - _playerPosition.x, 0, _cameraPosition.z - _playerPosition.z);
    }

    private void LateUpdate()
    {
        _playerPosition = _player.position;
        _cameraPosition = transform.position;

        _cameraPosition = new Vector3(_playerPosition.x + _offence.x, _cameraPosition.y,
            _playerPosition.z + _offence.z);

        transform.position = _cameraPosition;
    }
}
