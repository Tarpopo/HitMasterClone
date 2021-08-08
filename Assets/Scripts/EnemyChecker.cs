using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyChecker : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemies;
    [SerializeField] private UnityEvent _onEnemiesEnd;
    public event UnityAction OnEnemiesEnd
    {
        add => _onEnemiesEnd.AddListener(value);
        remove => _onEnemiesEnd.RemoveListener(value);
    }
    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
        if(_enemies.Count==0) _onEnemiesEnd?.Invoke();    
    }

}
