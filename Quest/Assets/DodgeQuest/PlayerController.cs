using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    public float hp = 100f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
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
}
