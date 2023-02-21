using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : ChuckPool
{
    [SerializeField] private Transform _player;
    [SerializeField] private GridObject[] _gridObjects;
    [SerializeField] private int _cellSize;
    [SerializeField] private int _viewRadius;
    
    private void Start()
    {
        InitGridObjects(GridLayer.Ground);
        InitGridObjects(GridLayer.OnGround);
    }
    
    private void Update()
    {
        FillArea();
    }

    private void FillArea()
    {
        var cellsCountOnAxis = GetCellCountOnAxis();
        var fillAreaCenter = WorldPositionToGridPosition(_player.position);

        for (var x = -cellsCountOnAxis; x < cellsCountOnAxis; x++)
        {
            for (var z = -cellsCountOnAxis; z < cellsCountOnAxis; z++)
            {
                var gridPosition = fillAreaCenter + new Vector3Int(x, 0, z);
                
                TrySetGridObject(GridLayer.Ground, gridPosition);
                TrySetGridObject(GridLayer.OnGround, gridPosition);
            }
        }
    }

    private void InitGridObjects(GridLayer layer)
    {
        var cellsCountOnAxis = GetCellCountOnAxis();
        var fillAreaCenter = WorldPositionToGridPosition(_player.position);
        
        for (var x = -cellsCountOnAxis; x < cellsCountOnAxis; x++)
        {
            for (var z = -cellsCountOnAxis; z < cellsCountOnAxis; z++)
            {
                var gridObject = GetRandomGridObject(layer);
        
                if(gridObject == null)
                    return;
                
                var gridPosition = fillAreaCenter + new Vector3Int(x, 0, z);
                var position = GridPositionToWorldPosition(gridPosition);
                
                Init(gridObject, position, gridPosition);
            }
        }
    }
    
    private void TrySetGridObject(GridLayer layer, Vector3Int gridPosition)
    {
        const int GroundYPosition = 0;
        const int OnGroundYPosition = 1;
        
        gridPosition.y = layer == GridLayer.Ground ? GroundYPosition : OnGroundYPosition;

        if(GetGridObjectsPool().Values.Contains(gridPosition))
            return;

        if (TryGetGridObject(out var gridObject))
        {
            var gridObjectWorldPosition = GridPositionToWorldPosition(gridPosition);
            gridObject.transform.position = gridObjectWorldPosition;
            gridObject.gameObject.SetActive(true);
            
            SetNewGridPosition(gridObject, gridPosition);
        }
    }

    private GridObject GetRandomGridObject(GridLayer layer)
    {
        var gridObjects = _gridObjects.Where(obj => obj.GridLayer == layer).ToList();

        if (gridObjects.Count == 0)
            return null;

        foreach (var gridObject in gridObjects)
        {
            const int MinRandomChance = 0;
            const int MaxRandomChance = 100;
            
            if (gridObject.ChanceToCreate > Random.Range(MinRandomChance, MaxRandomChance))
                return gridObject;
        }

        return null;
    }
    
    private int GetCellCountOnAxis()
    {
        return Convert.ToInt32(_viewRadius / _cellSize);
    }

    private Vector3 GridPositionToWorldPosition(Vector3Int gridPosition)
    {
        return new Vector3(gridPosition.x * _cellSize, gridPosition.y * _cellSize, gridPosition.z * _cellSize);
    }

    private Vector3Int WorldPositionToGridPosition(Vector3 worldPosition)
    {
        var x = Convert.ToInt32(worldPosition.x / _cellSize);
        var y = Convert.ToInt32(worldPosition.y / _cellSize);
        var z = Convert.ToInt32(worldPosition.z / _cellSize);

        return new Vector3Int(x, y, z);
    }
}
