using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IunaController : LivingObject
{
    private Pause pauseControl;
    private Audio audioControl;
    private PoolManager arrowPool;
    private bool CanShoot;
    public float WeaponCooldownTime = 1.0f;

    protected override void Start()
    {
        base.Start();
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        audioControl = GameController.GetComponent<Audio>();
        pauseControl = GameController.GetComponent<Pause>();
        arrowPool = GetComponent<PoolManager>();
		curHealth = maxHealth;
        CanShoot = true;
    }
    
    protected override void Update ()
    {
        base.Update();
        if (!pauseControl.Paused)
        {
            StartCoroutine(Move(Input.GetAxisRaw("Horizontal") * Velocity * Time.deltaTime, Input.GetAxisRaw("Vertical") * Velocity * Time.deltaTime));

            if (Input.GetButton("Fire1") && CanShoot)
            {
                CanShoot = false;
                AnimControl.SetTrigger("Attack");
                Invoke("Attack", 1.0f);
            }                      
        }        
    }

    private void Attack()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        float angle = AngleBetweenPoints(mouseWorldPosition, transform.position);

        
        arrowPool.ReuseObject(transform.localPosition, Quaternion.Euler(-36f, 0f, angle));
        audioControl.PlayArrow();
        Invoke("ActivateShoot", WeaponCooldownTime);
    }

    private void ActivateShoot()
    {
        CanShoot = true;
    }
}
