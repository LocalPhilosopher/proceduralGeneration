using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsceptingRatioCamera : MonoBehaviour {

    private BoxCollider2D box;
    private Camera cam;
    private float xRatio;
    private float yRatio;
    private float boxSizeX;
    private float boxSizeY;

    void Start()
    {
        box = GetComponent<BoxCollider2D>();
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        CalculateCameraBound();
    }

    void CalculateCameraBound()
    {
        xRatio = (float)Screen.width / (float)Screen.height;
        yRatio = (float)Screen.height / (float)Screen.width;

        boxSizeX = (Mathf.Abs(cam.orthographicSize) * 2 * xRatio);
        boxSizeY = boxSizeX * yRatio;

        box.size = new Vector2(boxSizeX, boxSizeY);
    }
}
