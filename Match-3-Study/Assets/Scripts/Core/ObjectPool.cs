using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    private Queue<T> _pool = new Queue<T>();
    public const int _amount = 10;

    public void CreateInstance(GameObject go)
    {
        if (go != null && go.TryGetComponent<T>(out var comp))
        {
            _objectPrefab = go;
        }
    }
    public T Get()
    {
        if (_pool.Count == 0)
        {
            Add(_amount);
        }
        return _pool.Dequeue();
    }

    public void Put(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
        
    }

    public void Add(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(_objectPrefab);
            go.SetActive(true);
            _pool.Enqueue(go.GetComponent<T>());
        }
    }
}
