using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public GameObject menuOffset;

    private void Update()
    {
        if (menuOffset != null)
        {
            this.transform.position = menuOffset.transform.position;
            this.transform.rotation = menuOffset.transform.rotation;
        }
    }
}
