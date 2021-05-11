using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Offset을 이용하여 배경을 움직이자
/// 필요속성 : Material, 움직이는 속도
/// 1. 움직이는 방향
/// 2. offset 조절
/// </summary>

public class BackGround : MonoBehaviour
{
    //Material
    public Material backgoundMaterial;

    //움직이는 속도
    [Range(0f,1f)]
    public float moveSpeed = 0.5f;

    void Update()
    {
        // 1. 움직이는 방향
        Vector2 dir = Vector2.up;

        // 2. offset 조절 P = P0 + vt
        backgoundMaterial.mainTextureOffset += dir * moveSpeed * Time.deltaTime;
    }

}
