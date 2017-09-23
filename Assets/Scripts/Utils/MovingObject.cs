using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour {
    public float Velocity = 1.5f;
    
    void Update () {
		
	}

    // Move towards a position
    public IEnumerator MoveTowards(Vector3 destination)
    {
        yield return null;
    }

    // Moves baseed on input
    public IEnumerator Move(float moveOnX, float MoveOnY)
    {
        this.transform.Translate(moveOnX, MoveOnY, 0f);
        yield return null;
    }
}
