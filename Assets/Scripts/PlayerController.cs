using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isColliding = false;
    private AudioSource NoteAudioSource;
    public GameObject HeartNoteGO;
    private void Start()
    {
        // Get the AudioSource component once in the Start method.
        NoteAudioSource = HeartNoteGO.GetComponent<AudioSource>();
    }

    public float CursorMoveSpeed = 10f;
    private float minX = -4f, maxX = -4f, minY = -3.44f, maxY = 5.5f;
    void Update()
    {
        if (Input.GetButton("Space") && isColliding)
        {
            Debug.Log("Spacebar pressed while colliding with HeartNote");
            PlayNoteAudio();
        }
        
        //Clamps player movement to set space
        float myVal = Input.GetAxis("Mouse Y");
        transform.Translate(0, myVal * CursorMoveSpeed, 0);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                  Mathf.Clamp(transform.position.y, minY, maxY), 6f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            isColliding = true;
            Debug.Log("Player collided with HeartNote");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Note"))
        {
            isColliding = false;
        }
    }

    private void PlayNoteAudio ()
    {
        if (NoteAudioSource != null)
        {
            NoteAudioSource.Play();
        }
    }
}
