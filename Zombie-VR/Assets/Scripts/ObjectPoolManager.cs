using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    public BulletCtrl bullet;
    public List<BulletCtrl> bulletCtrl = new List<BulletCtrl>();
    public Transform firePos;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        MakeBullet(10);
    }

    public void MakeBullet(int count = 0)
    {
        for (int i = 0; i < count; i++)
        {
            BulletCtrl tmp = Instantiate(bullet, firePos).GetComponent<BulletCtrl>();
            bulletCtrl.Add(tmp);
            bulletCtrl[i].transform.SetParent(transform);
            bulletCtrl[i].transform.position = firePos.position;
            bulletCtrl[i].transform.name = "Bullet" + i.ToString();
            bulletCtrl[i].gameObject.SetActive(false);
        }
    }

    public void ActiveBullet(int i)
    {
        Instantiate(bullet, firePos.position, firePos.rotation).GetComponent<Rigidbody>().AddForce(firePos.forward * 10f);
        bulletCtrl[i].gameObject.SetActive(true);
    }

}