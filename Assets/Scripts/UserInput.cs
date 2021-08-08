using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserInput : MonoBehaviour
{
    [SerializeField] private UnityEvent<Vector2> _onTouch;
    public event UnityAction<Vector2> OnTouch
    {
        add => _onTouch.AddListener(value);
        remove => _onTouch.RemoveListener(value);
    }

    private void Update()
    {
        // if (Input.touchCount > 0)
        // {
        //     _onTouch?.Invoke(Input.GetTouch(0).position);
        // }
        if (Input.GetMouseButtonDown(0))
        {
            _onTouch?.Invoke(Input.mousePosition);
        }
    }
}
