using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animations))]
[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private Vector2 _moveVector;
    private bool _faceRight = true;
    private Animations _animatons;
    private Player _player;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animatons = GetComponent<Animations>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Walk();
        Reflect();
        Jump();
    }

    private void Walk()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _animatons.AnimWalk(_moveVector);
        _rigidbody.velocity = new Vector2(_moveVector.x * _player.Speed, _rigidbody.velocity.y);
    }

    private void Reflect()
    {
        if ((_moveVector.x > 0 && !_faceRight) || (_moveVector.x < 0 && _faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            _faceRight = !_faceRight;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _player.Jump);
            _animatons.AnimJump();
        }
    }
}
