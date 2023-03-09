using System.Collections.Generic;
using System.Linq;
using Infrastructure;
using UnityEngine;

namespace GameLogic
{
    public abstract class EnvironmentPool : MonoBehaviour
    {
        private readonly Dictionary<EnvironmentObject, Vector3> _pool = new();

        protected void Init(EnvironmentObject environmentObject, Transform parent, Transform player, float distance)
        {
            var newEnvironmentObject = Instantiate(environmentObject, Vector3.zero, Quaternion.identity, parent);
            newEnvironmentObject.gameObject.SetActive(false);
            newEnvironmentObject.Init(player, distance);

            _pool.Add(newEnvironmentObject, Vector3.zero);
        }

        protected bool TryGetRandomEnvironmentObject(out EnvironmentObject environmentObject)
        {
            environmentObject = _pool.Keys.FirstOrDefault(result => result.gameObject.activeSelf == false);

            return environmentObject != null;
        }

        protected bool HasPosition(Vector3 position)
        {
            return _pool.Values.Contains(position);
        }

        protected void SetNewPosition(EnvironmentObject environmentObject, Vector3 position)
        {
            if (environmentObject == null)
                return;

            environmentObject.transform.position = position;
            _pool[environmentObject] = position;
        }
    }
}