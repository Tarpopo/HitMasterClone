using UnityEngine;
public class Enemy : MonoBehaviour,IDamageable
{
    [SerializeField] private ActorData _actorData;
    [SerializeField] private ParticleSystem _takeDamage;
    private EnemyChecker _enemyChecker;
    private Collider _collider;
    private void Start()
    {
        _enemyChecker = GetComponentInParent<EnemyChecker>();
        _actorData = GetComponent<ActorData>();
        _collider = GetComponent<Collider>();
    }
    public void TakeDamage(int damage = 0)
    {
        _collider.enabled = false;
        _enemyChecker.RemoveEnemy(this);
        _takeDamage.Play();
        _actorData.ActorAnimator.Play(_actorData.Death);
    }
}
