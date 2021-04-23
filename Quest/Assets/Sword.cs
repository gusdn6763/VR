using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float attackAmount = 20f;
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            BulletSpawner bulletSpawner = other.GetComponent<BulletSpawner>();

            if (bulletSpawner != null)
            {
                bulletSpawner.GetDamage(attackAmount);
            }
            audioSource.PlayOneShot(audioClip);
        }
        else if (other.gameObject.tag == "Monster2")
        {
            MonsterCtrl alien = other.GetComponent<MonsterCtrl>();

            if (alien != null)
            {
                alien.GetDamage(attackAmount);
            }
            audioSource.PlayOneShot(audioClip);
        }
    }
}
