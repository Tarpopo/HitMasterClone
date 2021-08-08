using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorData : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private AnimationClip _idle;
    [SerializeField] private AnimationClip _run;
    [SerializeField] private AnimationClip _shoot;
    [SerializeField] private AnimationClip _death;
    private Animator _animator;
    public string Idle => _idle.name;
    public string Run => _run.name;
    public string Shoot => _shoot.name;
    public string Death => _death.name;
    public float MoveSpeed => _moveSpeed;
    public Animator ActorAnimator => _animator;
    private void Awake()
    {
        TryGetComponent<Animator>(out _animator);
    }
}
