using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float CursorMoveSpeed = 10f;
    private float minX = -4f, maxX = -4f, minY = -3.44f, maxY = 5.5f;
    void Update()
    {
        //Clamps player movement to set space
        float myVal = Input.GetAxis("Mouse Y");
        transform.Translate(0, myVal * CursorMoveSpeed, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                  Mathf.Clamp(transform.position.y, minY, maxY), 6f);
    }
    
}
