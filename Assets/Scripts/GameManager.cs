using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static int playerScore = 0;

    public static void AddPoints(int points)
    {
        playerScore += points;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(playerScore);
    }
}
