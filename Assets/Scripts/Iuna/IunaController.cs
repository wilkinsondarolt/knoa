using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IunaController : MovingObject
{


	void Update ()
    {
        StartCoroutine(Move(Input.GetAxisRaw("Horizontal") * Velocity * Time.deltaTime, Input.GetAxisRaw("Vertical") * Velocity * Time.deltaTime));
    }

    void Attack()
    {
        // Do the attack animation and create a projectile
    }
}
