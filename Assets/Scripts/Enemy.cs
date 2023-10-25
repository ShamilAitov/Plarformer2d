using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;

    private float _maxHealth;
    private float _minHealth;

    public float Damage => _damage;
    public float Speed => _speed;

    private void Start()
    {
        _maxHealth = _health;
        _slider.maxValue = _maxHealth;
        _slider.value = _health;
    }

    public void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth);
        _slider.value = _health;
    }
}
