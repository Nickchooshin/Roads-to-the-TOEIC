using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public Text scoreText = null;
    public Image fadeImage = null;

    private int m_score = 0;
    
    void Start()
    {
        UpdateScore();
    }

    private void ScoreUp()
    {
        m_score += 12;

        UpdateScore();
    }

    private void ScoreDown()
    {
        m_score -= 10;

        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = string.Format("당신의 토익 점수 : {0:D3}점", m_score);
    }

    private void CheckScore()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float m_time = 0.0f;
        float maxTime = 2.0f;
        Color color = fadeImage.color;

        while (m_time < maxTime)
        {
            color.a = Mathf.Lerp(0.0f, maxTime, m_time);
            fadeImage.color = color;

            m_time += Time.deltaTime;

            yield return null;
        }
        
        if (m_score >= 400)
            SceneManager.LoadScene(2);
        else
            SceneManager.LoadScene(3);
    }
}
