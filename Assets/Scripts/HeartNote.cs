using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartNote : MonoBehaviour
{
    private AudioSource NoteAudioSource;
    public GameObject HeartNoteGO;

    private void Start()
    {
        // Get the AudioSource component once in the Start method.
        NoteAudioSource = HeartNoteGO.GetComponent<AudioSource>();
    }

    private bool isColliding = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;

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

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    void PlayNoteAudio()
    {
        if (NoteAudioSource != null)
        {
            NoteAudioSource.Play();
        }
    }

    private bool isHeart = false;
    private bool isUp = false;
    private bool isDown = false;
    private bool isLeft = false;
    private bool isRight = false;

    private float Speed = 10f;

    void Update()
    {
        transform.Translate(-Speed * Time.deltaTime, 0, 0);

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
