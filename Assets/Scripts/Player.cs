using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [SerializeField] private float _health;
    [SerializeField] private float _damage;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private float _maxHealth;
    private float _minHealth = 0;

    public float Damage => _damage;
    public float Health => _health;
    public float Speed => _speed;
    public float Jump => _jump;

    private void Start()
    {
        _maxHealth = _health;
        _slider.maxValue = _maxHealth;
        _slider.value = _health;
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
}
