using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);

        //Zoom Out
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Camera.main.fieldOfView <= 125)
                Camera.main.fieldOfView += 4;
            if (Camera.main.orthographicSize <= 20)
                Camera.main.orthographicSize += 1;
        }

        //Zoom In
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (Camera.main.fieldOfView > 2)
                Camera.main.fieldOfView -= 4;
            if (Camera.main.orthographicSize >= 1)
                Camera.main.orthographicSize -= 1;
        }

        //Rotate to the right
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.Translate(4, 0, 0);
        }

        //Rotate to the left
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.Translate(-4, 0, 0);
        }
    }
}
