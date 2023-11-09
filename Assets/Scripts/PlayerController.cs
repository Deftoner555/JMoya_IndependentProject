using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float CursorMoveSpeed = 10f;
    private float minX = 0f, maxX = 0f, minY = -3.77f, maxY = 6.07f;

    private float timer = 220f;
    private float currentTime;
    private bool canMove = true;

    private AudioSource gameSong;
    public GameObject playerGO;

    private void Start()
    {
        currentTime = timer;
        gameSong = playerGO.GetComponent<AudioSource>();
        gameSong.PlayDelayed(2f);
    }

    void Update()
    {
        Debug.Log(currentTime);
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
