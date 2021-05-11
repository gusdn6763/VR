using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputpL : MonoBehaviour
{
    Action abc;
    public InputField input;

    float x;
    float y;

    private void Start()
    {
        x = Camera.main.orthographicSize;
        y = x * Camera.main.aspect;
    }

    public void GetName(string name = "¾Æ´ã")
    {
        
    }

    public void Asd()
    {

    }
}
