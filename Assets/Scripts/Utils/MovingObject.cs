using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public float Velocity = 1.5f;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
       
    }

    public IEnumerator MoveTowards(Vector3 destination)
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, Velocity * Time.deltaTime);
        yield return null;
    }

    public IEnumerator Move(float moveOnX, float MoveOnY)
    {
        this.transform.Translate(moveOnX, MoveOnY, 0f);
        yield return null;
    }

    protected float AngleBetweenPoints(Vector2 positionA, Vector2 positionB)
    {
        return Mathf.Atan2(positionA.y - positionB.y, positionA.x - positionB.x) * Mathf.Rad2Deg;
    }
}
