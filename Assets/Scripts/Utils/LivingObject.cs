using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingObject : MovingObject
{
    public int curHealth;
    public int maxHealth = 100;

    protected override void Start()
    {
        curHealth = maxHealth;
    }

    protected override void Update()
    {
       
    }

    protected void TakeDamage(int Damage)
    {
        Damage -= Damage;
        CheckIsDead();
    }

    protected void CheckIsDead()
    {
        if (curHealth <= 0)
            OnDie();
    }

    private void OnDie()
    {

    }
}
