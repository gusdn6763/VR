using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 일정 시간마다 Enemy를 생성하고 싶다
/// 필요속성 : 시간(일정한시간,현재시간), 적공장
/// 1. 시간이 흐른다
/// 2. 일정한 시간이 되면
/// 3. 적을 생성한다
/// 4. 위치로 놓는다
/// </summary>

/// <summary>
/// 랜덤함수를 이용하여 Enemy가 불규칙하게 나오도록
/// 필요 속성 : 최소, 최대
/// </summary>
/// 
public class EnemyManager : MonoBehaviour
{
    // 최소 
    [SerializeField]
    float minTime = 1;
    
    // 최대
    [SerializeField]
    float maxTime = 5;

    // 현재 시간
    float currentTime = 0;

    // 일정 시간
    [SerializeField]
    float appearTime = 1;

    // 적 프리팹
    [SerializeField]
    GameObject enemyPrefab;

    void Start()
    {
        // 처음 적이 생성 될시간 설정
        currentTime = Random.Range(minTime, maxTime);
    }
    
    void Update()
    {
        // 1. 시간이 흐른다
        currentTime += Time.deltaTime;

        // 2. 일정한 시간이 되면
        if (currentTime > appearTime)
        {
            // 3. 적을 생성한다
            GameObject enemy = Instantiate(enemyPrefab);

            // 4. 위치로 놓는다
            enemy.transform.position = transform.position;

            // 5. 시간을 0으로 초기화
            currentTime = 0;

            // 적이 생성후 적 생성 시간 다시 설정
            currentTime = Random.Range(minTime, maxTime);
        }

    }
}
