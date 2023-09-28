using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] NotePrefabs;

    //set list of Y positions that prefabs should spawn at
    private float[] yPositions = { 5.84f, 2.5f, -1f, -4f };

    void Start()
    {
        InvokeRepeating("SpawnNotes", 2f, .5f); 
    }

    void SpawnNotes()
    {
        //select a random Y position from the list
        float RandYPos = yPositions[Random.Range(0, yPositions.Length)];

        int NotePrefabIndex = Random.Range(0, NotePrefabs.Length);
        Instantiate(NotePrefabs[NotePrefabIndex], new Vector3(20, RandYPos, 6), NotePrefabs[NotePrefabIndex].transform.rotation);
    } 
}
