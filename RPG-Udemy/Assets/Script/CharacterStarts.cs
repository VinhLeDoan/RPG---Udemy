using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStarts : MonoBehaviour
{

    public Start strength;
    public Start maxHealth;
    public Start damage;
    

    [SerializeField] private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHealth.GetValue();

       
    }

    public virtual void DoDamage(CharacterStarts _targetStarts)
    {
        int totalDamage = damage.GetValue() + strength.GetValue();
        _targetStarts.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        Debug.Log(_damage);

        if (currentHealth < 0)
            Die();
    }

    protected virtual void Die()
    {
        //throw new NotImplementedException();
    }
}
