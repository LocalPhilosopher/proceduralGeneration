using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemysight : MonoBehaviour
{

    [SerializeField]
    private Enemy enemy;
    private Transform player;
    private Animator anim;
    private BoxCollider2D managerBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
    //    if (other.tag == "Player")
    //    {
    //        if (transform.position.x < player.position.x)
    //            enemy.hInput = 1;
    //        if (transform.position.x > player.position.x)
    //            enemy.hInput = -1;
    //    }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.tag == "Player")
    //   {
    //       enemy.hInput = 0;
    //    }
    //}
}




