using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    private BoxCollider2D cameraBox;//The box colider of the camera
    private Transform player;//The position of the player
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;

    void Start()
    {
        cameraBox = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

     void Update()
    {
        //AspectRadioBoxChange();
        FollowPlayer();
    }
    
    //void AspectRadioBoxChange()//The size of the camera protection rect=7.1
    //{
        //16:10
        //if (Camera.main.aspect >= (1.6f) && Camera.main.aspect < 1.7f) cameraBox.size = new Vector2(23, 14.3f);
        //16:9
        //if (Camera.main.aspect >= (1.7f) && Camera.main.aspect < 1.8f) cameraBox.size = new Vector2(25.47f, 14.3f);
        //5:4
        //if (Camera.main.aspect >= (1.25f) && Camera.main.aspect < 1.3f) cameraBox.size = new Vector2(18, 14.3f);
        //4:3
        //if (Camera.main.aspect >= (1.3f) && Camera.main.aspect < 1.4f) cameraBox.size = new Vector2(19.13f, 14.3f);
        //3:2
        //if (Camera.main.aspect >= (1.5f) && Camera.main.aspect < 1.6f) cameraBox.size = new Vector2(21.6f, 14.3f);

    //}

    void FollowPlayer()
    {
        float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
        if (GameObject.Find("Boundary"))
        {
            transform.position = new Vector3(Mathf.Clamp(posX, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.x + cameraBox.size.x / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.x - cameraBox.size.x / 2),
                                             Mathf.Clamp(posY, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.min.y + cameraBox.size.y / 2, GameObject.Find("Boundary").GetComponent<BoxCollider2D>().bounds.max.y - cameraBox.size.y / 2),
                                             transform.position.z);

        }
    }
}
