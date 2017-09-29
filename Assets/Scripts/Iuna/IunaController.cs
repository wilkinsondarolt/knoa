using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IunaController : LivingObject
{
    private Pause pauseControl;
    private Audio audioControl;
    private PoolManager arrowPool;
    private bool CanShoot;
    private float CooldownTime = 1.0f;

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

            if (Input.GetButtonDown("Fire1") && CanShoot)            
                Attack();
        }        
    }

    private void Attack()
    {
        CanShoot = false;
        arrowPool.ReuseObject(transform.localPosition, Quaternion.Euler(-36f, 0f, 45f));
        audioControl.PlayArrow();
        Invoke("ActivateShoot", CooldownTime);
    }

    private void ActivateShoot()
    {
        CanShoot = true;
    }
}
