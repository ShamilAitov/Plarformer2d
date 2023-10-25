using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Transform _attackDistance;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _playerLayers;

    private Transform _target;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(_attackDistance.position, _attackRange, _playerLayers);

        foreach (Collider2D player in hitPlayers)
        {
            player.GetComponent<Player>().TakeDamage(_enemy.Damage);
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
