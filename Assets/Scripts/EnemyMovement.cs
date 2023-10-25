using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _visibilityDistance;
    [SerializeField] private float _visibilityRange;
    [SerializeField] private Transform _paht;
    [SerializeField] private LayerMask _playerLayers;

    private Transform _target;
    private Transform[] _points;
    private int _currentPoint;
    private Enemy _enemy;

    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _points = new Transform[_paht.childCount];

        for (int i = 0; i < _paht.childCount; i++)
        {
            _points[i] = _paht.GetChild(i);
        }
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _target = _points[_currentPoint];
        Pursue();

        transform.position = Vector2.MoveTowards(transform.position, _target.position, _enemy.Speed * Time.deltaTime);

        if (transform.position == _target.position)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    public void Pursue()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_visibilityDistance.position, _visibilityRange, _playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            _target = player.GetComponent<Player>().transform;
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (_visibilityDistance == null)
        {
            return;
        }
        
        Gizmos.DrawWireSphere(_visibilityDistance.position, _visibilityRange);
    }
}
