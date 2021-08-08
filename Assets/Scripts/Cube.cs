using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _cubeRotateSpeed;
    [SerializeField] private List<Axis> _axis;
    [SerializeField] private Transform _parentAxis;
    [SerializeField] private int _rotationFrames;
    private Axis _occupiedAxis;
    private AxisType _type;
    
    private void Start()
    {
        _type = (AxisType)Random.Range(0,2);
        RotateAxis(Random.Range(0,3));
        StartCoroutine(CoroutinesKid.AlwaysRotate(transform, Vector3.up, _cubeRotateSpeed));
    }

    public void SetActiveType(int type)
    {
        _type = (AxisType)type;
    }

    public void RotateAxis(int index = 0)
    {
        ResetRotation();
        var rotation = _type == AxisType.Horizontal ? new Vector3(0, 90, 0) : new Vector3(90, 0, 0);
        rotation *= Math.Sign(index);
        FreeAxis();
        _occupiedAxis = _axis.Where(elem => elem.Type == _type).ElementAt(Math.Abs(index));
        SetParentToAxes(_occupiedAxis);
        StartCoroutine(CoroutinesKid.EulerRotate(_parentAxis, rotation,_rotationFrames));
    }

    public void ResetRotation()
    {
        StopAllCoroutines();
        transform.rotation=Quaternion.identity;
        _parentAxis.rotation = Quaternion.identity;
    }

    private void FreeAxis()
    {
        if (_occupiedAxis == null) return;
        foreach (var element in _occupiedAxis.AxisObjects)
        {
            element.SetParent(transform);
        }
    }
    private void SetParentToAxes(Axis axis)
    {
        foreach (var element in axis.AxisObjects)
        {
            element.SetParent(_parentAxis);
        }
    }
}
[Serializable]
public class Axis
{
    public AxisType Type;
    public List<Transform> AxisObjects;
}

public enum AxisType
{
    Horizontal,
    Vertical
}