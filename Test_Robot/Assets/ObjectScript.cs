using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeStatus
{
    color, scale, rotation, disable
}

public class ObjectScript : MonoBehaviour
{
    public ChangeStatus changeStatus;
    private SpriteRenderer sprite;
    private Transform rotation;    

    void Start()
    {
        mainCl.act += ChangeObejct;
        sprite = GetComponent<SpriteRenderer>();
    }

    public void ChangeObejct()
    {
        switch(changeStatus)
        {
            case ChangeStatus.color:
                {
                    sprite.color = Color.black;
                }
                break;
            case ChangeStatus.disable:
                {
                    transform.gameObject.SetActive(false);
                }
                break;
            case ChangeStatus.rotation:
                {
                    transform.rotation = Quaternion.Euler(10, 10, 10);
                }
                break;
        }
    }

    private void OnDisable()
    {
        mainCl.act -= ChangeObejct;
    }
}
