using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _paht;
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    [SerializeField] private Transform _attackDistance;
    [SerializeField] private Transform _visibilityDistance;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _visibilityRange;
    [SerializeField] private LayerMask _playerLayers;

    private Transform[] _points;
    private int _currentPoint;
    private float _maxHealth;
    private float _minHealth;
    private Transform _target;

    public float Damage => _damage;

    private void Start()
    {
        _maxHealth = _health;
        _slider.maxValue = _maxHealth;
        _slider.value = _health;
        _points = new Transform[_paht.childCount];

        for (int i = 0; i < _paht.childCount; i++)
        {
            _points[i] = _paht.GetChild(i);
        }
    }

    private void Update()
    {
        Attack();
        Move();
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        _slider.value = _health;
    }

    private void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_attackDistance.position, _attackRange, _playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().TakeDamage(_damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackDistance == null && _visibilityDistance == null)
        {
            return;
        }
        else if (_attackDistance == null)
        {
            Gizmos.DrawWireSphere(_visibilityDistance.position, _visibilityRange);
        }
        else if (_visibilityDistance == null)
        {
            Gizmos.DrawWireSphere(_attackDistance.position, _attackRange);
        }
        else
        {
            Gizmos.DrawWireSphere(_visibilityDistance.position, _visibilityRange);
            Gizmos.DrawWireSphere(_attackDistance.position, _attackRange);
        }
    }

    private void Move()
    {
        _target = _points[_currentPoint];
        Pursue();

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void Pursue()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_visibilityDistance.position, _visibilityRange, _playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            _target = player.GetComponent<Player>().transform;
        }
    }
}
