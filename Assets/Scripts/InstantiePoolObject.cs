using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class InstantiePoolObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    private List<GameObject> _pool = new List<GameObject>();
    private GameObject GetObject()
    {
        foreach (var obj in _pool)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }

        var newObj = Instantiate(_prefab);
        _pool.Add(newObj);
        return newObj;
    }

    public void InstantiateObject(Transform target)
    {

        var obj = GetObject();
        obj.transform.SetPositionAndRotation(target.position, target.rotation);
        obj.SetActive(true);

    }
}
