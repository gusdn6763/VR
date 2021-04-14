using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    private bool brokenCheck = false;
    private void Update()
    {
        if (((transform.eulerAngles.x >= 45 || transform.eulerAngles.x <= -45) || (transform.eulerAngles.z >= 45 || transform.eulerAngles.z <= -45)) && !brokenCheck)
        {
            brokenCheck = true;
            ViemManager.instance.score++;
        }
    }
}
