using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float CursorMoveSpeed = 10f;
    private float minX = -4f, maxX = -4f, minY = -3.77f, maxY = 6.07f;

    private float timer = 15.0f;
    private float currentTime;
    private bool canMove = true;

    private void Start()
    {
        currentTime = timer;
    }

    void Update()
    {
        if (canMove)
        {
            //Player input
            float myVal = Input.GetAxis("Mouse Y");
            transform.Translate(0, myVal * CursorMoveSpeed, 0);

            //Clamps player movement to set space
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                      Mathf.Clamp(transform.position.y, minY, maxY), 6f);
        }

        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else 
        {
            currentTime = 0;
            canMove = false;
        }
    }
    
}
