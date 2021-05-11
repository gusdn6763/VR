using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT : MonoBehaviour
{
    private Transform box;
    private SpriteRenderer material;
    Color color;
    Vector3 vector = Vector3.zero;
    int i = 0;

    private void Awake()
    {
        box = GetComponent<Transform>();
        material = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        color = Color.red;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            i++;
            transform.localScale += new Vector3(i, i, i);
            transform.rotation = Quaternion.Euler(i, i, i);
            if (color == Color.red)
            {
                color = Color.blue;
                material.color = color;
            }
            else
            {
                color = Color.red;
                material.color = color;
            }
        }
    }

    private void OnEnable()
    {
        print("aaa");
    }
}
