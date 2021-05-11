using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    public Text black;
    private Color color;
    internal bool fadeInCheck;
    internal bool fadeOutCheck;


    private void Start()
    {
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeOutCoroutine(float _speed = 0.02f)
    {
        color = black.color;

        while (color.a < 1f)
        {
            color.a += _speed;
            black.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine(float _speed = 0.02f)
    {
        color = black.color;
        while (color.a > 0f)
        {
            color.a -= _speed;
            black.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeOutCoroutine());
    }

}