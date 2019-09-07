using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftTopRooms;
    public GameObject[] leftBottomRooms;
    public GameObject[] rightTopRooms;
    public GameObject[] rightBottomRooms;
    public GameObject[] leftRightRooms;
    public GameObject[] topBottomRooms;
    public GameObject[] closedTopRooms;
    public GameObject[] closedRightRooms;
    public GameObject[] closedLeftRooms;
    public GameObject[] closedBottomRooms;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedBoss;
    public GameObject boss;

    void Update()
    {

        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}