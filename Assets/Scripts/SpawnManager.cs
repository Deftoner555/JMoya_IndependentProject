using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] NotePrefabs;
    public GameObject powerUp;

    //set list of Y positions that prefabs should spawn at
    private float[] yPositions = { 5.84f, 2.5f, -1f, -4f };

    private float timerNotes = 20.0f;
    private float currentTime;
    private bool canMove = true;

    void SpawnNotes()
    {
        if (canMove)
        {
            //select a random Y position from the list
            float RandYPos = yPositions[Random.Range(0, yPositions.Length)];

            int NotePrefabIndex = Random.Range(0, NotePrefabs.Length);
            Instantiate(NotePrefabs[NotePrefabIndex], new Vector3(20, RandYPos, 6), 
                NotePrefabs[NotePrefabIndex].transform.rotation);
        }
        
    }

    IEnumerator SpawnPowerUp()
    {
        yield return new WaitForSecondsRealtime(8);

        float RandYPos = yPositions[Random.Range(0, yPositions.Length)];

        Instantiate(powerUp, new Vector3 (22, RandYPos, 6), powerUp.transform.rotation);
    }

    void Start()
    {
        currentTime = timerNotes;
        InvokeRepeating("SpawnNotes", 2f, .6f);

        StartCoroutine(SpawnPowerUp());
    }

    private void Update()
    {
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
