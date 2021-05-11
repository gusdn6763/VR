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

    // ���� ���ھ�
    public int currentScore;

    // �ְ� ���ھ�
    public int bestScore;

    // ���罺�ھ� Text
    public Text currentScoreTxt;

    // �ְ��ھ� Text
    public Text bestScoreTxt;

    private void Start()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        if (bestScore != 0)
        {
            bestScoreTxt.text = "�ְ����� : " + bestScore.ToString();
        }
    }

    public void GetScore()
    {
        currentScore++;
        currentScoreTxt.text = "���� ���� :" + currentScore;

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
