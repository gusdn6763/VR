using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViemManager : MonoBehaviour
{
    public static ViemManager instance;

    private Text scoreText;
    public float score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this.gameObject);
        }
        scoreText = GetComponent<Text>();
        scoreText.text = "Á¡¼ö : " + score.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
       
    }
}
