using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public static Player instance;

    private Shake Dmgshake;
    public override void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
        Dmgshake = GetComponent<Shake>();
    }

    public override void Damaged(float damage)
    {
        StartCoroutine(Dmgshake.ShakeCamera());
        base.Damaged(damage);
    }

    public void ResetPlayer()
    {
        
    }

    public void ResetInfo()
    {
        HP = 100f;
        currentHp = 100f;
        GetComponent<FireCtrl>().remainingBullet = 10;
    }


    public override void Die()
    {
        base.Die();
    }

    public void Dead()
    {
        StopAllCoroutines();
        dmgCheck = true;
        gameObject.SetActive(false);
    }
}
