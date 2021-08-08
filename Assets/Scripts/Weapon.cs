using System;
using DefaultNamespace;
using UnityEngine;
public class Weapon : MonoBehaviour
{
   [SerializeField] private float _bulletSpeed;
   [SerializeField] private Transform _ShootPoint;
   [SerializeField] private GameObject _bullet;
   [SerializeField] private ParticleSystem _shootParticle;
   [SerializeField] private float _shootDelay;
   private ActorData _actorData;
   private Timer _shootTimer;
   private void Start()
   {
      _shootTimer = new Timer();
      ManagerPool.Instance.Dispose();
      ManagerPool.Instance.AddPool(PoolType.Entities).PopulateWith(_bullet, 10);
      _actorData = GetComponent<ActorData>();
   }

   private void Update()
   {
      _shootTimer.UpdateTimer();
   }

   public void Shoot(Vector3 endPoint)
   {
      if (_shootTimer.IsTick) return;
      _actorData.ActorAnimator.Play(_actorData.Shoot);
      _shootTimer.StartTimer(_shootDelay,null);
      _shootParticle.Play();
      ManagerPool.Instance.Spawn<Bullet>(PoolType.Entities, _bullet, _ShootPoint.position).SetDirection(endPoint);
   }
}
