using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    public int openingDirection;
    // 1 --> need bottom door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door
    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    private RoomTemplates rTemp;
    public RoomSearch rsLT;
    public RoomSearch rsLB;
    public RoomSearch rsRT;
    public RoomSearch rsRB;
    public RoomSearch rsT;
    public RoomSearch rsB;
    public RoomSearch rsR;
    public RoomSearch rsL;
    public float waitTime = 4f;
    bool roomCompound;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1 && !roomCompound)
            {
                if (rsT.roomFound)
                {
                    if (rsRT.roomFound && rsLT.roomFound)
                    {
                        rand = Random.Range(0, templates.closedBottomRooms.Length);
                        Instantiate(templates.closedBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsRT.roomFound)
                    {
                        rand = Random.Range(0, templates.leftBottomRooms.Length);
                        Instantiate(templates.leftBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsLT.roomFound)
                    {
                        rand = Random.Range(0, templates.rightBottomRooms.Length);
                        Instantiate(templates.rightBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else
                    {
                        rand = Random.Range(0, templates.closedBottomRooms.Length);
                        Instantiate(templates.closedBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                }
                else if (rsRT.roomFound && rsLT.roomFound)
                {
                    rand = Random.Range(0, templates.closedBottomRooms.Length);
                    Instantiate(templates.closedBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsRT.roomFound)
                {
                    rand = Random.Range(0, templates.leftBottomRooms.Length);
                    Instantiate(templates.leftBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsLT.roomFound)
                {
                    rand = Random.Range(0, templates.rightBottomRooms.Length);
                    Instantiate(templates.rightBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }

                else if ((rsRT.roomFound && rsLT.roomFound) && !rsT.roomFound)
                {
                    rand = Random.Range(0, templates.topBottomRooms.Length);
                    Instantiate(templates.topBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else
                {
                    // Need to spawn a room with a BOTTOM door.
                    rand = Random.Range(0, templates.bottomRooms.Length);
                    Instantiate(templates.bottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                
            }
            else if (openingDirection == 2 && !roomCompound)
            {
                
                if (rsB.roomFound)
                {
                    if (rsRB.roomFound && rsLB.roomFound)
                    {
                        rand = Random.Range(0, templates.closedTopRooms.Length);
                        Instantiate(templates.closedTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsRB.roomFound)
                    {
                        rand = Random.Range(0, templates.leftTopRooms.Length);
                        Instantiate(templates.leftTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsLB.roomFound)
                    {
                        rand = Random.Range(0, templates.rightTopRooms.Length);
                        Instantiate(templates.rightTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else
                    {
                        rand = Random.Range(0, templates.closedTopRooms.Length);
                        Instantiate(templates.closedTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                }
                else if (rsRB.roomFound && rsLB.roomFound)
                {
                    rand = Random.Range(0, templates.closedTopRooms.Length);
                    Instantiate(templates.closedTopRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsRB.roomFound)
                {
                    rand = Random.Range(0, templates.leftTopRooms.Length);
                    Instantiate(templates.leftTopRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsLB.roomFound)
                {
                    rand = Random.Range(0, templates.rightTopRooms.Length);
                    Instantiate(templates.rightTopRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if ((rsRB.roomFound && rsLB.roomFound) && !rsB.roomFound)
                {
                    rand = Random.Range(0, templates.topBottomRooms.Length);
                    Instantiate(templates.topBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else
                {
                    // Need to spawn a room with a BOTTOM door.
                    rand = Random.Range(0, templates.topRooms.Length);
                    Instantiate(templates.topRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
            }
            else if (openingDirection == 3 && !roomCompound)
            {
                

                if (rsR.roomFound)
                {
                    if (rsRT.roomFound && rsRB.roomFound)
                    {
                        rand = Random.Range(0, templates.closedLeftRooms.Length);
                        Instantiate(templates.closedLeftRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsRT.roomFound)
                    {
                        rand = Random.Range(0, templates.leftBottomRooms.Length);
                        Instantiate(templates.leftBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsRB.roomFound)
                    {
                        rand = Random.Range(0, templates.leftTopRooms.Length);
                        Instantiate(templates.leftTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else
                    {
                        rand = Random.Range(0, templates.closedLeftRooms.Length);
                        Instantiate(templates.closedLeftRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                }
                else if (rsRT.roomFound && rsRB.roomFound)
                {
                    rand = Random.Range(0, templates.closedLeftRooms.Length);
                    Instantiate(templates.closedLeftRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsRT.roomFound)
                {
                    rand = Random.Range(0, templates.leftBottomRooms.Length);
                    Instantiate(templates.leftBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsRB.roomFound)
                {
                    rand = Random.Range(0, templates.leftTopRooms.Length);
                    Instantiate(templates.leftTopRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }

                else if ((rsRT.roomFound && rsRB.roomFound) && !rsR.roomFound)
                {
                    rand = Random.Range(0, templates.leftRightRooms.Length);
                    Instantiate(templates.leftRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else
                {
                    // Need to spawn a room with a LEFT door.
                    rand = Random.Range(0, templates.leftRooms.Length);
                    Instantiate(templates.leftRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }  
            }
            else if (openingDirection == 4 && !roomCompound)
            {
                
                if (rsL.roomFound)
                {
                    if (rsLT.roomFound && rsLB.roomFound)
                    {
                        rand = Random.Range(0, templates.closedRightRooms.Length);
                        Instantiate(templates.closedRightRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsLT.roomFound)
                    {
                        rand = Random.Range(0, templates.rightBottomRooms.Length);
                        Instantiate(templates.rightBottomRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                    else if (rsLB.roomFound)
                    {
                        rand = Random.Range(0, templates.rightTopRooms.Length);
                        Instantiate(templates.rightTopRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    } 
                    else
                    {
                        rand = Random.Range(0, templates.closedRightRooms.Length);
                        Instantiate(templates.closedRightRooms[rand], transform.position, transform.rotation);
                        spawned = true;
                    }
                }
                else if (rsLT.roomFound && rsLB.roomFound)
                {
                    rand = Random.Range(0, templates.closedRightRooms.Length);
                    Instantiate(templates.closedRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsLT.roomFound)
                {
                    rand = Random.Range(0, templates.rightBottomRooms.Length);
                    Instantiate(templates.rightBottomRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if (rsLB.roomFound)
                {
                    rand = Random.Range(0, templates.rightTopRooms.Length);
                    Instantiate(templates.rightTopRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else if ((rsLT.roomFound && rsLB.roomFound) && !rsL.roomFound)
                {
                    rand = Random.Range(0, templates.leftRightRooms.Length);
                    Instantiate(templates.leftRightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
                else
                {
                    // Need to spawn a room with a RIGHT door.
                    rand = Random.Range(0, templates.rightRooms.Length);
                    Instantiate(templates.rightRooms[rand], transform.position, transform.rotation);
                    spawned = true;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("SpawnPoint")){

            if (openingDirection == 0)
            {
                other.GetComponent<RoomSpawner>().openingDirection = 0;
            }
            else if (other.GetComponent<RoomSpawner>().openingDirection == 0)
            {
                openingDirection = 0;
            }
            else if (other.GetComponent<RoomSpawner>().openingDirection != 0 && openingDirection != 0)
                if (!spawned && !other.GetComponent<RoomSpawner>().spawned)
                {
                    if (openingDirection == 1)
                    {
                        if (other.GetComponent<RoomSpawner>().openingDirection == 2)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.topBottomRooms.Length);
                            Instantiate(templates.topBottomRooms[rand], transform.position, transform.rotation);
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 3)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.leftBottomRooms.Length);
                            Instantiate(templates.leftBottomRooms[rand], transform.position, transform.rotation);
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 4)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.rightBottomRooms.Length);
                            Instantiate(templates.rightBottomRooms[rand], transform.position, transform.rotation);
                        }
                    }
                    if (openingDirection == 2)
                    {
                        if (other.GetComponent<RoomSpawner>().openingDirection == 1)
                        {
                            roomCompound = true;
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 3)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.leftTopRooms.Length);
                            Instantiate(templates.leftTopRooms[rand], transform.position, transform.rotation);
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 4)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.rightTopRooms.Length);
                            Instantiate(templates.rightTopRooms[rand], transform.position, transform.rotation);
                        }
                    }
                    if (openingDirection == 3)
                    {
                        if (other.GetComponent<RoomSpawner>().openingDirection == 1)
                        {
                            roomCompound = true;
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 2)
                        {
                            roomCompound = true;
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 4)
                        {
                            roomCompound = true;
                            rand = Random.Range(0, templates.leftRightRooms.Length);
                            Instantiate(templates.leftRightRooms[rand], transform.position, transform.rotation);
                        }
                    }
                    if (openingDirection == 4)
                    {
                        if (other.GetComponent<RoomSpawner>().openingDirection == 1)
                        {
                            roomCompound = true;
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 2)
                        {
                            roomCompound = true;
                        }
                        else if (other.GetComponent<RoomSpawner>().openingDirection == 3)
                        {
                            roomCompound = true;
                        }
                    }
                }
        }
    }
    public bool roomFound = false;
    public void OnTriggerEnter2D(RoomSearch other)
    {
        roomFound = true;
    }
    public void OnTriggerExit2D(RoomSearch other)
    {
        roomFound = false;
    }
}