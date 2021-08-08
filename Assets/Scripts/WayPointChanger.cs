using System.Collections.Generic;
using UnityEngine;
public class WayPointChanger : MonoBehaviour
{
    [SerializeField] private List<WayPoint> _wayPoints;
    [SerializeField] private int _rotationFrames;
    public WayPoint CurrentWayPoint=>_wayPoints[_index];
    private int _index=-1;
    private Coroutine _coroutine;
    private void UpdateWayPoint()
    {
        _index++;
        if (_index >= _wayPoints.Count)
        {
            _index = 0;
        }
    }
    public void MoveToWayPoint(Transform objectTransform,float moveSpeed)
    { 
        UpdateWayPoint();
        StartCoroutine(CoroutinesKid.ChangePosition(objectTransform,
            CurrentWayPoint.Position, moveSpeed, ()=>
            {
                //StartCoroutine(CoroutinesKid.Rotate(objectTransform, CurrentWayPoint.Axis,CurrentWayPoint.Angle,_rotationFrames));
                objectTransform.rotation = CurrentWayPoint.Rotation;
                CurrentWayPoint.OnPoint?.Invoke();
            }));
    }
}
