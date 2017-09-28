using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IunaController : MovingObject
{
    private Audio audioControl;
    private PoolManager arrowPool;
	public int curHealth;
	public int maxHealth = 100;

    private void Start()
    {
        audioControl = GameObject.FindGameObjectWithTag("EditorOnly").GetComponent<Audio>();
        arrowPool = GetComponent<PoolManager>();

		curHealth = maxHealth;
    }


    void Update ()
    {
        StartCoroutine(Move(Input.GetAxisRaw("Horizontal") * Velocity * Time.deltaTime, Input.GetAxisRaw("Vertical") * Velocity * Time.deltaTime));

        if (Input.GetButtonDown("Fire1"))
        {
            arrowPool.ReuseObject(transform.position, Quaternion.identity);
            audioControl.PlayArrow();             
        }
    }

    void Attack()
    {
        // Do the attack animation and create a projectile
    }

	void Die()

	{

	}
}
