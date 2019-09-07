using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryManager : MonoBehaviour {


    private BoxCollider2D managerBox;//This is Collider of the BoundaryManager
    private Transform player; //this is position of the player
    public GameObject boundary; //The real camera boundy which will be activated and deactivated

	void Start () {
        managerBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent <Transform>();
	}
	
	void Update () {
        ManageBoundary();
	}
    void ManageBoundary()
    {
        if (managerBox.bounds.min.x < player.position.x && player.position.x < managerBox.bounds.max.x &&
            managerBox.bounds.min.y < player.position.y && player.position.y < managerBox.bounds.max.y)
        {
            boundary.SetActive(true);
        }
        else boundary.SetActive(false);
    }
}