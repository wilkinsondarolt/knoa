using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ProjectileObject
{	
	protected override void Update()
    {
        StartCoroutine(Move(1f * Velocity * Time.deltaTime, 0.1f * Velocity * Time.deltaTime));	
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
            collision.gameObject.SendMessage("TakeDamage", this.Damage);
    }
}
