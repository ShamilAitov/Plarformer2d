using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction <Coin> Collected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            Collected?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
