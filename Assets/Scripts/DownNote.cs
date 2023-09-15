using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownNote : MonoBehaviour
{
    public float Speed = 10f;

    private bool isColliding = false;

    private AudioSource NoteAudioSource;
    public GameObject HeartNoteGO;

    private void Start()
    {
        // Get the AudioSource component once in the Start method.
        NoteAudioSource = HeartNoteGO.GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(0, Speed * Time.deltaTime, 0);

        if (Input.GetButton("S") && isColliding)
        {
            //Debug.Log("Spacebar pressed while colliding with HeartNote");
            PlayNoteAudio();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = true;
            //Debug.Log("Player collided with HeartNote");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void PlayNoteAudio()
    {
        if (NoteAudioSource != null)
        {
            NoteAudioSource.Play();
        }
    }
}
