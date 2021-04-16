using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class BulletCtrl : MonoBehaviour 
{
    private Transform trans;

    public bool playerBullet;
    public bool passObstacle;
    public float speed;
    public float distance;
    public float damage;
    private float distanceTmp;

    private void Awake()
    {
        trans = GetComponent<Transform>();
    }



    private void OnEnable()
    {
        StartCoroutine(BulletMove());
    }

    private void OnDisable()
    {
        trans.position = Vector3.zero;
        trans.rotation = Quaternion.identity;
    }


    IEnumerator BulletMove()
    {
        distanceTmp = distance;
        while (distanceTmp >= 0)
        {
            distanceTmp -= Time.deltaTime * speed;
            transform.Translate(-transform.up * speed * Time.deltaTime, Space.World);
            yield return null;
        }
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if (playerBullet)
        {
            if (Col.gameObject.CompareTag("Monster"))
            {
                Col.GetComponent<MovingObject>().Damaged(damage);
                gameObject.SetActive(false);
            }
            else if(Col.gameObject.CompareTag("Part"))
            {
                //Col.gameObject<>();
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (Col.gameObject.CompareTag("Player"))
            {
                Col.GetComponent<MovingObject>().Damaged(damage);
                gameObject.SetActive(false);
            }
        }
    }

}
