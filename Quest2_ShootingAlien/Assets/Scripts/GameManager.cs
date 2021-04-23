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
    public bool isGameOver;
    public bool gameStart = false;

    MovementProvider movementProvider;
    AudioSource musicSource;
    void Start()
    {
        score = 0;
        isGameOver = false;
        musicSource = GetComponent<AudioSource>();
        movementProvider = GetComponent<MovementProvider>();
    }

    public void StartGame()
    {
        musicSource.Play();
        gameStart = true;
        movementProvider.StartMove();
    }
    void Update()
    {
        if(!isGameOver)
        {
            hpText.text = "HP :" + (int)playerGameObject.GetComponent<PlayerController>().hp;
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
