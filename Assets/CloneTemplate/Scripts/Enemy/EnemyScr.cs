using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyScr : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _rewads;

    [SerializeField] private Player _target;

    public event UnityAction Dying;

    public Player Target => _target;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

}