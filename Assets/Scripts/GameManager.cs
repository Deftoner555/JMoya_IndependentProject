using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScore(0);
    }

    private void Update()
    {
        
    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        scoreText.text = "Heartbeats: " + score;
    }
}
