using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaraController : MovingObject
{
    private GameObject Iuna;

    private void Start()
    {
        Iuna = GameObject.FindGameObjectWithTag("Player");
    }

    void Update ()
    {
        StartCoroutine(MoveTowards(Iuna.transform.position));
    }
}