using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IaraController : LivingObject
{
    private bool Busy;
    private GameObject Iuna;
    private float attackRadius = 2f;
    private float waitUntilNextAttack = 1.0f;
    public GameObject DisplayVida;

    protected override void Start()
    {
        base.Start();        
        Iuna = GameObject.FindGameObjectWithTag("Player");
    }

    private float currentSpeedMultiplier()
    {
        return (curHealth / maxHealth);
    }

    protected override void Update ()
    {
        base.Update();
        AnimControl.SetFloat("Multiplier",  (1f + currentSpeedMultiplier()));

        if (!Busy)
        {
            if (Mathf.Abs(Vector3.Distance(transform.position, NearestPlayerPosition())) > 1f)
            {
                StartCoroutine(MoveTowards(NearestPlayerPosition()));
            }
            else
            {
                Busy = true;
                StartCoroutine(Attack1());
            }
        }               
    }

    private Vector3 NearestPlayerPosition()
    {
        return Iuna.transform.position + new Vector3(3f, 3f, 0f);
    }

    private Vector3 AbsolutePlayerPosition()
    {
        return Iuna.transform.position + new Vector3(3f, 3f, 0f);
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

   IEnumerator Attack1()
    {
        AnimControl.SetTrigger("Attack1");
        yield return new WaitForSeconds(1f * currentSpeedMultiplier());

        if (Mathf.Abs(Vector3.Distance(transform.position, NearestPlayerPosition())) <= (attackRadius * 0.5))
            Iuna.GetComponent<IunaController>().SendMessage("TakeDamage", 1f);        

        yield return new WaitForSeconds(waitUntilNextAttack);
        Busy = false;
    }
}