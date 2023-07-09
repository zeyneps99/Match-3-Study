using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputHelper : MonoBehaviour
{
    private Commander _commander;
    private IEntity _entity;

    private TapCommand _touchCommand;

    private void Awake()
    {
        _commander = GetComponent<Commander>();
        _entity = GetComponent<IEntity>();
    }
   
    public void OnTouch(BaseEventData data)
    {
        if (_commander != null && _entity != null)
        {
            _touchCommand = new TapCommand(_entity, transform.position);
            _commander.ExecuteCommand(_touchCommand);
        }
    }

   
}
