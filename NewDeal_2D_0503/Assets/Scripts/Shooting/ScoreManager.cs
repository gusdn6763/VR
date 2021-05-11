using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    // 현재 스코어
    public int currentScore;

    // 최고 스코어
    public int bestScore;

    // 현재스코어 Text
    public Text currentScoreTxt;

    // 최고스코어 Text
    public Text bestScoreTxt;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        if (bestScore != 0)
        {
            bestScoreTxt.text = "최고점수 : " + bestScore.ToString();
        }
    }

    public void GetScore()
    {
        currentScore++;
        currentScoreTxt.text = "현재 점수 :" + currentScore;

        if (bestScore < currentScore)
        {
            GetBestScore(currentScore);
        }
    }
    public void GetBestScore(int num)
    {
        bestScore = num;
        bestScoreTxt.text = num.ToString();
        PlayerPrefs.SetInt("Best Score", bestScore);
    }
}
