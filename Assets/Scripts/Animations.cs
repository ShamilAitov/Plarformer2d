using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Animations : MonoBehaviour
{
    private Animator _animator;
    private int _animSpeed = Animator.StringToHash("Speed");
    private int _animJump = Animator.StringToHash("Jump");
    private int _animAttack = Animator.StringToHash("Attack");

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimWalk(Vector2 moveVector)
    {
        _animator.SetFloat(_animSpeed, Mathf.Abs(moveVector.x));
    }

    public void AnimJump()
    {
        _animator.SetTrigger(_animJump);
    }

    public void AnimAttack()
    {
        _animator.SetTrigger(_animAttack);
    }

}
