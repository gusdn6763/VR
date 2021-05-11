using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCl : MonoBehaviour
{
    public static Action act;
    public void ChangeStatus()
    {
        act.Invoke();
        JsonUtility.ToJson(act);
    }


}
