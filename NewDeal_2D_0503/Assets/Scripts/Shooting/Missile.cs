using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 미사일을 위로 이동하도록하자
/// 필요속성 : 미사일 속도
/// 1. 방향 구하기
/// 2. 이동하기
/// </summary>

public class Missile : MonoBehaviour
{
    // 미사일 속도
    public float speed = 5;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        // 방향구하기
        Vector3 dir = Vector3.up;

        // 이동하기 P = P0 + vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
