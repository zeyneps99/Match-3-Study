using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [SerializeField] private GameObject _objectPrefab;
    private Queue<GameObject> _pool = new Queue<GameObject>();
    private const int _amountToPool = 10;
    public GameObject Get()
    {
        if (_pool.Count == 0)
        {
            Add(_amountToPool);
        }
        return _pool.Dequeue();
    }

    public void Put(GameObject go)
    {
        go.SetActive(false);
        _pool.Enqueue(go);
        
    }

    public void Add(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(_objectPrefab);
            go.SetActive(true);
            _pool.Enqueue(go);
        }
    }
}
