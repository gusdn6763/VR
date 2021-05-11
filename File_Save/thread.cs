using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
//using Task<T> 쓰레드가 끝날때 반환값 
/// <summary>
/// 스레드 사용 이유 : 빠른 처리
/// </summary>
/// 
///동기화 -> 쓰레드 연결, 쓰레드는 생성시 각각 효율이 다르다.
public class thread : MonoBehaviour
{
    private void Start()
    {
        var Tas1k = Task.Factory.StartNew(() =>
        {

        });
        Tas1k.Wait();
        Tas1k.Start();

        //각각 스레드에 반복된 작업을 나누어줌
        Parallel.For(0, 1000, (int i) =>
        {

        });
        // async 동기화
        //await 가 피요
           }
}
