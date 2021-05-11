using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algo3 : MonoBehaviour
{
    string tempA = "newDeal";
    string tempB = "dEAl";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            string middleword = PickMiddleWords(tempA);
            print(middleword);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            string middleword = PickMiddleWords(tempB);
            print(middleword);
        }

    }

    string PickMiddleWords(string word)
    {
        // 초기화
        string middleWord = "";

        // 구현
        int middleNum = word.Length / 2;

        // string이 홀수인지 짝수인지 확인하자
        if(word.Length % 2 == 0)
        {
            middleWord += word[middleNum - 1];
        }

        // middleWord 값 넣기
        middleWord = middleWord + word[middleNum];

        // 호출한곳으로 반환
        return middleWord;
    }

}
