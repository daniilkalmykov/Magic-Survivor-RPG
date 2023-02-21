using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ChuckPool : MonoBehaviour
{
    private readonly Dictionary<GridObject, Vector3Int> _pool = new();

    protected void Init(GridObject gridObject, Vector3 spawnPoint, Vector3Int gridPosition)
    {
        var newGridObject = Instantiate(gridObject, spawnPoint, Quaternion.identity);
        newGridObject.gameObject.SetActive(false);
        newGridObject.transform.SetParent(transform);

        _pool.Add(newGridObject, gridPosition);
    }

    protected bool TryGetGridObject(out GridObject gridObject)
    {
        gridObject = _pool.Keys.FirstOrDefault(result => result.gameObject.activeSelf == false);

        return gridObject != null;
    }

    protected Dictionary<GridObject, Vector3Int> GetGridObjectsPool()
    {
        return _pool;
    }

    protected void SetNewGridPosition(GridObject gridObject, Vector3Int gridObjectPosition)
    {
        if (_pool.Keys.FirstOrDefault(result => result == gridObject) == null)
            throw new ArgumentNullException();
        
        _pool[gridObject] = gridObjectPosition;
    }
}