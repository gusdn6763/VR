using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ź���� ���� ������
    public float spawnRateMin = 0.5f; // �ּ� ���� �ֱ�
    public float spawnRateMax = 3f; // �ִ� ���� �ֱ�

    private Transform target; // �߻��� ���
    private float spawnRate; // ���� �ֱ�
    private float timeAfterSpawn; // �ֱ� ���� �������� ���� �ð�

    void Start()
    {
        // �ֱ� ���� ������ ���� �ð��� 0���� �ʱ�ȭ
        timeAfterSpawn = 0f;
        // ź�� ���� ������ spawnRateMin �� Max ���̿��� ���� ����
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        // playerController ������Ʈ�� ���� ���� ������Ʈ�� ã�� ���� ������� ����
        target = FindObjectOfType<Player>().transform;

    }

    void Update()
    {
        if (!GameManager.instance.isGameover)
        {
            // timeAfterSpawn ����
            timeAfterSpawn += Time.deltaTime;

            // �ֱ� ���� ������������ ������ �ð��� ���� �ֱ⺸�� ũ�ų� ���ٸ�
            if (timeAfterSpawn >= spawnRate)
            {
                // ������ �ð��� ����
                timeAfterSpawn = 0f;

                // bulletPrefab�� ��������
                // transform.position ��ġ�� transform.rotation ȸ������ ����
                GameObject bullet =
                    Instantiate(bulletPrefab, transform.position, transform.rotation);

                // ������ bullet ���� ������Ʈ�� ���� ������ target�� ���ϵ��� ȸ��
                bullet.transform.LookAt(target);
            }
        }
    }
}