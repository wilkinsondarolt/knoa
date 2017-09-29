using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IaraController : LivingObject
{
    private GameObject Iuna;
    public GameObject DisplayVida;

    protected override void Start()
    {
        base.Start();        
        Iuna = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update ()
    {
        base.Update();
        StartCoroutine(MoveTowards(Iuna.transform.position));
    }

    private void OnGUI()
    {
        DisplayVida.GetComponent<Text>().text = curHealth.ToString();
    }
}