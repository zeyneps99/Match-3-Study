using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Commander))]
public class Entity : MonoBehaviour, IEntity
{
    private Commander _commander;

    private void Awake()
    {
        _commander = GetComponent<Commander>();
    }

}
