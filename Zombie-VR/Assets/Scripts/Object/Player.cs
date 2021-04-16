using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovingObject
{
    public static Player instance;

    public enum CharacterStatus
    {
        NONE,
        IDLE,
        MOVE,
        ATTACK,
        DIE
    }

    public CharacterStatus playerStatus;
    private void Awake()
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
        playerStatus = CharacterStatus.DIE;
    }

    public void Dead()
    {
        StopAllCoroutines();
        dmgCheck = true;
        gameObject.SetActive(false);
    }
}
