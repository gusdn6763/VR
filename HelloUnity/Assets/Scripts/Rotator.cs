using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotation = 60f;

    private void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            rotation += 0.01f;
            transform.Rotate(0f, (rotation * Time.deltaTime), 0f);
        }
    }
}
