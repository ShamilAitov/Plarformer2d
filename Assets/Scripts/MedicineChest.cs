using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private float _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            player.IncreaseHealth(_health);
            Destroy(gameObject);
        }
    }
}
