using System;
using System.Collections;
using UnityEngine;
public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private int _frames;
    [SerializeField] private Vector3 _upPosition;
    private Vector3 _originPosition;
    private void Start()
    {
        _originPosition = transform.position;
        StartCoroutine(Move());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) StopMove();
    }

    private IEnumerator Move()
    {
        while (true)
        {
            var delta = (_upPosition - transform.position)/_frames;
            for (int i = 0; i < _frames; i++)
            {
                transform.position += delta;
                yield return null;
            }

            delta = (_originPosition - transform.position)/_frames;
            for (int i = 0; i < _frames; i++)
            {
                transform.position += delta;
                yield return null;
            }
        }
    }

    public void StopMove()
    {
        StopAllCoroutines();
        transform.position = _originPosition;
    }
}
