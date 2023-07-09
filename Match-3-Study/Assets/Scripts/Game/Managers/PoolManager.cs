using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    private ObjectPool<GenericCube> _genericCubePool = new ObjectPool<GenericCube>();
    private ObjectPool<BalloonCube> _balloonCubePool = new ObjectPool<BalloonCube>();


    public void CreatePoolInstance(GameObject prefab)
    {
        if (prefab.TryGetComponent(out Cube cube))
        {
            if (cube is GenericCube)
            {
                _genericCubePool.CreateInstance(prefab);
            }
            else if (cube is BalloonCube)
            {
                _balloonCubePool.CreateInstance(prefab);
            }
        }
    }

    public Cube GetPooledObject(CubeTypes type)
    {
        switch (type)
        {
            case CubeTypes.Yellow:
            case CubeTypes.Blue:
            case CubeTypes.Green:
            case CubeTypes.Red:
            case CubeTypes.Purple:
                return _genericCubePool.Get();
            case CubeTypes.Balloon:
                return _balloonCubePool.Get();
            default:
                return null;
        }

    }

    public void ReturnToPool(Cube cube)
    {
        switch (cube.Type)
        {
            case CubeTypes.Yellow:
            case CubeTypes.Blue:
            case CubeTypes.Green:
            case CubeTypes.Red:
            case CubeTypes.Purple:
                _genericCubePool.Put((GenericCube)cube);
                break;
            case CubeTypes.Balloon:
                _balloonCubePool.Put((BalloonCube)cube);
                break;
            default:
                break;
        }
    }

}
