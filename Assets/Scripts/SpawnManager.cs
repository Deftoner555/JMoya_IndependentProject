using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] NotePrefabs;
    private float[] yPositions = { 5.84f, 2.5f, -1f, -4f };
    void Start()
    {
        
    }

     
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            float RandYPos = yPositions[Random.Range(0, yPositions.Length)];
            int NotePrefabIndex = Random.Range(0, NotePrefabs.Length);
            Instantiate(NotePrefabs[NotePrefabIndex], new Vector3 (20, RandYPos, 6), NotePrefabs[NotePrefabIndex].transform.rotation);
        }
    }
}
