using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TextCreator : MonoBehaviour
{
    public Canvas canvas = null;
    //public GameObject textPrefab = null;
    public FlyingText textPrefab = null;

    private System.Random random = new System.Random();

    private void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        Vector3 position = Vector3.zero;
        int r = 0;
        float speed = 0.0f;
        float time = 0.0f;

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

            FlyingText flyingText = Instantiate<FlyingText>(textPrefab, canvas.transform);
            flyingText.transform.position = new Vector3(position.x, position.y, flyingText.transform.position.z);
            flyingText.speed = speed;
            flyingText.SetText("Moutain");

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
