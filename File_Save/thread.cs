using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
//using Task<T> �����尡 ������ ��ȯ�� 
/// <summary>
/// ������ ��� ���� : ���� ó��
/// </summary>
/// 
///����ȭ -> ������ ����, ������� ������ ���� ȿ���� �ٸ���.
public class thread : MonoBehaviour
{
    private void Start()
    {
        var Tas1k = Task.Factory.StartNew(() =>
        {

        });
        Tas1k.Wait();
        Tas1k.Start();

        //���� �����忡 �ݺ��� �۾��� ��������
        Parallel.For(0, 1000, (int i) =>
        {

        });
        // async ����ȭ
        //await �� �ǿ�
           }
}
