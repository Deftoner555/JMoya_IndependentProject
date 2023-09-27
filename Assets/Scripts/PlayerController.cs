using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float CursorMoveSpeed = 10f;
    private float minX = -4f, maxX = -4f, minY = -3.77f, maxY = 6.07f;
    void Update()
    {
        //Player input
        float myVal = Input.GetAxis("Mouse Y");
        transform.Translate(0, myVal * CursorMoveSpeed, 0);

        //Clamps player movement to set space
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                  Mathf.Clamp(transform.position.y, minY, maxY), 6f);
    }
    
}
