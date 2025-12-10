using System;
using UnityEditor;
using UnityEngine;

public class Health : MonoBehaviour, IDamageble
{
    public event Action OnDeath;
    public event Action<float> OnDamage;
    public float maxHealth = 3f;

    private float currentHp;

    public void Start()
    {
        currentHp = maxHealth;
    }

    public void TakeDamage(float amount)
    {

        currentHp -= amount;
        OnDamage?.Invoke(amount);
        if (currentHp <= 0)
        {
            OnDeath?.Invoke();
            
            
        }
    }

}