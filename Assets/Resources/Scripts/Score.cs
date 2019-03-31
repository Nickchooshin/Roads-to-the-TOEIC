using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText = null;

    private int m_score = 0;
    
    void Start()
    {
        UpdateScore();
    }

    void ScoreUp()
    {
        m_score += 5;

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = string.Format("당신의 토익 점수 : {0:D3}점", m_score);
    }
}
