using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// DestroyBar에 오브젝트가 닿으면 닿은 Object를 파괴한다
/// OnTriggerEnter 사용하여 만들기
/// </summary>

public class DestoryBar : MonoBehaviour
{
    //DestroyBar에 오브젝트가 닿으면 
    private void OnTriggerEnter(Collider other)
    {
        //닿은 Object를 파괴한다
        Destroy(other.gameObject);
    }

}
