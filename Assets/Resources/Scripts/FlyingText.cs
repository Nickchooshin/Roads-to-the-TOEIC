using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlyingText : MonoBehaviour
{
    public float speed = 3.0f;
    public Text text = null;
    public Score scoreObject = null;

    private string m_kor = "";
    private string m_lang = "";

    private Vector3 direction = new Vector3(-1.0f, 0.0f);
    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        if (transform.position.x < -7.4f)
            Destroy(gameObject);
    }

    public void Init(string word, string kor, string lang)
    {
        SetText(word);
        m_kor = kor;
        m_lang = lang;
    }

    public void SetText(string str)
    {
        text.text = str;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        scoreObject.SendMessage("ScoreUp");
        Destroy(gameObject);
    }
}
