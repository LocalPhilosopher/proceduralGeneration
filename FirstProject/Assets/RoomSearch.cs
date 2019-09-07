using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSearch : MonoBehaviour
{
    
    public bool roomFound = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer==9) roomFound = true;
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == 9)
        {
            if (transform.position.x == 0 && transform.position.y > 0) roomFound = false;
        }
    }
}