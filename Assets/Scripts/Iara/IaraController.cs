using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IaraController : LivingObject
{
    private bool Busy;
    private GameObject Iuna;
    private float waitUntilNextAttack = 3.0f;
    public GameObject DisplayVida;

    protected override void Start()
    {
        base.Start();        
        Iuna = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void Update ()
    {
        base.Update();
        MoveTowards(Iuna.transform.position);
    }

    private void OnGUI()
    {
        DisplayVida.GetComponent<Text>().text = curHealth.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Arrow")
        { 
            this.TakeDamage(other.gameObject.GetComponent<Arrow>().Damage);
            other.gameObject.SetActive(false);
        }            
    }

    protected override void OnDie()
    {
        Scenes.LoadScene("Epilogue");
    }
}