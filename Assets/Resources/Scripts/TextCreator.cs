using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using LitJson;

public class TextCreator : MonoBehaviour
{
    public Canvas canvas = null;
    public FlyingText textPrefab = null;
    public Score scoreObject = null;

    private System.Random random = new System.Random();

    private TextAsset wordTextAsset = null;
    private JsonData wordData = null;

    private void Start()
    {
        wordTextAsset = Resources.Load<TextAsset>("Data/word");
        wordData = JsonMapper.ToObject(wordTextAsset.text);

        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        Vector3 position = Vector3.zero;
        int r = 0;
        float speed = 0.0f;
        float time = 0.0f;
        int listNumber = wordData.Count;

        while (true)
        {
            position = new Vector3(7.4f, 0.0f, 0.0f);

            // position
            r = random.Next(0, 2);

            switch (r)
            {
                case 0:
                    position.y = -3.0f;
                    break;
                case 1:
                    position.y = -1.0f;
                    break;
            }

            // speed
            r = random.Next(0, 2);

            switch (r)
            {
                case 0:
                    speed = 3.0f;
                    break;
                case 1:
                    speed = 5.0f;
                    break;
                case 2:
                    speed = 2.0f;
                    break;
            }

            // Instantiate
            r = random.Next(0, listNumber);

            FlyingText flyingText = Instantiate<FlyingText>(textPrefab, canvas.transform);
            string word = wordData[r]["word"].ToString();
            string kor = wordData[r]["kor"].ToString();
            string lang = wordData[r]["lang"].ToString();

            flyingText.transform.position = new Vector3(position.x, position.y, flyingText.transform.position.z);
            flyingText.speed = speed;
            flyingText.scoreObject = scoreObject;
            flyingText.Init(word, kor, lang);

            // wait time
            r = random.Next(0, 2);

            switch (r)
            {
                case 0:
                    time = 1.0f;
                    break;
                case 1:
                    time = 1.5f;
                    break;
                case 2:
                    time = 2.0f;
                    break;
            }

            yield return new WaitForSeconds(time);
        }
    }

    // 높이 -300, -100
}
