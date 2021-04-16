using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float attackAmount = 35f;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.gameObject.tag == "Monster")
        {
            BulletSpawner bulletSpawner = other.GetComponent<BulletSpawner>();

            if (bulletSpawner != null)
            {
                bulletSpawner.GetDamage(attackAmount);
            }
            Destroy(gameObject);
        }
    }
}
