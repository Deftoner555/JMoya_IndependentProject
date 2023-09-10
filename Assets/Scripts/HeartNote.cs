using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartNote : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component once in the Start method.
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetButton("Space"))
        {
            if (audioSource != null)
            {
                // Play the audio.
                audioSource.Play();
            }
        }

    }

    public float Speed = 1f;

    void Update()
    {
        transform.Translate(0, Speed, 0);
    }
}
