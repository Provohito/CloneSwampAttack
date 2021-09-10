using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] public List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;
    private Animator _animator;
    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;


    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
            Destroy(gameObject);
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
        Debug.Log("saddsadsa");
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        Debug.Log("rew");
        _weapons.Add(weapon);
    }
}
