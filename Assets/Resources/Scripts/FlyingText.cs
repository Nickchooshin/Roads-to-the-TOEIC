using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingText : MonoBehaviour
{
    public float speed = 3.0f;
    public Text text = null;

    private Vector3 direction = new Vector3(-1.0f, 0.0f);
    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x < -7.4f)
            Destroy(gameObject);
    }

    public void SetText(string str)
    {
        text.text = str;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("AAA");
    }
}
