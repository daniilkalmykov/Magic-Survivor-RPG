using Player;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    [SerializeField] private GridLayer _gridLayer;
    [SerializeField] private int _chanceToCreate;

    public GridLayer GridLayer => _gridLayer;
    public int ChanceToCreate => _chanceToCreate;

    private void OnValidate()
    {
        const int MaxChanceToCreate = 100;
        const int MinChanceToCreate = 1;
        
        _chanceToCreate = Mathf.Clamp(_chanceToCreate, MinChanceToCreate, MaxChanceToCreate);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerMovement playerMovement))
            print("Blkasdfjkgyhiadfugh");            
    }
}

public enum GridLayer
{
    Ground,
    OnGround
}
