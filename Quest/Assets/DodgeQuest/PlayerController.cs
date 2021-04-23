using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed = 8f;
    public float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        



    }

    public void Die()
    {
        gameObject.SetActive(false);
        FindObjectOfType<GameManager>().EndGame();
    }
    public void GetDamage(float amounnt)
    {
        hp -= (int)(amounnt / 2.0f);
        if (hp <= 0)
        {
            FindObjectOfType<GameManager>().isGameOver = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PUNCH")
        {
            GetDamage(10f);
        }
    }
}
