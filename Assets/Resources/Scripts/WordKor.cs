using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordKor : MonoBehaviour
{
    public Text text = null;
    public float speed = 1.0f;

    private Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);

    void Start()
    {
        StartCoroutine(Life(1.0f));
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void SetText(string str)
    {
        text.text = str;
    }

    private IEnumerator Life(float time)
    {
        yield return new WaitForSeconds(time);

        Destroy(gameObject);
    }
}
