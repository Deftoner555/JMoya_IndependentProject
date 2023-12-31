using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string SE_titleScreen = "TitleScreen";
    [SerializeField] private string SE_howToPlay = "HowToPlay";
    [SerializeField] private string SE_gameplay = "Gameplay";
    [SerializeField] private string SE_resultScreen = "ResultScreen";

    public TextMeshProUGUI scoreText;
    public GameObject restartButton;
    private int score = 0;

    void Start()
    {
        UpdateScore(0);
    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        scoreText.text = "Heartbeats: " + score;
    }

    public void toTitle()
    {
        SceneManager.LoadScene(SE_titleScreen);
    }

    public void toHowToPlay()
    {
        SceneManager.LoadScene(SE_howToPlay);
    }

    public void toGameplay()
    {
        SceneManager.LoadScene(SE_gameplay);
    }

    public void toResult()
    {
        SceneManager.LoadScene(SE_resultScreen);
    }

    public void showRestart()
    {
        restartButton.gameObject.SetActive(true);
    }
}
