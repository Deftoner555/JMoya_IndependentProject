using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartNote : MonoBehaviour
{
    private AudioSource NoteAudioSource;
    public GameObject HeartNoteGO;

    private bool isHeart = false;
    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private bool isColliding = false;

    private float Speed = 10f;

    private void Start()
    {
        // Get the AudioSource component once in the Start method.
        NoteAudioSource = HeartNoteGO.GetComponent<AudioSource>();
    }

    //When collider enters Trigger, it checks the tag and sets isColliding to true if it collides with Player GO
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;

            //setting up bool's for each tag to make sure each player input is specific to each GO
            if (gameObject.CompareTag("Heart"))
            {
                isHeart = true;
            }

            else if (gameObject.CompareTag("Up"))
            {
                isUp = true;
            }

            else if (gameObject.CompareTag("Down"))
            {
                isDown = true;
            }

            else if (gameObject.CompareTag("Left"))
            {
                isLeft = true;
            }

            else if (gameObject.CompareTag("Right"))
            {
                isRight = true;
            }
        }
    }

    //sets isColliding to false when trigger exits collider
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    //avoids nullReferenceException if it ever pops up
    void PlayNoteAudio()
    {
        if (NoteAudioSource != null)
        {
            NoteAudioSource.Play();
        }
    }

    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);

        //Sets up conditions for each note and how to activate each one individually
        if (Input.GetButtonDown("Space") && isColliding && isHeart)
        {
            PlayNoteAudio();
        }

        else if (Input.GetButtonDown("W") && isColliding && isUp)
        {
            PlayNoteAudio();
        }

        else if (Input.GetButtonDown("S") && isColliding && isDown)
        {
            PlayNoteAudio();
        }

        else if (Input.GetButtonDown("A") && isColliding && isLeft)
        {
            PlayNoteAudio();
        }

        else if (Input.GetButtonDown("D") && isColliding && isRight)
        {
            PlayNoteAudio();
        }
    }
}
