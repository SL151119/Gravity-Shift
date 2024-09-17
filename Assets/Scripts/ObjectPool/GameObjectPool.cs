using System.Collections.Generic;
using UnityEngine;

public class GameObjectPool : IObjectPool<GameObject>
{
    private readonly Queue<GameObject> _objectPool;
    private readonly GameObject _prefab;
    private readonly Transform _parentTransform;

    public GameObjectPool(GameObject prefab, int initialSize, Transform parentTransform)
    {
        _prefab = prefab;
        _parentTransform = parentTransform;
        _objectPool = new Queue<GameObject>();

        PreloadObjects(initialSize);
    }

    private void PreloadObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject obj = CreateNewObject();
            _objectPool.Enqueue(obj);
        }
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = GameObject.Instantiate(_prefab, _parentTransform);
        obj.SetActive(false);
        return obj;
    }

    public GameObject Get()
    {
        if (_objectPool.Count > 0)
        {
            GameObject obj = _objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            return CreateNewObject();
        }
    }

    public void Release(GameObject obj)
    {
        obj.SetActive(false);
        _objectPool.Enqueue(obj);
    }
}