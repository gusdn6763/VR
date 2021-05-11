using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Drop : MonoBehaviour
{
    public Text text;
    public float waitTime = 2f;
    List<SpriteRenderer> tmp = new List<SpriteRenderer>();

    float x;
    float y;

    public void Start()
    {
        SpriteRenderer[] aatmp = FindObjectsOfType<SpriteRenderer>();
        x = Camera.main.orthographicSize;
        y = x * Camera.main.aspect;
        int tmpLength = aatmp.Length;
        for (int i = 0; i < aatmp.Length; i++)
        {
            tmp.Add(aatmp[i]);
        }
        StartCoroutine(start());
    }


    IEnumerator start()
    {
        for (int i = 0; i < tmp.Count; i++)
        {
            text.text = tmp[i].name.ToString();
            tmp[i].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            Instantiate(text, new Vector3(Random.Range(0f, x), 
                Random.Range(0f, y), 0), Quaternion.identity, transform);
            print(x + "" + y);
            yield return new WaitForSeconds(waitTime);
        }

    }
}
