using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Calculate
//{

//    Calculate(int a, int b)
//    {
//    }
//    public 
//}

public class NewBehaviourScript : MonoBehaviour
{
    Func<int, int, int> calc;
    Action doIt;

    private void Start()
    {
        calc = (a, b) => a + b;
        print(calc(3, 5));

        calc = Calculate;
        print(calc(0, 1));

        doIt = () =>
        {
            print("asd");
        };
    }

    public void Test()
    {
        calc = (a, b) => a + b;
        print(calc(3, 5));
    }

    private int Calculate(int a, int b)
    {
        return a + b;
    }
}
