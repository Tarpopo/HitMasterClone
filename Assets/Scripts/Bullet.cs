using DefaultNamespace;
using UnityEngine;
public class Bullet : MonoBehaviour,IPoolable
{
    [SerializeField] private float _time;
    [SerializeField] private float _speed;
    private Timer _bulletTimer;
    private Vector3 _endPoint;
    private void Awake()
    {
        _bulletTimer = new Timer();
    }
    private void Update()
    {
        _bulletTimer.UpdateTimer();
        if (_bulletTimer.IsTick==false) return;
        transform.position = Vector3.MoveTowards(transform.position,_endPoint,_speed*Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageable damageable))damageable.TakeDamage();
        ManagerPool.Instance.Despawn(PoolType.Entities,gameObject);
    }

    public void SetDirection(Vector3 point)
    {
        _endPoint = point;
    }

    public void OnSpawn()
    {
        _bulletTimer.StartTimer(_time, () =>
        {
            ManagerPool.Instance.Despawn(PoolType.Entities,gameObject);
        });
    }
    public void OnDespawn() { }
}
