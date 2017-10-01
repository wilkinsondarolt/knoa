using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObject : MovingObject
{
    public int curHealth;
    public int maxHealth = 100;
    protected Animator AnimControl;

    protected override void Start()
    {
        AnimControl = GetComponent<Animator>();
        curHealth = maxHealth;
    }

    protected override void Update()
    {
       
    }

    protected void TakeDamage(int Damage)
    {
        curHealth -= Damage;
        CheckIsDead();
    }

    protected void CheckIsDead()
    {
        if (curHealth <= 0)
            OnDie();
    }

    protected virtual void OnDie()
    {

    }
}
