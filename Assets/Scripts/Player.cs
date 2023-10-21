using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _attackDistance;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayers;

    private Rigidbody2D _rigidbody;
    private Vector2 _moveVector;
    private Animator _animator;
    private bool _faceRight = true;
    private int _animSpeed = Animator.StringToHash("Speed");
    private int _animJump = Animator.StringToHash("Jump");
    private int _animAttack = Animator.StringToHash("Attack");
    private float _maxHealth;
    private float _minHealth = 0;

    public float Damage => _damage;
    public float Health => _health;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _maxHealth = _health;
        _slider.maxValue = _maxHealth;
        _slider.value = _health;
    }

    private void Update()
    {
        Walk();
        Reflect();
        Jump();
        Attack();
    }

    public void IncreaseHealth(float firstAidKit)
    {
        _health = Mathf.Clamp(_health + firstAidKit, _minHealth, _maxHealth);
        _slider.value = _health;
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        _slider.value = _health;
    }

    private void Walk()
    {
        _moveVector.x = Input.GetAxis("Horizontal");
        _animator.SetFloat(_animSpeed, Mathf.Abs(_moveVector.x));
        _rigidbody.velocity = new Vector2(_moveVector.x * _speed, _rigidbody.velocity.y);
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
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jump);
            _animator.SetTrigger(_animJump);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.SetTrigger(_animAttack);

            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackDistance.position, _attackRange, _enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(_damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackDistance == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(_attackDistance.position, _attackRange);
    }
}
