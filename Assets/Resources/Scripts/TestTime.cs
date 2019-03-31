using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestTime : MonoBehaviour
{
    public Text timeText = null;
    public float MaxTime = 60.0f;

    private float m_time = 0.0f;

    void Update()
    {
        m_time += Time.deltaTime;

        UpdateTime();
    }

    private void UpdateTime()
    {
        timeText.text = string.Format("시험 종료까지\n앞으로 {0:F2}초", (MaxTime - m_time));
    }
}
