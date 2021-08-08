using UnityEngine;
using UnityEngine.Events;
public class WayPoint : MonoBehaviour
{
    [SerializeField] private UnityEvent _onPoint;
    public UnityEvent OnPoint => _onPoint;
    public Vector3 Position => transform.position;
    public Quaternion Rotation => transform.rotation;
}
