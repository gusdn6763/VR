using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject playerGameObject;
    public Text hpText;
    public Text scoreText;
    int score;
    public bool gameStart = false;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOver)
        {
            hpText.text = "Hp :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
            scoreText.text = "Score :" + (int)score;
        }
    }

    public void GetScored(int value)
    {
        score += value;
    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverText.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
