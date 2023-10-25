using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animations))]
[RequireComponent(typeof(Player))]
public class PlayerAttack : MonoBehaviour
{  
    [SerializeField] private Transform _attackDistance;
    [SerializeField] private float _attackRange;
    [SerializeField] private LayerMask _enemyLayers;

    private Animations _animatons;
    private Player _player;

    void Start()
    {
        _animatons = GetComponent<Animations>();
        _player = GetComponent<Player>();
    }

    void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animatons.AnimAttack();
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackDistance.position, _attackRange, _enemyLayers);

            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<Enemy>().TakeDamage(_player.Damage);
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
